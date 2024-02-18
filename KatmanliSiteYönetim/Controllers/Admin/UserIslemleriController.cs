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
    public class UserIslemleriController : Controller
    {

        private readonly IUserService um;
        private readonly IMapper _mapper;
        public UserIslemleriController(IUserService userService)
        {

            um = userService;

        }

        [HttpGet]
        public IActionResult UserPaneli()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserPaneli(User u)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(u);




            if (results.IsValid)
            {
                um.TAdd(u);

                return RedirectToAction("YoneticiPanel", "Admin");
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


        public IActionResult userSil(int id)
        {

            var userRow = um.GetById(id);
            um.TDelete(userRow);

            return RedirectToAction("AdminUser", "Admin");
        }

        [HttpGet]
        public IActionResult userDuzenle(int id)
        {

            var userList = um.GetById(id);

            List<SelectListItem> values = (from y in um.GetList()
                                           group y by y.role into g
                                           select new SelectListItem
                                           {
                                               Text = g.Key.ToString(),
                                               Value = g.Key.ToString()
                                           }).ToList();


            ViewBag.siteIdListesi = values;



            User u = new User()
            {
                YoneticiID = userList.YoneticiID,
                UserID = userList.UserID,
                userName = userList.userName,
                userPassword = userList.userPassword,
                phone = userList.phone,
                email = userList.email,
                role = userList.role,

            };
            return View(u);
        }
        [HttpPost]
        public IActionResult userDuzenle(User u)
        {

            var UserUpdate = um.GetById(u.UserID);
            UserUpdate.userName = u.userName;
            UserUpdate.userPassword = u.userPassword;
            UserUpdate.phone = u.phone;
            UserUpdate.email = u.email;
            UserUpdate.role = u.role;
            UserUpdate.YoneticiID = u.YoneticiID;
            UserUpdate.UserID = u.UserID;

           

            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(u);


            if (results.IsValid)
            {
                um.TUpdate(UserUpdate);

                return RedirectToAction("AdminUser", "Admin");
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
