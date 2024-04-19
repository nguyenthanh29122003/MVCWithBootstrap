using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        private DAOSubject DAOSubject = new DAOSubject();
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Danh sách học phần", Url = "/Subject/Index" }
            };
            var subjects = DAOSubject.GetSubjects();
            return View(subjects);
        }
    }
}