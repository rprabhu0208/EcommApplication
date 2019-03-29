using ECommApplication.Common;
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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommApplication"].ToString());
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
        public Category GetCategory(int categoryId)
        {
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
                    category.IsActive = Convert.ToString(ds.Tables[0].Rows[0]["IsActive"]);
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

        public List<Category> getCategories(Category category)
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
                Object[] param = new Object[1];
                param[0] = category?.CategoryID > 0 ? category.CategoryID : null;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_GetCategory", param);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstCatogies.Add(new Category
                        {
                            CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            CategoryName = Convert.ToString(dr["CategoryName"]),
                            IsActive = Convert.ToString(dr["IsActive"])
                        });
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

        #region SubCategory Master
        public int SubCategory(SubCategory obj)
        {
            int i = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[4];
                param[0] = obj.CategoryID;
                param[1] = obj.SubCategoryID;
                param[2] = obj.SubCategoryName;
                param[3] = obj.IsActive;

                i = SqlHelper.ExecuteNonQuery(con, null, "SP_InsertUpdateSubCategory", param);
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

        public int DeleteSubCategory(int categoryId)
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
        public SubCategory GetSubCategory(int subCategoryId)
        {
            SubCategory subCategory = null;
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[1];
                param[0] = subCategoryId;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_GetSubCategory", param);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    subCategory = new SubCategory();
                    subCategory.SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategoryID"]);
                    subCategory.SubCategoryName = Convert.ToString(ds.Tables[0].Rows[0]["SubCategoryName"]);
                    subCategory.IsActive = Convert.ToString(ds.Tables[0].Rows[0]["IsActive"]);
                    subCategory.category = new Category()
                    {
                        CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"]),
                        CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]),
                    };
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
            return subCategory;
        }

        public List<SubCategory> getSubCategories(SubCategory subcategory)
        {
            List<SubCategory> lstSubCatogories = new List<SubCategory>();
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[2];
                param[0] = subcategory.SubCategoryID > 0 ? subcategory.SubCategoryID : null;
                param[1] = subcategory.CategoryID > 0 ? subcategory.CategoryID : null;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_GetSubCategory", param);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstSubCatogories.Add(new SubCategory
                        {
                            //   CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]),
                            SubCategoryName = Convert.ToString(dr["SubCategoryName"]),
                            IsActive = Convert.ToString(dr["IsActive"]),
                            category = new Category()
                            {
                                CategoryID = Convert.ToInt32(dr["CategoryID"]),
                                CategoryName = Convert.ToString(dr["CategoryName"]),
                            }

                        });
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
            return lstSubCatogories;
        }
        #endregion

        #region Product Master
        public int AddProduct(Product prd)
        {

            int i = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string prdXML = "";
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                // Returns message that successfully uploaded  
                if (prd.productImages != null && prd.productImages.Count > 0)
                {
                    prdXML = CommonFunctions.ConvertObjectListToXML<ProductImage>(prd.productImages);
                }
                Object[] param = new Object[14];
                param[0] = prd.subCategory.SubCategoryID;
                param[1] = prd.ProductId;
                param[2] = prd.ProductName;
                param[3] = prd.IsActive;
                param[4] = prd.DisplayAtHomePage;
                param[5] = prd.ProductDescription;
                param[6] = prd.ProductQty;
                param[7] = prd.ProductWeight;
                param[8] = prd.BasePrice;
                param[9] = prd.GST;
                param[10] = prd.ShippingCharges;
                param[11] = prd.ServiceTax;
                param[12] = prd.FinalPrice;
                param[13] = prdXML;
                i = SqlHelper.ExecuteNonQuery(con, null, "SP_InsertUpdateProduct", param);
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

        public List<Product> getProducts(Product product)
        {
            List<Product> lstProducts = new List<Product>();
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[1];
                param[0] = product.ProductId > 0 ? product.ProductId : null;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_GetProducts", param);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstProducts.Add(new Product
                        {
                            //   CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            //CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            //SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]),
                            ProductId = Convert.ToInt32(dr["ProductID"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            ProductDescription = Convert.ToString(dr["ProductDescription"]),
                            ProductQty = Convert.ToInt32(dr["ProductQty"]),
                            ProductWeight = Convert.ToString(dr["ProductWeight"]),
                            BasePrice = Convert.ToDecimal(dr["BasePrice"]),
                            ShippingCharges = Convert.ToDecimal(dr["ShippingCharges"]),
                            GST = Convert.ToDecimal(dr["GST"]),
                            ServiceTax = Convert.ToDecimal(dr["ServiceTax"]),
                            FinalPrice = Convert.ToDecimal(dr["FinalPrice"]),
                            DisplayAtHomePage = Convert.ToString(dr["DisplayAtHomePage"]),
                            IsActive = Convert.ToString(dr["IsActive"]),
                            subCategory = new SubCategory()
                            {
                                SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]),
                                SubCategoryName = Convert.ToString(dr["SubCategoryName"]),
                                category = new Category()
                                {
                                    CategoryID = Convert.ToInt32(dr["CategoryID"]),
                                    CategoryName = Convert.ToString(dr["CategoryName"])
                                }
                            }
                        });
                    }

                    if (product.ProductId > 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            lstProducts[0].productImages = new List<ProductImage>();
                            int i = 1;
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstProducts[0].productImages.Add(
                                    new ProductImage()
                                    {
                                        ProductImageID = i++, //Convert.ToInt32(dr["ProductImageID"]),
                                        Priority = Convert.ToInt32(dr["Priority"]),
                                        IsActive = Convert.ToString(dr["IsActive"]),
                                        Caption = Convert.ToString(dr["Caption"]),
                                        ProductImagePath = Convert.ToString(dr["ImagePath"]),
                                        DisplayAtHomePage = Convert.ToString(dr["DisplayAtHomePage"]),
                                        ProductID = (int)product.ProductId
                                    });
                            }
                        }
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
            return lstProducts;
        }
        #endregion


        #region AdminLogin
        public bool ValidateAdmin(UserLogin user)
        {
            bool isValid = false;
            DataSet ds = null;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                // string password = FormsAuthentication.HashPasswordForStoringInConfigFile(acc.UserPassword.Trim(), "md5");
                Object[] param = new Object[2];
                param[0] = user.UserName;
                param[1] = user.UserPassword;
                ds = SqlHelper.ExecuteDataset(con, null, "SP_ValidateAdmin", param);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    isValid = true;
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
            return isValid;
        }
        #endregion
    }
}