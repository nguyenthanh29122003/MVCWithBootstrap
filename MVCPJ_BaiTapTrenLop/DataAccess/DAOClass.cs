using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOClass : DAOBase
    {
        public List<Class> GetClasses()
        {
            try
            {
                List<Class> list = new List<Class>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetClasses", null).Tables[0].Rows)
                {
                    Class cls = new Class()
                    {
                        ClassID = int.Parse(row["ClassID"].ToString()),
                        ClassName = row["ClassName"].ToString()
                    };
                    list.Add(cls);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateClass(Class cls)
        {
            try
            {
                object[] paras = { cls.ClassID, cls.ClassName };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateClass", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertClass(Class cls)
        {
            try
            {
                object[] paras = { cls.ClassName };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertClass", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteClass(int classID)
        {
            try
            {
                object[] paras = { classID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteClass", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Class GetClassById(int classID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetClassById", new object[] { classID }).Tables[0].Rows[0];
                Class cls = new Class()
                {
                    ClassID = int.Parse(row["ClassID"].ToString()),
                    ClassName = row["ClassName"].ToString()
                };
                return cls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
