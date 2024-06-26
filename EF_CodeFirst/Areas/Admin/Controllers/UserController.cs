﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirst.Filters;
using EF_CodeFirst.Identity;

namespace EF_CodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext appDbContext = new AppDbContext();
            List<AppUser> users = appDbContext.Users.ToList();
            return View(users);
        }
    }
}