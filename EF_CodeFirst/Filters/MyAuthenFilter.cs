﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace EF_CodeFirst.Filters
{
    public class MyAuthenFilter : FilterAttribute, IAuthenticationFilter
    {
        //Thuc thi khi truy cap vao Actions
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}