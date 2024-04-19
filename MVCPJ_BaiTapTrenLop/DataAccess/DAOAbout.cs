using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOAbout : DAOBase
    {
        public About GetAbout()
        {
			try
			{
				DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetAbout", null).Tables[0].Rows[0];
                About about = new About() { ID = int.Parse(row["ID"].ToString()), Title = row["Title"].ToString(), Content = row["Content"].ToString() };
                return about;
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public int UpdateAbout(About about)
        {
            object[] paras = { about.ID, about.Title, about.Content};
            try
            {
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateAbout", paras);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}