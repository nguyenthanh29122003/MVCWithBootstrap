using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter]
    public class UserController : Controller
    {
        private DAOUser daoUser = new DAOUser();
        private const int PageSize = 5; // Số lượng bản ghi trên một trang

        // GET: Admin/User
        public ActionResult Index(int page = 1)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" }
            };

            List<User> users = daoUser.GetUsers();

            // Phân trang
            int totalRecords = users.Count;
            users = users.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.TotalRecords = totalRecords;
            ViewBag.PageSize = PageSize;
            ViewBag.CurrentPage = page;

            return View(users);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Chi tiết người dùng", Url = "/Admin/User/Details" }
            };
            User user = daoUser.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Thêm mới người dùng", Url = "/Admin/User/Details" }
            };

            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Manager" },
                new SelectListItem { Value = "3", Text = "User" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Thêm mới người dùng", Url = "/Admin/User/Create" }
            };

            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Manager" },
                new SelectListItem { Value = "3", Text = "User" }
            };
            if (ModelState.IsValid)
            {
                if (file == null)
                    return View(user);
                else
                {
                    string imgName = file.FileName;
                    string imgPath = "/Images/User/" + imgName;
                    user.Avatar = imgPath;
                    if (daoUser.InsertUser(user) > 0)
                    {
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa người dùng", Url = $"/Admin/User/Edit/{id}" }
            };

            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Manager" },
                new SelectListItem { Value = "3", Text = "User" }
            };
            User user = daoUser.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa người dùng", Url = $"/Admin/User/Edit/{user.ID}" }
            };

            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "Manager" },
                new SelectListItem { Value = "3", Text = "User" }
            };

            if (ModelState.IsValid)
            {
                if (file == null)
                    daoUser.UpdateUser(user);
                else
                {
                    string imgPath = user.Avatar;
                    if (daoUser.UpdateUser(user) > 0)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + imgPath);
                        file.SaveAs(Server.MapPath("~") + imgPath);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Xóa người dùng", Url = $"/Admin/User/Delete{id}" }
            };
            var user = daoUser.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý người dùng", Url = "/Admin/User/Index" },
                new BreadcrumbItem { Text = "Xóa người dùng", Url = $"/Admin/User/Delete{id}" }
            };
            daoUser.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
