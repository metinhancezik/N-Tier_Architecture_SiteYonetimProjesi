
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KatmanliSiteYonetim.Controllers.Yonetim
{
    [Authorize(Policy = "YoneticiOnly")]
    public class YonetimController : Controller
    {

        private readonly ISiteService sm;
        private readonly IUserService um;
        private readonly ISiteYoneticisiService sym;



        public YonetimController(ISiteService siteService, IUserService userService,
                               ISiteYoneticisiService siteYoneticisiService)
        {
            sm = siteService;
            um = userService;
            sym = siteYoneticisiService;

        }

        public IActionResult SiteYonetimPaneli()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                Context c = new Context();



                var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);

                if (siteManager != null)
                {

                    var SiteInfo = sm.GetById(siteManager.SiteID);
                    ViewBag.SiteName = SiteInfo.SiteName;


                    return View(siteManager);
                }
            }
            else
            {

            }

            return View();
        }
    }
}
