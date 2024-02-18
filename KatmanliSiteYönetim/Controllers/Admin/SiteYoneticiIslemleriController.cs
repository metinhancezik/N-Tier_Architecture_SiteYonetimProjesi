using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KatmanliSiteYonetim.Controllers.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class SiteYoneticiIslemleriController : Controller
    {
        private readonly ISiteService sm;

        private readonly ISiteYoneticisiService sym;
        private readonly IMapper _mapper;


        public SiteYoneticiIslemleriController(ISiteService siteService,
                               ISiteYoneticisiService siteYoneticisiService)
        {
            sm = siteService;

            sym = siteYoneticisiService;

        }

        [HttpGet]
        public IActionResult SiteYoneticisiPaneli() //Yonetici ekleme Kismi
        {
            var siteList = sm.GetList();
            ViewBag.SiteSelectList = new SelectList(siteList, "SiteID", "SiteName");
            return View();
        }

        [HttpPost]
        public IActionResult SiteYoneticisiPaneli(SiteYoneticisi sy)
        {

            SiteYoneticisiValidator syv = new SiteYoneticisiValidator();
            ValidationResult results = syv.Validate(sy);


            if (results.IsValid)
            {
                sym.TAdd(sy);

                return RedirectToAction("AdminSiteYoneticisi", "Admin");
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
        public IActionResult SiteYoneticiSil(int id)
        {
            var siteYoneticiSatir = sym.GetById(id);
            sym.TDelete(siteYoneticiSatir);

            return RedirectToAction("AdminSiteYoneticisi", "Admin");
        }



        public IActionResult SiteYoneticiDuzenle(int id)
        {
            var syoneticiList = sym.GetById(id);

            List<SelectListItem> values = (from y in sym.GetList()
                                           group y by y.SiteID into g
                                           select new SelectListItem
                                           {
                                               Text = g.Key.ToString(),
                                               Value = g.Key.ToString()
                                           }).ToList();

            ViewBag.siteIdListesi = values;

            SiteYoneticisi s = new SiteYoneticisi()
            {
                YoneticiID = syoneticiList.YoneticiID,
                SiteID = syoneticiList.SiteID,
                Name = syoneticiList.Name,
                Surname = syoneticiList.Surname,
                Adres = syoneticiList.Adres,
                Phone = syoneticiList.Phone,
                BlokName = syoneticiList.BlokName,

            };
            return View(s);
        }

        [HttpPost]
        public IActionResult SiteYoneticiUpdate(SiteYoneticisi sy)
        {

            var siteYoneticiUpdate = sym.GetById(sy.YoneticiID);
            siteYoneticiUpdate.BlokName = sy.BlokName;
            siteYoneticiUpdate.SiteID = sy.SiteID;
            siteYoneticiUpdate.Adres = sy.Adres;
            siteYoneticiUpdate.Name = sy.Name;
            siteYoneticiUpdate.Surname = sy.Surname;
            siteYoneticiUpdate.Phone = sy.Phone;


            SiteYoneticisiValidator syv = new SiteYoneticisiValidator();
            ValidationResult results = syv.Validate(sy);


            if (results.IsValid)
            {
                sym.TUpdate(siteYoneticiUpdate);

                return RedirectToAction("AdminSiteYoneticisi", "Admin");
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
