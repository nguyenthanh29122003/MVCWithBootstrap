using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Filters
{
    public class CustomAdminAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User currentUser = (User)filterContext.HttpContext.Session["User"];
            if (currentUser.RoleId != 1)
                filterContext.Result = new RedirectResult("/Account/AuthorizationAdminError");
        }
    }
}