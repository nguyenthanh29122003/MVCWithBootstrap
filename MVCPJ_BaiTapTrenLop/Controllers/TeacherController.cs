using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class TeacherController : Controller
    {
        private DAOTeacher daoTeacher = new DAOTeacher();
        // GET: Teacher
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Danh sách giáo viên", Url = "/Teacher/Index" }
            };
            List<Teacher> teachers = daoTeacher.GetTeachers();
            return View(teachers);
        }
    }
}