using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOSubject : DAOBase
    {
        public List<Subject> GetSubjects()
        {
            try
            {
                List<Subject> list = new List<Subject>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetSubjects", null).Tables[0].Rows)
                {
                    Subject subject = new Subject()
                    {
                        SubjectID = int.Parse(row["SubjectID"].ToString()),
                        SubjectName = row["SubjectName"].ToString(),
                        Description = row["Description"].ToString(),
                        Price = decimal.Parse(row["Price"].ToString())
                    };
                    list.Add(subject);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateSubject(Subject subject)
        {
            try
            {
                object[] paras = { subject.SubjectID, subject.SubjectName, subject.Description, subject.Price };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateSubject", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertSubject(Subject subject)
        {
            try
            {
                object[] paras = { subject.SubjectName, subject.Description, subject.Price };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertSubject", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteSubject(int subjectID)
        {
            try
            {
                object[] paras = { subjectID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteSubject", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Subject GetSubjectById(int subjectID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetSubjectById", new object[] { subjectID }).Tables[0].Rows[0];
                Subject subject = new Subject()
                {
                    SubjectID = int.Parse(row["SubjectID"].ToString()),
                    SubjectName = row["SubjectName"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = decimal.Parse(row["Price"].ToString())
                };
                return subject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
