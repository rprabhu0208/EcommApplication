using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }

        public int ProductID { get; set; }
        public HttpPostedFileBase productImage { get; set; }
        public string IsActive { get; set; }
        public int Priority { get; set; }
        public string Caption { get; set; }
        public string ProductImagePath { get; set; }

        public string DisplayAtHomePage { get; set; }
    }
}