using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ECommApplication.Common
{
    public static class CommonFunctions
    {

        public static string convertObjectListToXML<T>(List<T> obj) 
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
    }
}