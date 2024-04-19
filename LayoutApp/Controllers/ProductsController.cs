using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayoutApp.Models;

namespace LayoutApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){Id = 101, Name = "Iphone", Price = 1000},
                new Product(){Id = 102, Name = "Samsung", Price = 2000},
                new Product(){Id = 103, Name = "Xiaomu", Price = 5000},
            };
            //ViewBag.Products = products;    
            return View(products);
        }
        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){Id = 101, Name = "Iphone", Price = 1000},
                new Product(){Id = 102, Name = "Samsung", Price = 2000},
                new Product(){Id = 103, Name = "Xiaomu", Price = 5000},
            };
            Product matchingProduct = null;
            foreach (Product item in products)
            {
                if(item.Id == id)
                {
                    matchingProduct = item;
                }   
            }
            //ViewBag.MatchingProduct = matchingProduct;
            //Strongly Typed View
            return View(matchingProduct);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Name")]Product pro)
        {
            return View(pro);
        }
        //Tạo Map Route tại Controller
        //{id:int?} tham khảo thêm tại devblogs.microsoft.com/dotnet/attribute-routing-in-asp-net-mvc-5/#route-constraints
        [Route("Products/Detail/{id:int?}")]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                ViewBag.ProName = "Product id was not found.";
            }
            else
            {
                var Products = new[]
                {
                    new {id = 1, name = "Iphone", price = 1000},
                    new {id = 2, name = "Samsung", price = 2000},
                    new {id = 3, name = "Xiaomi", price = 5000},
                };
                string proName = "";
                foreach (var item in Products)
                {
                    if (item.id == id)
                    {
                        proName = item.name;
                    }
                }

                ViewBag.ProName = proName;
            }
            return View();
        }

        //Tạo Map Route tại Controller
        [Route("Products/GetProductId/{name}")]
        public ActionResult GetProductId(string name)
        {
            if (name == null)
            {
                ViewBag.ProId = "Product name was not found.";
            }
            else
            {
                var Products = new[]
                {
                    new {id = 1, name = "Iphone", price = 1000},
                    new {id = 2, name = "Samsung", price = 2000},
                    new {id = 3, name = "Xiaomi", price = 5000},
                };
                int proId = 0;
                foreach (var item in Products)
                {
                    if (item.name == name)
                    {
                        proId = item.id;
                    }
                }

                ViewBag.ProId = proId;
            }
            return View();
        }
    }
}