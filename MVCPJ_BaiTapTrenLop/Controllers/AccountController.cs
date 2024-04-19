using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class AccountController : Controller
    {
        DAOUser DAOUser = new DAOUser();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User currentUser = DAOUser.Login(user.Username, user.Password);
                if (currentUser != null)
                {
                    HttpContext.Session["User"] = currentUser;
                    HttpContext.Session["RoleId"] = currentUser.RoleId;
                    if (currentUser.RoleId == 1 || currentUser.RoleId == 2)
                        return RedirectToAction("Index", "Home", new {area = "Admin"});
                    else
                        return RedirectToAction("Index", "Home");
                }
                ViewBag.Alert = "Thông tin tài khoản và mật khẩu không chính xác";
            }
            return View(user);
        }

        [CustomAuthenticationFilter]
        public ActionResult Logout()
        {
            HttpContext.Session["User"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult AuthorizationAdminError()
        {
            return new ContentResult(){ Content = "Bạn không có đủ quyền truy cập đến đây :).", ContentType = "text/plain"};
        }

        [CustomAuthenticationFilter]
        public ActionResult MyProfile()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Chỉnh sửa thông tin", Url = "/Account/EditProfile" }
            };
            User user = (User) HttpContext.Session["User"];
            return View(user);
        }

        [CustomAuthenticationFilter]
        public ActionResult EditProfile()
        {
            User user = (User)HttpContext.Session["User"];
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(User user, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Thông tin cá nhân", Url = "/Account/MyProfile" },
                new BreadcrumbItem { Text = "Chỉnh sửa thông tin", Url = "/Account/EditProfile" }
            };
            string oldImage = user.Avatar;
            user.Avatar = "/Images/User/" + file.FileName;
            if (DAOUser.EditProfile(user) > 0)
            {
                System.IO.File.Delete(Server.MapPath("~") + oldImage);
                file.SaveAs(Server.MapPath("~") + user.Avatar);
                HttpContext.Session["User"] = DAOUser.GetById(user.ID);
                return RedirectToAction("MyProfile");
            }
            else
            {
                User currentUser = (User)HttpContext.Session["User"];
                return View(currentUser);
            }
        }
    }
}