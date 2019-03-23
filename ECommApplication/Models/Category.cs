using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class Category
    {
        
        public int CategoryID { get; set; }   
        public bool IsActive { get; set; } 
        //[Required(ErrorMessage = "Please Enter Category Name")]
        //[DataType(DataType.Text)]
        //[RegularExpression(@"^[0-9a-zA-Z ]+$", ErrorMessage = "Special Characters Are Not Allowed !!")]
        //[Display(Name = "Enter Category Name")] 
        public string CategoryName { get; set; }
    }
}