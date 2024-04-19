using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using EF_CodeFirst.Filters;

namespace EF_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Action filter se dc thuc thi truoc result filter
        [MyActionFilter]
        [MyResultFilter]
        public ActionResult Index()
        {
            Debug.WriteLine("Start action index."); 
            ViewBag.Number = 10;
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}