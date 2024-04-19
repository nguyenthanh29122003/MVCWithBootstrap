using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutApp.Models
{
    public class CustomBinderStudent : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            int id = Convert.ToInt32(controllerContext.HttpContext.Request.Form["id"]);
            string name = controllerContext.HttpContext.Request.Form["name"];
            string addLine = controllerContext.HttpContext.Request.Form["addLine"];
            string city = controllerContext.HttpContext.Request.Form["city"];

            return new Student() { Id = id, Name = name, Address = addLine + " " + city };
        }

    }
}