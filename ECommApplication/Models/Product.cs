using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommApplication.Models
{
    public class Product
    {
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; } 
         
        //[Required(ErrorMessage = "Please enter Product name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }
 
        public bool IsActive { get; set; }
        public bool DisplayAtHomePage { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        //public string OrderBy { get; set; }
        //public DateTime OrderDate { get; set; }

        public int? ProductId { get; set; }

        public int SupplierId { get; set; } 

        public string ProductDetailId { get; set; } 
      
        //[Required(ErrorMessage = "Please enter Product Decription")]
        [DataType(DataType.Text)]
        public string ProductDescription { get; set; } 

        //[Required(ErrorMessage = "Please enter Product Size")]
        [DataType(DataType.Text)]
        public string ProductSize { get; set; } 

        //[Required(ErrorMessage = "Please enter Product Weight")]
        [DataType(DataType.Text)]
        public string ProductWeight { get; set; } 
       
        //[Required(ErrorMessage = "Please enter Product price")]
        //[DataType(DataType.Text)]
         
        public HttpPostedFileBase Thumbnail { get; set; }

        [DataType(DataType.Text)]
        public string Unit { get; set; }

        public string FileName { get; set; } 
        //[Required(ErrorMessage = "Please enter Product Quanty")]
        //[DataType(DataType.Text)]
        public int Quantity { get; set; } 

        public string shortDescription { get; set; }

        public HttpPostedFileBase ProductImage { get; set; }
        public string ImageOrder { get; set; }

        public decimal BasePrice { get; set; }
        public decimal GST { get; set; }
        public decimal ShippingCharges { get; set; } 
        public decimal ServiceTax { get; set; }
        public decimal FinalPrice { get; set; }

        public List<ProductImage> productImages { get; set; }

    }

    
}