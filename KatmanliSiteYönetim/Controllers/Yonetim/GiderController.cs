
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KatmanliSiteYonetim.Controllers.Yonetim
{
    [Authorize(Policy = "YoneticiOnly")]
    public class GiderController : Controller
    {

        private readonly ISiteService sm;
        private readonly IUserService um;
        private readonly ISiteYoneticisiService sym;
        private readonly IBlokService bm;
        private readonly IDaireService dm;
        private readonly IAidatService aim;
        private readonly IEvSahibiKiraciService eskm;
        private readonly IGiderService gm;

        public GiderController(ISiteService siteService, IUserService userService,
                               ISiteYoneticisiService siteYoneticisiService, IBlokService blokService,
                               IDaireService daireService, IEvSahibiKiraciService evSahibiKiraciService, IAidatService aidatService, IGiderService giderServices)
        {
            sm = siteService;
            um = userService;
            sym = siteYoneticisiService;
            bm = blokService;
            dm = daireService;
            eskm = evSahibiKiraciService;
            aim = aidatService;
            gm = giderServices;
        }
        public IActionResult GiderPaneli(string filterAra)
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);
            var SiteInfo = sm.GetById(siteManager.SiteID);
            var Giderler = gm.GetList().Where(x => x.SiteID == siteManager.SiteID).ToList();

            if (!string.IsNullOrEmpty(filterAra))
            {
                int filterAraInt;
                bool isNumeric = int.TryParse(filterAra, out filterAraInt);

                Giderler = Giderler.Where(x => x.HarcamaCinsi.Contains(filterAra) || x.Sirket.Contains(filterAra) || x.ExtraInformation.Contains(filterAra) ||
                        (isNumeric && (x.HarcananTutar == filterAraInt || x.Date.Day == filterAraInt || x.Date.Month == filterAraInt || x.Date.Year == filterAraInt))).ToList();
                return PartialView(Giderler);
            }

            return View(Giderler);
        }
        [HttpGet]
        public IActionResult GiderEkle()
        {


            return View();
        }

        [HttpPost]
        public IActionResult GiderEkle(Gider G)
        {
            Context c = new Context();
            int? userId = HttpContext.Session.GetInt32("UserId");
            var siteManager = c.SiteYoneticisis.FirstOrDefault(x => x.YoneticiID == userId);

            G.SiteID = siteManager.SiteID;
            G.Date = DateTime.Now;

            gm.TAdd(G);


            return RedirectToAction("GiderPaneli", "Gider");
        }
    }
}
