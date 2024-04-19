using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAONews : DAOBase
    {
        public List<News> GetNews()
        {
            try
            {
                List<News> list = new List<News>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetNews", null).Tables[0].Rows)
                {
                    News news = new News()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Title = row["Title"].ToString(),
                        TitleImage = row["TitleImage"].ToString(),
                        Content = row["Content"].ToString(),
                        PublishDate = DateTime.Parse(row["PublishDate"].ToString()),
                        CategoryID = int.Parse(row["CategoryID"].ToString()),
                        // Cập nhật CategoryName nếu cần
                        CategoryName = row["Name"].ToString()
                    };
                    list.Add(news);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<News> GetTop5News()
        {
            try
            {
                List<News> list = new List<News>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "GetTop5News", null).Tables[0].Rows)
                {
                    News news = new News()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Title = row["Title"].ToString(),
                        TitleImage = row["TitleImage"].ToString(),
                        Content = row["Content"].ToString(),
                        PublishDate = DateTime.Parse(row["PublishDate"].ToString()),
                        CategoryID = int.Parse(row["CategoryID"].ToString()),
                        // Cập nhật CategoryName nếu cần
                        CategoryName = row["Name"].ToString()
                    };
                    list.Add(news);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateNews(News news)
        {
            try
            {
                object[] paras = { news.ID, news.Title, news.TitleImage, news.Content, news.PublishDate, news.CategoryID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateNews", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertNews(News news)
        {
            try
            {
                object[] paras = { news.Title, news.TitleImage, news.Content, news.PublishDate, news.CategoryID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertNews", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteNews(int newsID)
        {
            try
            {
                object[] paras = { newsID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteNews", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public News GetNewsByID(int newsID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetNewsByID", new object[] { newsID }).Tables[0].Rows[0];
                News news = new News()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Title = row["Title"].ToString(),
                    TitleImage = row["TitleImage"].ToString(),
                    Content = row["Content"].ToString(),
                    PublishDate = DateTime.Parse(row["PublishDate"].ToString()),
                    CategoryID = int.Parse(row["CategoryID"].ToString()),
                    // Cập nhật CategoryName nếu cần
                    CategoryName = row["Name"].ToString()
                };
                return news;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> GetNewsByCategoryID(int categoryID)
        {
            try
            {
                List<News> list = new List<News>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetNewsByCategory", categoryID).Tables[0].Rows)
                {
                    News news = new News()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Title = row["Title"].ToString(),
                        TitleImage = row["TitleImage"].ToString(),
                        Content = row["Content"].ToString(),
                        PublishDate = DateTime.Parse(row["PublishDate"].ToString()),
                        CategoryID = int.Parse(row["CategoryID"].ToString()),
                        // Cập nhật CategoryName nếu cần
                        CategoryName = row["Name"].ToString()
                    };
                    list.Add(news);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
