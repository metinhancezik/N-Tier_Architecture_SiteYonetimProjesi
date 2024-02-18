
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq.Expressions;

namespace KatmanliSiteYonetim.Controllers.Yonetim
{
    [Authorize(Policy = "YoneticiOnly")]
    public class AidatController : Controller
    {

        private readonly ISiteService sm;
        private readonly IUserService um;
        private readonly ISiteYoneticisiService sym;
        private readonly IBlokService bm;
        private readonly IDaireService dm;
        private readonly IAidatService aim;
        private readonly IEvSahibiKiraciService eskm;


        public AidatController(ISiteService siteService, IUserService userService,
                               ISiteYoneticisiService siteYoneticisiService, IBlokService blokService,
                               IDaireService daireService, IEvSahibiKiraciService evSahibiKiraciService, IAidatService aidatService)
        {
            sm = siteService;
            um = userService;
            sym = siteYoneticisiService;
            bm = blokService;
            dm = daireService;
            eskm = evSahibiKiraciService;
            aim = aidatService;
        }

        public IActionResult AidatPaneli(string filterAra)
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);
            var bloklar = c.Bloks.Where(a => a.SiteID == siteManager.SiteID).ToList();

            var BlokIds = c.Bloks.FirstOrDefault(x => x.SiteID == siteManager.SiteID);
            var daires = c.Daires.Where(b => b.BlokID == BlokIds.BlokID).ToList();
            var DaireIds = c.Daires.FirstOrDefault(x => x.BlokID == BlokIds.BlokID);
            var evSahipleri = c.EvSahibis.Where(x => x.DaireID == DaireIds.DaireID).ToList();
            var Aidats = c.Aidats.Join(
                       c.Daires.Where(d => d.BlokID == BlokIds.BlokID),
                       aidat => aidat.DaireID,
                       daire => daire.DaireID,
                       (aidat, daire) => aidat
                   ).ToList();


            ViewBag.siteID = siteManager.SiteID;
            var viewModelList = new List<AidatView>();


            foreach (var item in Aidats)
            {
                var viewModel = new AidatView
                {
                    SiteID = siteManager.SiteID,
                    AidatID = item.AidatID,
                    BlokID = BlokIds.BlokID,
                    DaireID = item.DaireID,
                    Tutar = item.Tutar,
                    Odenmis = item.Odenmis,
                    Date = item.Date
                };

                var oturanKisiler = c.EvSahibis.Where(x => x.DaireID == item.DaireID).ToList();

                viewModel.OturanKisiName = string.Join(", ", oturanKisiler.Select(x => x.Name));
                viewModelList.Add(viewModel);
            }

            if (!string.IsNullOrEmpty(filterAra))
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(filterAra, out filterAraInt);
                viewModelList = viewModelList.Where(x => x.OturanKisiName.Contains(filterAra) ||
                  (isNumeric && (x.Tutar == filterAraInt || x.Odenmis == filterAraInt || x.BlokID == filterAraInt || x.DaireID == filterAraInt || x.Date.Day == filterAraInt || x.Date.Month == filterAraInt || x.Date.Year == filterAraInt))).ToList();

                return PartialView(viewModelList);
            }

            return View(viewModelList);
        }



        [HttpGet]
        public IActionResult AidatEkle()
        {

            return View();
        }


        [HttpPost]
        public IActionResult AidatEkle(Aidat A)
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);
            var BlokIds = c.Bloks.FirstOrDefault(x => x.SiteID == siteManager.SiteID);
            var daires = c.Daires.Where(b => b.BlokID == BlokIds.BlokID).ToList();
            DateTime now = DateTime.Now;

            foreach (var dai in daires)
            {


                var newAidat = new Aidat
                {
                    DaireID = dai.DaireID,
                    Tutar = A.Tutar,
                    Odenmis = 0,
                    Date = now
                };

                Expression<Func<Aidat, bool>> kriter = x => x.DaireID == newAidat.DaireID;
                var aidat = aim.TGetByFilter(kriter);

                if (aidat != null)
                {
                    aidat.Tutar += A.Tutar;
                    aim.TUpdate(aidat);
                }
                else
                {
                    aim.TAdd(newAidat);
                }
            }

            return RedirectToAction("AidatPaneli", "Aidat");
        }



        public IActionResult OdemeEkle(int id)
        {
            var odenen = aim.GetById(id);

            return View(odenen);
        }

        [HttpPost]
        public IActionResult OdemeUpdate(Aidat odenen)
        {
            var OdemeUpdate = aim.GetById(odenen.AidatID);
            OdemeUpdate.DaireID = odenen.DaireID;
            OdemeUpdate.Tutar = odenen.Tutar;
            OdemeUpdate.Odenmis += odenen.Odenmis;
            OdemeUpdate.Date = DateTime.Now;

            aim.TUpdate(OdemeUpdate);

            return RedirectToAction("AidatPaneli", "Aidat");
        }
    }
}


