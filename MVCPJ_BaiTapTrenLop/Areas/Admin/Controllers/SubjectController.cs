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
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class SubjectController : Controller
    {
        private DAOSubject DAOSubject = new DAOSubject();

        // GET: Admin/Subject
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" }
            };
            var subjects = DAOSubject.GetSubjects();
            return View(subjects);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Chi tiết môn học", Url = "#" }
            };
            var subject = DAOSubject.GetSubjectById(id);
            return View(subject);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa môn học", Url = "#" }
            };
            var subject = DAOSubject.GetSubjectById(id);
            return View(subject);
        }

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa môn học", Url = "#" }
            };
            if (ModelState.IsValid)
            {
                DAOSubject.UpdateSubject(subject);
                ViewBag.Noti = "Sửa thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Noti = "Sửa không thành công!";
                return View(subject);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Tạo mới môn học", Url = "#" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Tạo mới môn học", Url = "#" }
            };
            if (ModelState.IsValid)
            {
                DAOSubject.InsertSubject(subject);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subject);
            }
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Xóa môn học", Url = "#" }
            };
            var subject = DAOSubject.GetSubjectById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Admin/Subject/Delete/5
        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý môn học", Url = "/Admin/Subject/Index" },
                new BreadcrumbItem { Text = "Xóa môn học", Url = "#" }
            };
            try
            {
                DAOSubject.DeleteSubject(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi khi xóa môn học. Vui lòng thử lại sau.");
                return View();
            }
        }
    }
}
