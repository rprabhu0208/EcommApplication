using ECommApplication.DataLayer;
using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApplication.Controllers
{
    public class BindController : Controller
    {
        // GET: BindDataTable
        OnlineContext OC = null;
       public BindController()
        {
            OC = new OnlineContext();
        }
       
        public ActionResult BindCategory(Category category)
        { 
            List<Category> lstCategory = new List<Category>();
            lstCategory = OC.getCategories(category);
            return Json(new { category = lstCategory },JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindSubCategory(SubCategory subcategory)
        {
            List<SubCategory> lstSubCatogories = new List<SubCategory>();
            lstSubCatogories = OC.getSubCategories(subcategory);
            return Json(new { subcategory = lstSubCatogories }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BindProducts(Product product)
        {
            List<Product> lstProducts = new List<Product>();
            lstProducts = OC.getProducts(product);
            return Json(new { products = lstProducts }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}