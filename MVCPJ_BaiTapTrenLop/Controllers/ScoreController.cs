using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Filters;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    [CustomAuthenticationFilter]
    public class ScoreController : Controller
    {
        DAOClass DAOClass = new DAOClass();
        DAOSubject DAOSubject = new DAOSubject();
        DAOScore DAOScore = new DAOScore();
        // GET: Score
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Tra cứu điểm", Url = "/Score/Index" }
            };
            ViewBag.Classes = new SelectList( DAOClass.GetClasses(), "ClassID", "ClassName");
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Score score)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Home" },
                new BreadcrumbItem { Text = "Tra cứu điểm", Url = "/Score/Index" }
            };
            ViewBag.Classes = new SelectList(DAOClass.GetClasses(), "ClassID", "ClassName");
            ViewBag.Subjects = new SelectList(DAOSubject.GetSubjects(), "SubjectID", "SubjectName");
            if (ModelState.IsValid)
            {
                Score newScore = DAOScore.GetScoreByClassAndSubject(score.ClassID, score.SubjectID);
                if (newScore != null)
                    ViewBag.ScoreImage = "1";
                else
                    ViewBag.ScoreImage = "0";
                return View(newScore);
            }
            return View(score);
        }


    }
}