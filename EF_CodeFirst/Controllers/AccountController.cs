using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EF_CodeFirst.Models;
using EF_CodeFirst.ViewModels;
using EF_CodeFirst.Identity;
using System.Web.Helpers; //Crypto
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;

namespace EF_CodeFirst.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);

                var passwordHash = Crypto.HashPassword(registerVM.Password);
                var user = new AppUser()
                {
                    UserName = registerVM.Username,
                    PasswordHash = passwordHash,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber,
                    DateOfBirth = registerVM.DateOfBirth,
                    Address = registerVM.Address,
                    City = registerVM.City,
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    LoginUser(userManager, user);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New error", "Invalid data.");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var appUserManager = new AppUserManager(userStore);

            var user = appUserManager.Find(loginVM.Username, loginVM.Password);
            if(user != null)
            {
                LoginUser(appUserManager, user);
                if(appUserManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new {area = "Admin"});
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password.");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult MyProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var appUserManager = new AppUserManager(userStore);
                var user = appUserManager.FindByName(User.Identity.Name);

                RegisterVM registerVM = new RegisterVM()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    DateOfBirth = user.DateOfBirth,
                    Address = user.Address,
                    City = user.City,
                };
                return View(registerVM);
            }
            return RedirectToAction("Index", "Home");
        }
        
        //public ActionResult MyProfile()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var appDbContext = new AppDbContext();
        //        var userStore = new AppUserStore(appDbContext);
        //        var appUserManager = new AppUserManager(userStore);
        //        var user = appUserManager.FindById(User.Identity.GetUserId());
        //        return View(User);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        [NonAction]
        public void LoginUser(AppUserManager userManager, AppUser user)
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
    }
}