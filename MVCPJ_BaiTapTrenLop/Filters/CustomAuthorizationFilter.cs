using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCPJ_BaiTapTrenLop.Filters
{
    public class CustomAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User currentUser = (User)filterContext.HttpContext.Session["User"];
            if (currentUser.RoleId == 3)
                filterContext.Result = new RedirectResult("/Account/AuthorizationAdminError");
        }
    }
}