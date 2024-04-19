using EF_CodeFirst.Models;
using EF_CodeFirst.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        CompanyDBContext db = new CompanyDBContext();
        public ActionResult Index(string search = "", string SortColumn = "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            //Search
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;

            //Sort
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductId")
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(row => row.ProductID).ToList();
                else
                    products = products.OrderByDescending(row => row.ProductID).ToList();
            else if (SortColumn == "ProductName")
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(row => row.ProductName).ToList();
                else
                    products = products.OrderByDescending(row => row.ProductName).ToList();
            else if (SortColumn == "Price")
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(row => row.Price).ToList();
                else
                    products = products.OrderByDescending(row => row.Price).ToList();

            //Paging
            int noOfRecordPerPage = 5;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerPage)));
            int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = noOfPages;
            products = products.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();

            return View(products);
        }
        public ActionResult Details(int id)
        {
            List<Product> products = db.Products.Where(row => row.ProductID.Equals(id)).ToList();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products[0]);
        }
        public ActionResult Create()
        {
            List<Category> categories = db.Categories.ToList();
            List<Brand> brands = db.Brands.ToList();
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Create");
        }
        public ActionResult Edit(int id)
        {
            Product p = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            List<Category> categories = db.Categories.ToList();
            List<Brand> brands = db.Brands.ToList();
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            Product p = db.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();
            //Update
            p.ProductName = pro.ProductName;
            p.Price = pro.Price;
            p.DateOfPurchase = pro.DateOfPurchase;
            p.AvailabilityStatus = pro.AvailabilityStatus;
            p.CategoryID = pro.CategoryID;
            p.BrandID = pro.BrandID;
            p.Active = pro.Active;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}