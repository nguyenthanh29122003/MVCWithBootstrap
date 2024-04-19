using EF_CodeFirst.Filters;
using EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}