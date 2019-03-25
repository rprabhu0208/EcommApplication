using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please Enter UserName.")]
        //[Display(Name = "Enter User Name:")] 
        public string UserName { get; set; }

         
        [Required(ErrorMessage = "Please Enter Password.")] 
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

    }
}