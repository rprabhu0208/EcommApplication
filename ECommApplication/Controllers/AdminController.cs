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
            Category category = null;
            if (Request.IsAjaxRequest())
            {
                if(Request.QueryString["CategoryId"] != null)
                {
                    category = OC.GetCategory(Convert.ToInt32(Request.QueryString["CategoryId"]));
                    return Json(new { data = category }, JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Category(Category CA)
        {
            int i = OC.Category(CA);
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory(string categoryId)
        {
            
            if (Request.IsAjaxRequest())
            {
                if (Request.QueryString["CategoryId"] != null)
                {
                    int i = OC.DeleteCategory(Convert.ToInt32(Request.QueryString["CategoryId"]));
                    return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }



        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        #endregion
         
    }
}