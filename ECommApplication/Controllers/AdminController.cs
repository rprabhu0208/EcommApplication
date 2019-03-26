using ECommApplication.CustomFilters;
using ECommApplication.DataLayer;
using ECommApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace ECommApplication.Controllers
{
    [AuthAttribute]
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
            if (ModelState.IsValid)
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
            ModelState.Remove("subCategory.category.CategoryName");
            ModelState.Remove("subCategory.SubCategoryName");
            ModelState.Remove("subCategory.CategoryID");
            if (ModelState.IsValid)
            {
                if (Session["productImages"] != null)
                {
                    product.productImages = Session["productImages"] as List<ProductImage>;
                }

                //int i = OC.SubCategory(SC);
                int i = OC.AddProduct(product);

            }
            return View(product);
        }

        #endregion 
        public ActionResult UploadImage(ProductImage prodImage)
        {
            List<ProductImage> productImages = null;
            if (TempData["productImages"] != null)
                productImages = TempData["productImages"] as List<ProductImage>;
            else
                productImages = new List<ProductImage>();

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        // prodImage.productImage = file;
                        // Get the complete folder path and store the file inside it.  
                        //fname = Path.Combine(Server.MapPath("~/TempFiles/"), fname);
                        // file.SaveAs(fname);
                        prodImage.productImagePath = "/TempFiles/" + fname;
                    }

                    productImages.Add(prodImage);
                    TempData["productImages"] = productImages;

                    return Json(new { productImages = productImages.ToList() }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

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