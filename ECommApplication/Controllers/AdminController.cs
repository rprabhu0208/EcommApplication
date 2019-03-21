using ECommApplication.DataLayer;
using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApplication.Controllers
{
    public class AdminController : Controller
    {
        OnlineContext OC = null;
        
        public AdminController()
        {
            OC = new OnlineContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region category

        [HttpGet]
        public ActionResult Category(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Category(Category CA)
        {
            int i = OC.Category(CA);
            return View();
        }

        #endregion
         
    }
}