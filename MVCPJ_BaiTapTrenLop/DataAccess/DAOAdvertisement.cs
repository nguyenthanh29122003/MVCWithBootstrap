using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOAdvertisement : DAOBase
    {
        public List<Advertisement> GetAdvertisements()
        {
            try
            {
                List<Advertisement> list = new List<Advertisement>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetAdvertisements", null).Tables[0].Rows)
                {
                    Advertisement advertisement = new Advertisement()
                    {
                        AdvertisementID = int.Parse(row["AdvertisementID"].ToString()),
                        Title = row["Title"].ToString(),
                        Description = row["Description"].ToString(),
                        ImageURL = row["ImageURL"].ToString(),
                        URL = row["URL"].ToString()
                    };
                    list.Add(advertisement);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAdvertisement(Advertisement advertisement)
        {
            try
            {
                object[] paras = { advertisement.AdvertisementID, advertisement.Title, advertisement.Description, advertisement.ImageURL, advertisement.URL };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateAdvertisement", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertAdvertisement(Advertisement advertisement)
        {
            try
            {
                object[] paras = { advertisement.Title, advertisement.Description, advertisement.ImageURL, advertisement.URL };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertAdvertisement", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteAdvertisement(int advertisementID)
        {
            try
            {
                object[] paras = { advertisementID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteAdvertisement", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Advertisement GetAdvertisementByID(int advertisementID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetAdvertisementByID", new object[] { advertisementID }).Tables[0].Rows[0];
                Advertisement advertisement = new Advertisement()
                {
                    AdvertisementID = int.Parse(row["AdvertisementID"].ToString()),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    ImageURL = row["ImageURL"].ToString(),
                    URL = row["URL"].ToString()
                };
                return advertisement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
