﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}