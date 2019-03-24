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
            //if (Request.IsAjaxRequest())
            //{
            //    if(Request.QueryString["CategoryId"] != null)
            //    {
            //        category = OC.GetCategory(Convert.ToInt32(Request.QueryString["CategoryId"]));
            //        return Json(new { data = category }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Category(Category CA)
        {
            if(ModelState.IsValid)
            {
                int i = OC.Category(CA);
            }
            
            return View(CA);
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

        #endregion

        #region Sub Category

        [HttpGet]
        public ActionResult SubCategory(string id)
        {
            SubCategory subCategory = null;
            //if (Request.IsAjaxRequest())
            //{
            //    if (Request.QueryString["SubCategoryId"] != null)
            //    {
            //        subCategory = OC.GetSubCategory(Convert.ToInt32(Request.QueryString["SubCategoryId"]));
            //        return Json(new { data = subCategory }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubCategory(SubCategory SC)
        {
            if (ModelState.IsValid)
            {
                int i = OC.SubCategory(SC);
                
            }
            return View(SC);
        }

        [HttpPost]
        public ActionResult DeleteSubCategory(string categoryId)
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

        #endregion

        #region Product Master

        [HttpGet]
        public ActionResult Product(string id)
        {
            Product product = null;
            if (Request.IsAjaxRequest())
            {
                //if (Request.QueryString["SubCategoryId"] != null)
                //{
                //    subCategory = OC.GetSubCategory(Convert.ToInt32(Request.QueryString["SubCategoryId"]));
                //    return Json(new { data = subCategory }, JsonRequestBehavior.AllowGet);
                //}
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Product(Product product)
        {
            if (ModelState.IsValid)
            {
                //int i = OC.SubCategory(SC);
                int i = OC.AddProduct(product);

            }
            return View(product);
        }

        #endregion 
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}