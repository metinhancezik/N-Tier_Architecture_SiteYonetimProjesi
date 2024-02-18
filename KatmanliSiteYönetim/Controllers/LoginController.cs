using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace KatmanliSiteYönetim.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {



        [HttpGet]
        public IActionResult LoginPanel()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> LoginPanel(User u)
        {
            using (Context c = new Context())
            {
                User user = await c.Users.FirstOrDefaultAsync(x => x.userName == u.userName && x.userPassword == u.userPassword);

                if (user != null)
                {
                    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, u.userName)
    };

                    if (user.role == "Admin")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    if (user.role == "SiteYoneticisi")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "SiteYoneticisi"));
                    }

                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                    await HttpContext.SignInAsync(principal);

                    if (user.role == "Admin")
                    {
                        return RedirectToAction("YoneticiPanel", "Admin");
                    }
                    else if (user.role == "SiteYoneticisi")
                    {
                        HttpContext.Session.SetInt32("UserId", user.YoneticiID);
                        return RedirectToAction("SiteYonetimPaneli", "Yonetim", new { id = user.YoneticiID });
                    }
                    else
                    {
                        return RedirectToAction("ErrorPage", "Error");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
            }
        }

    }

}
