using ECommApplication.DataLayer.Common;
using ECommApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ECommApplication.DataLayer
{
    public class OnlineContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SGNPEcommerce"].ToString());
        DataSet ds;

        public int Category(Category obj)
        {
            int i = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[3];
                param[0] = obj.CategoryID;
                param[1] = obj.CategoryName;
                param[2] = obj.IsActive;
                 
                i = SqlHelper.ExecuteNonQuery(con, null, "SP_InsertUpdateCategory", param); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return i;
        }
    }
}