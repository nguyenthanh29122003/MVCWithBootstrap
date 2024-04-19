using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class TeacherController : Controller
    {
        private DAOTeacher daoTeacher = new DAOTeacher();
        private const int PageSize = 5; // Số lượng bản ghi trên một trang

        // GET: Admin/Teacher
        public ActionResult Index(int page = 1)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" }
            };

            List<Teacher> teachers = daoTeacher.GetTeachers();

            // Phân trang
            int totalRecords = teachers.Count;
            teachers = teachers.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.TotalRecords = totalRecords;
            ViewBag.PageSize = PageSize;
            ViewBag.CurrentPage = page;

            return View(teachers);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Chi tiết giáo viên", Url = "/Admin/Teacher/Details" }
            };
            Teacher teacher = daoTeacher.GetTeacherById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Thêm mới giáo viên", Url = "/Admin/Teacher/Details" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Thêm mới giáo viên", Url = "/Admin/Teacher/Create" }
            };
            if (ModelState.IsValid)
            {
                if (file == null)
                    return View(teacher);
                else
                {
                    string imgName = file.FileName;
                    string imgPath = "/Images/Teacher/" + imgName;
                    teacher.ImagePath = imgPath;
                    if(daoTeacher.InsertTeacher(teacher) > 0)
                    {
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                    return RedirectToAction("Index");
                }
            }
            //else
            //{
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var state = ModelState[key];
            //        if (state.Errors.Count > 0)
            //        {
            //            var value = state.Value?.AttemptedValue ?? "NULL";
            //            var error = state.Errors.FirstOrDefault()?.ErrorMessage ?? "Unknown Error";
            //            System.Diagnostics.Debug.WriteLine($"Key: {key}, Value: {value}, Error: {error}");
            //        }
            //    }
            //}
            return View(teacher);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa giáo viên", Url = $"/Admin/Teacher/Edit/{id}" }
            };
            Teacher teacher = daoTeacher.GetTeacherById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa giáo viên", Url = $"/Admin/Teacher/Edit/{teacher.TeacherID}" }
            };
            if (ModelState.IsValid)
            {
                if(file == null)
                    daoTeacher.UpdateTeacher(teacher);
                else
                {
                    string imgPath = teacher.ImagePath;
                    if(daoTeacher.UpdateTeacher(teacher) > 0)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + imgPath);
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Xóa giáo viên", Url = $"/Admin/Teacher/Delete{id}" }
            };
            var teacher = daoTeacher.GetTeacherById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý giáo viên", Url = "/Admin/Teacher/Index" },
                new BreadcrumbItem { Text = "Xóa giáo viên", Url = $"/Admin/Teacher/Delete{id}" }
            };
            daoTeacher.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

    }
}
