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
    public class ScoreController : Controller
    {
        private DAOScore DAOScore = new DAOScore();
        private DAOSubject DAOSubject = new DAOSubject();
        private DAOClass DAOClass = new DAOClass();

        // GET: Admin/Score
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" }
            };
            return View(DAOScore.GetScores());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Chi tiết điểm", Url = "#" }
            };
            return View(DAOScore.GetScoreById(id));
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Nhập điểm", Url = "#" }
            };
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName");
            ViewBag.Classes = new SelectList(DAOClass.GetClasses(), "ClassID", "ClassName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Score score, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Nhập điểm", Url = "#" }
            };
            if (file != null)
            {
                if (ModelState.IsValid)
                {
                    score.ScoreImage = "/Images/Score/" + file.FileName;
                    if (DAOScore.InsertScore(score) > 0)
                    {
                        file.SaveAs(Server.MapPath("~") + score.ScoreImage);
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName");
            ViewBag.Classes = new SelectList(DAOClass.GetClasses(), "ClassID", "ClassName");
            return View(score);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa điểm", Url = "#" }
            };
            var score = DAOScore.GetScoreById(id);
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName", score.SubjectID);
            ViewBag.Classes = new SelectList(DAOClass.GetClasses(), "ClassID", "ClassName", score.ClassID);
            return View(score);
        }

        [HttpPost]
        public ActionResult Edit(Score score, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa điểm", Url = "#" }
            };
            if (file != null)
            {
                if (ModelState.IsValid)
                {
                    string oldImageURL = score.ScoreImage;
                    if (DAOScore.UpdateScore(score) > 0)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + oldImageURL);
                        file.SaveAs(Server.MapPath("~") + oldImageURL);
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName");
            ViewBag.Classes = new SelectList(DAOClass.GetClasses(), "ClassID", "ClassName");
            return View(score);
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Xóa sửa điểm", Url = "#" }
            };
            return View(DAOScore.GetScoreById(id));
        }
        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý điểm", Url = "/Admin/Score/Index" },
                new BreadcrumbItem { Text = "Xóa sửa điểm", Url = "#" }
            };
            string oldImageURL = DAOScore.GetScoreById(id).ScoreImage;
            if (DAOScore.DeleteScore(id) > 0)
                System.IO.File.Delete(Server.MapPath("~") + oldImageURL);
            return RedirectToAction("Index");
        }
    }
}
