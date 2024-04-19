using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPJ_BaiTapTrenLop.Filters;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" }
            };
            return View();
        }
    }
}