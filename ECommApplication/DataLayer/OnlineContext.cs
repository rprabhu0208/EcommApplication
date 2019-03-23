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

        #region CategoryMaster
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

        public int DeleteCategory(int categoryId)
        {
            int i = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[1];
                param[0] = categoryId; 
                i = SqlHelper.ExecuteNonQuery(con, null, "SP_DeleteCategory", param);
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
        public Category GetCategory(int categoryId) {
            Category category = null;
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[1];
                param[0] = categoryId;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_GetCategory", param);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    category = new Category();
                    category.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"]);
                    category.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    category.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return category;
        }

        public List<Category> getCategories()
        {
            List<Category> lstCatogies = new List<Category>();
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[0]; 
                  ds = SqlHelper.ExecuteDataset(con, null, "SP_GetCategory", param);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lstCatogies.Add(new Category {
                            CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            CategoryName = Convert.ToString(dr["CategoryName"]), IsActive = Convert.ToBoolean(dr["IsActive"] )});
                    }
                        
                    //for(int i;i<ds.Tables[0].Rows.Count; i ++)
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return lstCatogies;
        }

        #endregion
    }
}