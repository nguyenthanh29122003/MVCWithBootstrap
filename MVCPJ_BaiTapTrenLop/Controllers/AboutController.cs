using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class AboutController : Controller
    {
        DAOAbout DAOAbout = new DAOAbout();
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/" },
                new BreadcrumbItem { Text = "Giới thiệu", Url = $"/About/Index" }
            };
            return View(DAOAbout.GetAbout());
        }
    }
}