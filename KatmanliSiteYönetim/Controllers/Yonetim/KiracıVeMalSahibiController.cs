
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace KatmanliSiteYonetim.Controllers.Yonetim
{
    [Authorize(Policy = "YoneticiOnly")]
    public class KiracıVeMalSahibiController : Controller
    {

        private readonly ISiteService sm;
        private readonly IUserService um;
        private readonly ISiteYoneticisiService sym;
        private readonly IBlokService bm;
        private readonly IDaireService dm;
        private readonly IEvSahibiKiraciService eskm;


        public KiracıVeMalSahibiController(ISiteService siteService, IUserService userService,
                               ISiteYoneticisiService siteYoneticisiService, IBlokService blokService,
                               IDaireService daireService, IEvSahibiKiraciService evSahibiKiraciService)
        {
            sm = siteService;
            um = userService;
            sym = siteYoneticisiService;
            bm = blokService;
            dm = daireService;
            eskm = evSahibiKiraciService;

        }


        public IActionResult KiracıVeMalSahibiPaneli(string filterAra)
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);
            var SiteInfo = sm.GetById(siteManager.SiteID);
            var bloklar = c.Bloks.Where(x => x.SiteID == SiteInfo.SiteID).ToList();
            var daireler = c.Daires.ToList().Where(x => bloklar.Any(b => b.BlokID == x.BlokID)).ToList();
            var evSahibiKiracilar = c.EvSahibis
        .Include(x => x.Daire)
        .Where(x => daireler.Select(d => d.DaireID).Contains(x.DaireID))
        .ToList();


            if (!string.IsNullOrEmpty(filterAra))
            {
                evSahibiKiracilar = evSahibiKiracilar
                    .Where(x => x.Name.Contains(filterAra) || x.Surname.Contains(filterAra) || x.Role.Contains(filterAra) || x.Mail.Contains(filterAra))
                    .ToList();
                evSahibiKiracilar = evSahibiKiracilar.OrderBy(x => x.Name).ToList();
                return PartialView(evSahibiKiracilar);
            }

            evSahibiKiracilar = evSahibiKiracilar.OrderBy(x => x.Name).ToList();

            return View(evSahibiKiracilar);
        }

        [HttpGet]
        public IActionResult BlokSec()
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);
            var SiteInfo = sm.GetById(siteManager.SiteID);
            var bloklar = c.Bloks.Where(x => x.SiteID == SiteInfo.SiteID).ToList();
            var daireler = c.Daires.ToList().Where(x => bloklar.Any(b => b.BlokID == x.BlokID)).ToList();
            ViewBag.blokList = new SelectList(bloklar, "BlokID", "BlokName");

            return View();
        }

        [HttpPost]
        public IActionResult BlokSec(int BLOKID)
        {


            return RedirectToAction("KiracıVeMalSahibiEkle", "KiracıVeMalSahibi", new { blokID = BLOKID });

        }
        [HttpGet]
        public IActionResult KiracıVeMalSahibiEkle(int blokID)
        {
            Context c = new Context();
            var daireler = c.Daires.Where(b => b.BlokID == blokID).ToList();

            ViewBag.DaireList = new SelectList(daireler, "DaireID", "DaireID");

            return View();
        }

        [HttpPost]
        public IActionResult KiracıVeMalSahibiEkle(EvSahibiKiraci esk)
        {
            MalSahibiValidator msw = new MalSahibiValidator();
            ValidationResult results = msw.Validate(esk);


            if (results.IsValid)
            {
                eskm.TAdd(esk);

                return RedirectToAction("KiracıVeMalSahibiPaneli", "KiracıVeMalSahibi");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();

        }
        public IActionResult KiracıVeyaMalSahibiSil(int id)
        {
            var satırTut = eskm.GetById(id);


            eskm.TDelete(satırTut);

            return RedirectToAction("KiracıVeMalSahibiPaneli", "KiracıVeMalSahibi");
        }

        public IActionResult KiracıVeyaMalSahibiDuzenle(int id)
        {

            var MalSahibiList = eskm.GetById(id);


            EvSahibiKiraci esk = new EvSahibiKiraci()
            {
                DaireID = MalSahibiList.DaireID,
                Name = MalSahibiList.Name,
                Surname = MalSahibiList.Surname,
                Telefon = MalSahibiList.Telefon,
                Mail = MalSahibiList.Mail,
                Role = MalSahibiList.Role,
                EvSahibiID = MalSahibiList.EvSahibiID
            };
            return View(esk);

        }

        [HttpPost]
        public IActionResult KiraciVeyaMalSahibiUpdate(EvSahibiKiraci esk)
        {
            var MalSahibiUpdate = eskm.GetById(esk.EvSahibiID);
            MalSahibiUpdate.DaireID = esk.DaireID;
            MalSahibiUpdate.Name = esk.Name;
            MalSahibiUpdate.Surname = esk.Surname;
            MalSahibiUpdate.Telefon = esk.Telefon;
            MalSahibiUpdate.Role = esk.Role;


            MalSahibiValidator msv = new MalSahibiValidator();
            ValidationResult results = msv.Validate(esk);


            if (results.IsValid)
            {
                eskm.TUpdate(MalSahibiUpdate);

                return RedirectToAction("KiracıVeMalSahibiPaneli", "KiracıVeMalSahibi");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return RedirectToAction("KiracıVeMalSahibiPaneli", "KiracıVeMalSahibi");
        }


    }
}

