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
    public class WorkingScheduleController : Controller
    {
        private DAOWorkingSchedule daoWorkingSchedule = new DAOWorkingSchedule();
        private const int PageSize = 5; // Số lượng bản ghi trên một trang

        // GET: Admin/WorkingSchedule
        public ActionResult Index(int page = 1)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" }
            };

            List<WorkingSchedule> schedules = daoWorkingSchedule.GetAllWorkingSchedules();

            // Phân trang
            int totalRecords = schedules.Count;
            schedules = schedules.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.TotalRecords = totalRecords;
            ViewBag.PageSize = PageSize;
            ViewBag.CurrentPage = page;

            return View(schedules);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Chi tiết lịch công tác", Url = "/Admin/WorkingSchedule/Details" }
            };
            WorkingSchedule schedule = daoWorkingSchedule.GetWorkingScheduleById(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Thêm mới lịch công tác", Url = "/Admin/WorkingSchedule/Create" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkingSchedule schedule)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Thêm mới lịch công tác", Url = "/Admin/WorkingSchedule/Create" }
            };
            if (ModelState.IsValid)
            {
                daoWorkingSchedule.InsertWorkingSchedule(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa lịch công tác", Url = $"/Admin/WorkingSchedule/Edit/{id}" }
            };
            WorkingSchedule schedule = daoWorkingSchedule.GetWorkingScheduleById(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        [HttpPost]
        public ActionResult Edit(WorkingSchedule schedule)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa lịch công tác", Url = $"/Admin/WorkingSchedule/Edit/{schedule.ScheduleID}" }
            };
            if (ModelState.IsValid)
            {
                daoWorkingSchedule.UpdateWorkingSchedule(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Xóa lịch công tác", Url = $"/Admin/WorkingSchedule/Delete/{id}" }
            };
            var schedule = daoWorkingSchedule.GetWorkingScheduleById(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý lịch công tác", Url = "/Admin/WorkingSchedule/Index" },
                new BreadcrumbItem { Text = "Xóa lịch công tác", Url = $"/Admin/WorkingSchedule/Delete/{id}" }
            };
            daoWorkingSchedule.DeleteWorkingSchedule(id);
            return RedirectToAction("Index");
        }

    }
}
