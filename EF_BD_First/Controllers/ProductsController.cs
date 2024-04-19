using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_BD_First.Models;

namespace EF_BD_First.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search="", string SortColumn = "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            //List<Product> products = db.Products.ToList();
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
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count)/ Convert.ToDouble(noOfRecordPerPage)));
            int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = noOfPages;
            products = products.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();

            return View(products);
        }
        //public ActionResult Index(int id = 0)
        //{
        //    EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
        //    //List<Product> products = db.Products.ToList();
        //    Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    ViewBag.DeleteId = id;
        //    return View();
        //}
        public ActionResult Details(int id)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            List<Product> products = db.Products.Where(row => row.ProductID.Equals(id)).ToList();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products[0]);
        }
        //public ActionResult Create(int id, string name, Nullable<decimal> price, Nullable<DateTime> dateOfPurchase, string availabilityStatus, int categoryId, int brandId, Nullable<bool> active)
        //{
        //    EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
        //    Product newProduct = new Product() { ProductID = id, ProductName = name, Price = price, DateOfPurchase = dateOfPurchase, AvailabilityStatus = availabilityStatus, CategoryID = categoryId, BrandID = brandId, Active = active};
        //    db.Products.Add(newProduct);
        //    return View(newProduct);
        //}
        public ActionResult Create()
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            List<Category> categories = db.Categories.ToList();
            List<Brand> brands = db.Brands.ToList();
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            db.Products.Add(p); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
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
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
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
        //public ActionResult Delete(int id = 0)
        //{
        //    EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
        //    Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id = 0)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            EFFirstDatabaseEntities db = new EFFirstDatabaseEntities();
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}