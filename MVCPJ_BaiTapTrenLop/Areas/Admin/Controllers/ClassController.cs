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
    public class ClassController : Controller
    {
        DAOClass DAOClass = new DAOClass();

        // GET: Admin/Class
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" }
            };

            return View(DAOClass.GetClasses());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Chi tiết lớp học", Url = "#" }
            };
            return View(DAOClass.GetClassById(id));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa lớp học", Url = "#" }
            };

            return View(DAOClass.GetClassById(id));
        }

        [HttpPost]
        public ActionResult Edit(Class cls)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa lớp học", Url = "#" }
            };

            if (DAOClass.UpdateClass(cls) > 0)
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
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Tạo mới lớp học", Url = "#" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Create(Class cls)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Tạo mới lớp học", Url = "#" }
            };
            DAOClass.InsertClass(cls);
            return RedirectToAction("Index");
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Xóa lớp học", Url = "#" }
            };
            return View(DAOClass.GetClassById(id));
        }

        [HttpPost, ActionName("Delete")]
        [CustomAdminAuthorizationFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lớp học", Url = "/Admin/Class/Index" },
                new BreadcrumbItem { Text = "Xóa lớp học", Url = "#" }
            };
            DAOClass.DeleteClass(id);
            return RedirectToAction("Index");
        }
    }
}
