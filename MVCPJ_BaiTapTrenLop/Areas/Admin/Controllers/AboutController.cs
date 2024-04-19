using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class AboutController : Controller
    {
        DAOAbout DAOAbout = new DAOAbout();
        // GET: Admin/About
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giới thiệu", Url = "/Admin/About/Index" }
            };
            About about = DAOAbout.GetAbout();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giới thiệu", Url = "/Admin/About/Index" }
            };
            int i = DAOAbout.UpdateAbout(about);
            return View(about);
        }
    }
}