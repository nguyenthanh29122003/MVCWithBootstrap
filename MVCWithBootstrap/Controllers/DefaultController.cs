using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithBootstrap.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Phone = "DF-123-123-123";
            return View();
        }

        public ActionResult GetEmpDetails()
        {
            ViewBag.Id = 101;
            ViewBag.Name = "Thanh";
            ViewBag.Salary = 1000;
            ViewBag.Gender = 'M';
            ViewBag.Year = 2018;
            ViewBag.Positions = new List<string> { "Security", "Technician", "Manager"};
            return View();
        }
    }
}