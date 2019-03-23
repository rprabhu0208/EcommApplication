using ECommApplication.DataLayer;
using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApplication.Controllers
{
    public class BindDataTableController : Controller
    {
        // GET: BindDataTable
        OnlineContext OC = null;
       public BindDataTableController()
        {
            OC = new OnlineContext();
        }
       
        public ActionResult BindCategory()
        { 
            List<Category> lstCategory = new List<Category>();
            lstCategory = OC.getCategories();
            return Json(new { category = lstCategory },JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindSubCategory()
        {
            List<SubCategory> lstSubCatogories = new List<SubCategory>();
            lstSubCatogories = OC.getSubCategories();
            return Json(new { subcategory = lstSubCatogories }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}