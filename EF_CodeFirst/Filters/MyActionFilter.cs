using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace EF_CodeFirst.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Number = 15;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Thuc thi dau tien khi action dc goi
            Debug.WriteLine("Action Executing");
            filterContext.Controller.ViewBag.Number = 5;
        }
    }
}