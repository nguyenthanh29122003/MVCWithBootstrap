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
    public class NewsCategoryController : Controller
    {
        DAONewsCategory DAONewsCategory = new DAONewsCategory();
        // GET: Admin/NewsCategory
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" }
            };
            return View(DAONewsCategory.GetNewsCategories());
        }
        
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Chi tiết nhóm tin", Url = "#" }
            };
            return View(DAONewsCategory.GetNewsCategoryByID(id));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa nhóm tin", Url = "#" }
            };
            return View(DAONewsCategory.GetNewsCategoryByID(id));
        }
        [HttpPost]
        public ActionResult Edit(NewsCategory newsCategory)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa nhóm tin", Url = "#" }
            };
            if (DAONewsCategory.UpdateNewsCategory(newsCategory) > 0)
                ViewBag.Noti = "Sửa thành công!";
            else
                ViewBag.Noti = "Sửa không thành công!";
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Tạo mới nhóm tin", Url = "#" }
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsCategory newsCategory)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Tạo mới nhóm tin", Url = "#" }
            };
            DAONewsCategory.InsertNewsCategory(newsCategory);
            return RedirectToAction("Index");
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Xóa nhóm tin", Url = "#" }
            };
            return View(DAONewsCategory.GetNewsCategoryByID(id));
        }
        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(NewsCategory newsCategory)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý nhóm tin", Url = "/Admin/NewsCategory/Index" },
                new BreadcrumbItem { Text = "Xóa nhóm tin", Url = "#" }
            };
            DAONewsCategory.DeleteNewsCategory(newsCategory.ID);
            return RedirectToAction("Index");
        }
    }
}