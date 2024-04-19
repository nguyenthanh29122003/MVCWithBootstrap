using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirst.Models;
using EF_CodeFirst.Filters;

namespace EF_CodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [MyAuthenFilter]
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> list = db.Products.ToList();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product p)
        {
            return PartialView("MyProduct", p);
        }
    }
}