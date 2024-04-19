using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAONewsCategory : DAOBase
    {
        public List<NewsCategory> GetNewsCategories()
        {
            try
            {
                List<NewsCategory> list = new List<NewsCategory>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetNewsCategories", null).Tables[0].Rows)
                {
                    NewsCategory newsCategory = new NewsCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Name = row["Name"].ToString()
                    };
                    list.Add(newsCategory);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateNewsCategory(NewsCategory newsCategory)
        {
            try
            {
                object[] paras = { newsCategory.ID, newsCategory.Name };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateNewsCategory", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertNewsCategory(NewsCategory newsCategory)
        {
            try
            {
                object[] paras = { newsCategory.Name };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertNewsCategory", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteNewsCategory(int categoryID)
        {
            try
            {
                object[] paras = { categoryID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteNewsCategory", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NewsCategory GetNewsCategoryByID(int categoryID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetNewsCategoryByID", new object[] { categoryID }).Tables[0].Rows[0];
                NewsCategory newsCategory = new NewsCategory()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Name = row["Name"].ToString()
                };
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}