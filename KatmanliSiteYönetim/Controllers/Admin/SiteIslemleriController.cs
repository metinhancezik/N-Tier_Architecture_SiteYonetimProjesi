
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.SiteDTOs;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace KatmanliSiteYonetim.Controllers.Admin
{

    [Authorize(Policy = "AdminOnly")]
    public class SiteIslemleriController : Controller
    {
        private readonly ISiteService sm;
        private readonly IMapper _mapper;


        public SiteIslemleriController(ISiteService siteService, IMapper mapper)
        {
            sm = siteService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult ISLEM(int id, string parametre)
        {
            if (parametre == "ekle")
            {
                ViewBag.Check = "ekle";
                return View();
            }
            else if (parametre == "duzenle")
            {
                ViewBag.Check = "duzenle";
                ViewBag.ID = id;

                var siteList = sm.GetById(id);

                Site s = new Site()
                {
                    SiteID = siteList.SiteID,
                    SiteName = siteList.SiteName,
                    Adres = siteList.Adres,
                    Sehir = siteList.Sehir,
                    BlokSayısı = siteList.BlokSayısı,
                    DaireSayısı = siteList.DaireSayısı,
                    IsitmaTipi = siteList.IsitmaTipi
                };



                return Json(s);

            }
            return View();
        }
      
           
              
               
        public IActionResult SiteEkle(Site sy) 
        {
            SiteWriterValidator syv = new SiteWriterValidator();
            ValidationResult results = syv.Validate(sy);


            if (results.IsValid)
            {
                sm.TAdd(sy);

                return RedirectToAction("AdminSite", "Admin");
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
        
        public IActionResult SiteDuzenle(SiteAddDTO S,  int id)
        {
            
                var Sitelerl = sm.GetById(id);
                var siteUpdate = Sitelerl;
                siteUpdate.SiteName = Sitelerl.SiteName;
                siteUpdate.Adres = Sitelerl.Adres;
                siteUpdate.Sehir = Sitelerl.Sehir;
                siteUpdate.BlokSayısı = Sitelerl.BlokSayısı;
                siteUpdate.DaireSayısı = Sitelerl.DaireSayısı;
                siteUpdate.IsitmaTipi = Sitelerl.IsitmaTipi;

                sm.TUpdate(Sitelerl);
                return RedirectToAction("AdminSite", "Admin");
            }


        public IActionResult SiteSil(int id)
        {
            var satırTut = sm.GetById(id);

            sm.TDelete(satırTut);

            return RedirectToAction("AdminSite", "Admin");
        }






    }
}
