
using AutoMapper;
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

namespace KatmanliSiteYonetim.Controllers.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class DaireIslemleriController : Controller
    {
        private readonly ISiteService sm;

        private readonly IBlokService bm;
        private readonly IDaireService dm;
        private readonly IMapper _mapper;

        public DaireIslemleriController(ISiteService siteService, IBlokService blokService,
                               IDaireService daireService)
        {
            sm = siteService;
            bm = blokService;
            dm = daireService;
        }



        public IActionResult SiteSecimi()
        {
            var c = new Context();
            var siteListesi = c.Sites.ToList();
            ViewBag.SiteListesi = new SelectList(siteListesi, "SiteID", "SiteName");


            return View();
        }


        [HttpPost]
        public IActionResult SecilenSite(int SiteID)
        {
            Context c = new Context();
            var bloklar = c.Bloks.Where(b => b.SiteID == SiteID).ToList();
            ViewBag.Bloklar = new SelectList(bloklar, "BlokID", "BlokName");

            return RedirectToAction("DaireEkle", "DaireIslemleri", new { blokID = 0, siteID = SiteID });
        }


        [HttpGet]
        public IActionResult DaireEkle(int blokID, int siteID)
        {
            Context c = new Context();
            var bloklar = c.Bloks.Where(b => b.SiteID == siteID).ToList();
            ViewBag.Bloklar = new SelectList(bloklar, "BlokID", "BlokName", blokID);
            ViewBag.SeciliSiteID = siteID;
            return View();
        }



        [HttpPost]
        public IActionResult DaireEkle(Daire d)
        {

            DaireValidator dv = new DaireValidator();
            ValidationResult results = dv.Validate(d);

            if (d.ExtraInformation == null)
            {
                d.ExtraInformation = "YOK";
            }

            if (results.IsValid)
            {
                dm.TAdd(d);

                return RedirectToAction("AdminDaire", "Admin");
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


        public IActionResult DaireSil(int id)
        {
            var daireRow = dm.GetById(id);
            dm.TDelete(daireRow);


            return RedirectToAction("AdminDaire", "Admin");
        }

        public IActionResult DaireDuzenle(int id)
        {
            var blokList = dm.GetById(id);

            List<SelectListItem> values = (from y in dm.GetList()
                                           group y by y.BlokID into g
                                           select new SelectListItem
                                           {
                                               Text = g.Key.ToString(),
                                               Value = g.Key.ToString()
                                           }).ToList();

            ViewBag.BlokIdListesi = values;


            Daire d = new Daire()
            {
                BlokID = blokList.BlokID,
                DaireID = blokList.DaireID,
                KatNumarasi = blokList.KatNumarasi,
                ExtraInformation = blokList.ExtraInformation
            };
            return View(d);

        }
        [HttpPost]
        public IActionResult DaireUpdate(Daire d)
        {

            var daireUpdate = dm.GetById(d.BlokID);
            daireUpdate.BlokID = d.BlokID;
            daireUpdate.KatNumarasi = d.KatNumarasi;
            daireUpdate.ExtraInformation = d.ExtraInformation;

            DaireValidator dv = new DaireValidator();
            ValidationResult results = dv.Validate(daireUpdate);



            if (results.IsValid)
            {

                dm.TUpdate(daireUpdate);

                return RedirectToAction("AdminDaire", "Admin");
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
    }
}
