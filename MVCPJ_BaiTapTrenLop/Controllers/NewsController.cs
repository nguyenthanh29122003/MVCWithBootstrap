using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DAOAdvertisement daoAdvertisement = new DAOAdvertisement();
        DAONews daoNews = new DAONews();
        DAONewsCategory DAONewsCategory = new DAONewsCategory();
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Tin tức", Url = "/News/Index" }
            };
            ViewBag.LastestNews = daoNews.GetTop5News();
            ViewBag.NewsCategories = DAONewsCategory.GetNewsCategories();
            return View(daoAdvertisement.GetAdvertisements());
        }
    }
}