using MVCPJ_BaiTapTrenLop.DataAccess;
using MVCPJ_BaiTapTrenLop.Filters;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCPJ_BaiTapTrenLop.Controllers
{
    [CustomAuthenticationFilter]
    public class DocumentsController : Controller
    {
        // GET: Documents
        public const int pageSize = 5;
        public ActionResult Index(int pageNumber = 1)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/" },
                new BreadcrumbItem { Text = "Danh sách văn bản pháp quy", Url = "/Documents/Index" }
            };

            List<LegalDocument> documents = DAOLegalDocument.Instance.GetLegalDocuments();

            int totalRecords = documents.Count;
            documents = documents.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalRecords = totalRecords;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = pageNumber;

            return View(documents);
        }
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumbs = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Text = "Trang chủ", Url = "/" },
                new BreadcrumbItem { Text = "Danh sách văn bản pháp quy", Url = "/Documents/Index" },
                new BreadcrumbItem { Text = "Chi tiết", Url = $"#" }
            };
            return View(DAOLegalDocument.Instance.GetLegalDocumentById(id));
        }
    }
}