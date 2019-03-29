using ECommApplication.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class SubCategory
    {
        OnlineContext OC = null;

        public SubCategory()
        {
            OC = new OnlineContext();
        }
        public int? SubCategoryID { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "Please Select Sub Cateogory Status")]
        public string IsActive { get; set; }

        [Required(ErrorMessage = "Please Enter Sub Category Name")]
        public string SubCategoryName { get; set; }

        public Category category { get; set; }
        public List<Category> getCategories()
        {
            List<Category> lstCategory = new List<Category>();

            lstCategory = OC.getCategories(null);
            return lstCategory;
        }
    }
}