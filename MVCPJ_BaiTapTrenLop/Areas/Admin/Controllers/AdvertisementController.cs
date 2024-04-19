using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class AdvertisementController : Controller
    {
        private DAOAdvertisement DAOAdvertisement = new DAOAdvertisement();

        // GET: Admin/Advertisement
        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" }
            };

            var advertisements = DAOAdvertisement.GetAdvertisements();
            return View(advertisements);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Chi tiết quảng cáo", Url = "#" }
            };

            var advertisement = DAOAdvertisement.GetAdvertisementByID(id);
            return View(advertisement);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa quảng cáo", Url = "#" }
            };

            var advertisement = DAOAdvertisement.GetAdvertisementByID(id);
            return View(advertisement);
        }

        [HttpPost]
        public ActionResult Edit(Advertisement advertisement, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa quảng cáo", Url = "#" }
            };

            if (ModelState.IsValid)
            {
                string oldImageURL = advertisement.ImageURL;
                if (DAOAdvertisement.UpdateAdvertisement(advertisement) > 0)
                {
                    System.IO.File.Delete(Server.MapPath("~") + oldImageURL);
                    file.SaveAs(Server.MapPath("~") + oldImageURL);
                }
                ViewBag.Noti = "Sửa thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Noti = "Sửa không thành công!";
                return View(advertisement);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Tạo mới quảng cáo", Url = "#" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Create(Advertisement advertisement, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Tạo mới quảng cáo", Url = "#" }
            };

            if (ModelState.IsValid)
            {
                advertisement.ImageURL = "/Images/Advertisement/" + file.FileName;
                if(DAOAdvertisement.InsertAdvertisement(advertisement) > 0)
                {
                    file.SaveAs(Server.MapPath("~") + advertisement.ImageURL);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(advertisement);
            }
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Xóa quảng cáo", Url = "#" }
            };

            var advertisement = DAOAdvertisement.GetAdvertisementByID(id);
            return View(advertisement);
        }

        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý quảng cáo", Url = "/Admin/Advertisement/Index" },
                new BreadcrumbItem { Text = "Xóa quảng cáo", Url = "#" }
            };

            string oldImageURL = DAOAdvertisement.GetAdvertisementByID(id).ImageURL;
            if (DAOAdvertisement.DeleteAdvertisement(id) > 0)
                System.IO.File.Delete(Server.MapPath("~") + oldImageURL);
            return RedirectToAction("Index");
        }
    }
}
