using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Filters;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthorizationFilter]
    [CustomAuthenticationFilter]
    public class NewsController : Controller
    {
        private DAONews DAONews = new DAONews();
        private DAONewsCategory DAONewsCategory = new DAONewsCategory();

        // GET: Admin/News
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" }
            };
            var news = DAONews.GetNews();
            return View(news);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Chi tiết tin tức", Url = "#" }
            };
            var news = DAONews.GetNewsByID(id);
            return View(news);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa tin tức", Url = "#" }
            };
            var news = DAONews.GetNewsByID(id);
            ViewBag.CategoryList = new SelectList(DAONewsCategory.GetNewsCategories(), "ID", "Name", news.CategoryID);
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(News news, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa tin tức", Url = "#" }
            };

            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ViewBag.CategoryList = new SelectList(DAONewsCategory.GetNewsCategories(), "ID", "Name", news.CategoryID);
                    return View(news);
                }
                else
                {
                    string imgPath = news.TitleImage;
                    if (DAONews.UpdateNews(news) > 0)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + imgPath);
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Tạo mới tin tức", Url = "#" }
            };
            ViewBag.CategoryList = new SelectList(DAONewsCategory.GetNewsCategories(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(News news, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Tạo mới tin tức", Url = "#" }
            };

            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ViewBag.CategoryList = new SelectList(DAONewsCategory.GetNewsCategories(), "ID", "Name", news.CategoryID);
                    return View(news);
                }
                else
                {
                    string imgName = file.FileName;
                    string imgPath = "/Images/News/" + imgName;
                    news.TitleImage = imgPath;
                    if (DAONews.InsertNews(news) > 0)
                    {
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                    else
                    {
                        ViewBag.CategoryList = new SelectList(DAONewsCategory.GetNewsCategories(), "ID", "Name", news.CategoryID);
                        return View(news);
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(news);
        }
        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Xóa tin tức", Url = "#" }
            };
            return View(DAONews.GetNewsByID(id));
        }
        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý tin tức", Url = "/Admin/News/Index" },
                new BreadcrumbItem { Text = "Xóa tin tức", Url = "#" }
            };
            DAONews.DeleteNews(id);
            return RedirectToAction("Index");
        }
    }
}
