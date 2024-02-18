
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;

namespace KatmanliSiteYonetim.Controllers.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly ISiteService sm;
        private readonly IUserService um;
        private readonly ISiteYoneticisiService sym;
        private readonly IBlokService bm;
        private readonly IDaireService dm;

     

        public AdminController(ISiteService siteService, IUserService userService,
                               ISiteYoneticisiService siteYoneticisiService, IBlokService blokService,
                               IDaireService daireService)
        {
            sm = siteService;
            um = userService;
            sym = siteYoneticisiService;
            bm = blokService;
            dm = daireService;
        }




        public IActionResult YoneticiPanel()
        {

            return View();
        }


        public IActionResult AdminSite()
        {
            var valuesSite = sm.GetList();



            return View(valuesSite);
        }
        public IActionResult FilterAra(string filterAra, string category, string MainCategory)
        {
            if (MainCategory == "Site")
            {
                var sites = sm.GetList();

                if (filterAra == null)
                {

                    var sitesValue2 = JsonConvert.SerializeObject(sites);
                    return Json(sitesValue2);
                }
                else
                {
                    filterAra = filterAra.ToLower();


                    if (category == "SiteIsmi")
                    {
                        var sitesValue = sites.Where(s => s.SiteName.ToLower().Contains(filterAra))
                            .Select(s => new
                            {
                                SiteID = s.SiteID,
                                SiteName = s.SiteName,
                                Sehir = s.Sehir,
                                Adres = s.Adres
                            }).ToList();
                        var sitesValue2 = JsonConvert.SerializeObject(sitesValue);
                        return Json(sitesValue2);
                    }
                    else if (category == "SehirIsmi")
                    {
                        var sitesValue = sites.Where(s => s.Sehir.ToLower().Contains(filterAra))
                               .Select(s => new
                               {
                                   SiteID = s.SiteID,
                                   SiteName = s.SiteName,
                                   Sehir = s.Sehir,
                                   Adres = s.Adres
                               }).ToList();
                        var sitesValue2 = JsonConvert.SerializeObject(sitesValue);
                        return Json(sitesValue2);
                    }
                    else if (category == "AdresIsmi")
                    {
                        var sitesValue = sites.Where(s => s.Adres.ToLower().Contains(filterAra))
                             .Select(s => new
                             {
                                 SiteID = s.SiteID,
                                 SiteName = s.SiteName,
                                 Sehir = s.Sehir,
                                 Adres = s.Adres
                             }).ToList();
                        var sitesValue2 = JsonConvert.SerializeObject(sitesValue);
                        return Json(sitesValue2);
                    }


                } 
            }
            
            return View();
        }


        public IActionResult ListUser(string MainCategory)
        {

            var siteler = sm.GetList();
            var bloklar = bm.GetList();
            var bloklarTam = (from b in bloklar
                              join s in siteler on b.SiteID equals s.SiteID
                              select new
                              {
                                  BlockID = b.BlokID,
                                  SiteID = b.SiteID,
                                  SiteName = s.SiteName,
                                  BlockName = b.BlokName,
                                  Adres = s.Adres,

                              }).ToList();

            var daireler = dm.GetList();
            var dairelerTam = (from d in daireler
                               join b in bloklarTam on d.BlokID equals b.BlockID
                               select new
                               {
                                   BlockID = d.BlokID,
                                   SiteID = b.SiteID,
                                   DaireID = d.DaireID,
                                   KatNumarası=d.KatNumarasi,
                                   ExtraInfo=d.ExtraInformation,
                                   SiteName = b.SiteName,
                                   BlockName = b.BlockName,
                                   Adres = b.Adres,
                                   DaireNo=d.DaireNo,

                               }).ToList();

            var siteYoneticileri=sym.GetList();
            var siteYoneticileriTam= (from d in siteYoneticileri
                                      join s in siteler on d.SiteID equals s.SiteID
                                      select new
                                      {
                                          YöneticiID = d.YoneticiID,
                                          KullanıcıAdı = d.Name+" "+d.Surname,
                                          Adres = d.Adres,
                                          Phone = d.Phone,                                       
                                          SiteName = s.SiteName,
                                          BlockName = d.BlokName,
                                      }).ToList();

            if (MainCategory == "Site")
            {
                

                var JsonValeues = JsonConvert.SerializeObject(siteler);

                return Json(JsonValeues);
            }
            else if (MainCategory == "Blok")
            {
  

                var JsonValeues = JsonConvert.SerializeObject(bloklarTam);


                return Json(JsonValeues);
            }
            else if (MainCategory == "Daire")
            {
            
                var JsonValeues = JsonConvert.SerializeObject(dairelerTam);

                return Json(JsonValeues);
            }
            else if (MainCategory == "SiteYoneticisi")
            {
                var JsonValeues = JsonConvert.SerializeObject(siteYoneticileriTam);

                return Json(JsonValeues);
            }
            else if (MainCategory == "User")
            {
                var JsonValeues = JsonConvert.SerializeObject(um.GetList());

                return Json(JsonValeues);
            }

            return View();
        }

        public IActionResult AdminBlok(string filterAra)
        {
            var valuesSite = bm.GetList();

            if (!string.IsNullOrEmpty(filterAra))
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(filterAra, out filterAraInt);

                valuesSite = valuesSite.Where(x => x.BlokName.Contains(filterAra) ||
                               (isNumeric && (x.BlokID == filterAraInt || x.SiteID == filterAraInt)))
                              .ToList();
                return PartialView(valuesSite);
            }
            return View(valuesSite);


        }
        public IActionResult AdminDaire(string filterAra)
        {
            var valuesSite = dm.GetList();

            if (!string.IsNullOrEmpty(filterAra))
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(filterAra, out filterAraInt);

                valuesSite = valuesSite.Where(x => x.ExtraInformation.Contains(filterAra) ||
                               (isNumeric && (x.BlokID == filterAraInt || x.KatNumarasi == filterAraInt || x.DaireID == filterAraInt)))
                              .ToList();
                return PartialView(valuesSite);
            }
            return View(valuesSite);


        }


        public IActionResult AdminUser(string FilterUser)
        {
            var valuesUser = um.GetList();
            if (FilterUser != null)
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(FilterUser, out filterAraInt);
                valuesUser = valuesUser.Where(x => x.role.Contains(FilterUser) || x.email.Contains(FilterUser) || x.userName.Contains(FilterUser) || x.phone.Contains(FilterUser) ||
                     (isNumeric && (x.UserID == filterAraInt || x.YoneticiID == filterAraInt)))
                              .ToList();
                return PartialView(valuesUser);

            }

            return View(valuesUser);

        }

        public IActionResult AdminSiteYoneticisi(string FilterUser)
        {
            var valuesUser = sym.GetList();
            if (FilterUser != null)
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(FilterUser, out filterAraInt);
                valuesUser = valuesUser.Where(x => x.Name.Contains(FilterUser) || x.Surname.Contains(FilterUser) || x.Adres.Contains(FilterUser) || x.BlokName.Contains(FilterUser) ||
                     (isNumeric && (x.YoneticiID == filterAraInt || x.SiteID == filterAraInt || x.Phone == filterAraInt)))
                              .ToList();

                return PartialView(valuesUser);
            }

            return View(valuesUser);

        }

    }
}
