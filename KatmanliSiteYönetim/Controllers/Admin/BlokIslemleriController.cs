
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KatmanliSiteYonetim.Controllers.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class BlokIslemleriController : Controller
    {
        private readonly ISiteService sm;
        private readonly IBlokService bm;
        private readonly IMapper _mapper;

        public BlokIslemleriController(ISiteService siteService
                                , IBlokService blokService)
        {
            sm = siteService;
            bm = blokService;
        }


        [HttpGet]
        public IActionResult BlokEkle()
        {

            var siteList = sm.GetList();
            ViewBag.SiteSelectList = new SelectList(siteList, "SiteID", "SiteName");


            return View();
        }
        [HttpPost]
        public IActionResult BlokEkle(Blok b)
        {

            var siteList = sm.GetList();
            ViewBag.SiteSelectList = new SelectList(siteList, "SiteID", "SiteName");

            BlokValidator bv = new BlokValidator();
            ValidationResult results = bv.Validate(b);



            if (results.IsValid)
            {




                bm.TAdd(b);

                return RedirectToAction("AdminBlok", "Admin");
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


        public IActionResult BlokSil(int id)
        {

            var blokRow = bm.GetById(id);
            bm.TDelete(blokRow);

            return RedirectToAction("AdminBlok", "Admin");
        }






        public IActionResult BlokDuzenle(int id)
        {

            var siteList = bm.GetById(id);

            List<SelectListItem> values = (from y in bm.GetList()
                                           group y by y.SiteID into g
                                           select new SelectListItem
                                           {
                                               Text = g.Key.ToString(),
                                               Value = g.Key.ToString()
                                           }).ToList();

            ViewBag.siteIdListesi = values;


            Blok b = new Blok()
            {
                BlokID = siteList.BlokID,
                SiteID = siteList.SiteID,
                BlokName = siteList.BlokName
            };
            return View(b);


        }
        [HttpPost]
        public IActionResult BlokUpdate(Blok b)
        {

            var blokUpdate = bm.GetById(b.BlokID);
            blokUpdate.BlokName = b.BlokName;
            blokUpdate.SiteID = b.SiteID;


            BlokValidator bv = new BlokValidator();
            ValidationResult results = bv.Validate(blokUpdate);



            if (results.IsValid)
            {

                bm.TUpdate(blokUpdate);

                return RedirectToAction("AdminBlok", "Admin");
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
