using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace ECommApplication.Common
{
    public static class CommonFunctions
    {

        public static string ConvertObjectListToXML<T>(List<T> obj) 
        { 
             string xmlObj = "";
            // Returns message that successfully uploaded  
            if (obj != null)
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<ProductImage>));
                //  product.productImages = TempData["productImages"] as List<ProductImage>;
                // xmlSer.Serialize()
                var stringwriter = new System.IO.StringWriter();
                xmlSer.Serialize(stringwriter, obj);

                 xmlObj = stringwriter.ToString();

            }
            return xmlObj;
        }


        public static List<SelectListItem> SelectListYesNo()
        {
            List<SelectListItem> lstSelectListItems = new List<SelectListItem>();

            lstSelectListItems.Add(new SelectListItem() { Text = "Yes", Value = "Yes" });
            lstSelectListItems.Add(new SelectListItem() { Text = "No", Value = "No" });

            return lstSelectListItems;
        }
    }
}