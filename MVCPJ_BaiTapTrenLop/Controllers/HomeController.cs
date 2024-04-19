using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DAOAdvertisement daoAdvertisement = new DAOAdvertisement();
        DAONews daoNews = new DAONews();
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" }
            };

            List<Advertisement> list = daoAdvertisement.GetAdvertisements();
            list.RemoveAt(1);
            list.RemoveAt(2);
            list.RemoveAt(3);

            ViewBag.LastestNews = daoNews.GetTop5News();
            ViewBag.Advertisements = list;

            return View();
        }
    }
}