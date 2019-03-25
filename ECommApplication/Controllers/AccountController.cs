using ECommApplication.DataLayer;
using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApplication.Controllers
{
    public class AccountController : Controller
    {
        OnlineContext OC = null;

        public AccountController()
        {
            OC = new OnlineContext();
        }
        // GET: Account
        [HttpGet]
        public ActionResult AdminLogin()
        {
            Session["AdminUserName"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                if (OC.ValidateAdmin(login))
                {
                    Session["AdminUserName"] = login.UserName;
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}