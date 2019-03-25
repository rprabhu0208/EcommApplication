﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class ProductImage
    {
        public int ImageID { get; set; }

        public int ProductID { get; set; }
        public HttpPostedFileBase productImage { get; set; }
        public bool IsActive { get; set; } 
        public int Priority { get; set; }
        public string Caption { get; set; }
        public string productImagePath { get; set; }
    }
}