using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class Category
    {

        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "Please Select Cateogory Status")]
        public string IsActive { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; }
    }
}