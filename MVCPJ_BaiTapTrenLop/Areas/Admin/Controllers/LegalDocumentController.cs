using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using MVCPJ_BaiTapTrenLop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Drawing;
using System.Xml.Linq;

namespace MVCPJ_BaiTapTrenLop.Areas.Admin.Controllers
{
    [CustomAuthorizationFilter]
    [CustomAuthenticationFilter]
    public class LegalDocumentController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" }
            };
            return View(DAOLegalDocument.Instance.GetLegalDocuments());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Chi tiết văn bản pháp quy", Url = "#" }
            };
            return View(DAOLegalDocument.Instance.GetLegalDocumentById(id));
        }

        public ActionResult Create()
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Tạo mới văn bản pháp quy", Url = "#" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(LegalDocument legalDocument, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Tạo mới văn bản pháp quy", Url = "#" }
            };
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string filePath = "/LegalDocuments/" + fileName;
                        legalDocument.FilePath = filePath;  // Lưu đường dẫn vào cơ sở dữ liệu
                        if (DAOLegalDocument.Instance.InsertLegalDocument(legalDocument) > 0)
                            file.SaveAs(Server.MapPath("~" + filePath));
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi tải file lên: " + ex.Message);
                }
            }
            return View(legalDocument);
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa văn bản pháp quy", Url = "#" }
            };
            return View(DAOLegalDocument.Instance.GetLegalDocumentById(id));
        }

        [HttpPost]
        public ActionResult Edit(LegalDocument legalDocument, HttpPostedFileBase file)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Chỉnh sửa văn bản pháp quy", Url = "#" }
            };
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        if (DAOLegalDocument.Instance.UpdateLegalDocument(legalDocument) > 0)
                        {
                            System.IO.File.Delete(Server.MapPath("~" + legalDocument.FilePath));
                            file.SaveAs(Server.MapPath("~" + legalDocument.FilePath));
                            return RedirectToAction("Index");
                        }
                        else
                            return View(legalDocument);
                    }
                    DAOLegalDocument.Instance.UpdateLegalDocument(legalDocument);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi tải file lên: " + ex.Message);
                }
            }
            return View(legalDocument);
        }
        [CustomAdminAuthorizationFilter]
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Xóa văn bản pháp quy", Url = "#" }
            };
            return View(DAOLegalDocument.Instance.GetLegalDocumentById(id));
        }
        [CustomAdminAuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang quản lý", Url = "/Admin/Home" },
                new BreadcrumbItem { Text = "Quản lý văn bản pháp quy", Url = "/Admin/LegalDocument/Index" },
                new BreadcrumbItem { Text = "Xóa văn bản pháp quy", Url = "#" }
            };
            DAOLegalDocument.Instance.DeleteLegalDocument(id);
            return RedirectToAction("Index");
        }
    }
}
