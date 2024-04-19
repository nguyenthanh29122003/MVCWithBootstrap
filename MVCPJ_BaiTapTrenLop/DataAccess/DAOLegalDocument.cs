using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using DataAccess;  // Thư viện chứa các phương thức truy cập dữ liệu
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOLegalDocument : DAOBase
    {
        private static DAOLegalDocument instance;
        public static DAOLegalDocument Instance { get { if (instance == null) instance = new DAOLegalDocument(); return instance; } set { instance = value; } }

        public List<LegalDocument> GetLegalDocuments()
        {
            try
            {
                List<LegalDocument> list = new List<LegalDocument>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetLegalDocuments", null).Tables[0].Rows)
                {
                    LegalDocument document = new LegalDocument()
                    {
                        DocumentID = int.Parse(row["DocumentID"].ToString()),
                        SerialNumber = row["SerialNumber"].ToString(),
                        Title = row["Title"].ToString(),
                        Content = row["Content"].ToString(),
                        Summary = row["Summary"].ToString(),
                        CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                        FilePath = row["FilePath"].ToString()
                    };
                    list.Add(document);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateLegalDocument(LegalDocument document)
        {
            try
            {
                object[] paras = { document.DocumentID, document.SerialNumber, document.Title, document.Content, document.Summary, document.FilePath };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateLegalDocument", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertLegalDocument(LegalDocument document)
        {
            try
            {
                object[] paras = { document.SerialNumber, document.Title, document.Content, document.Summary, document.FilePath };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertLegalDocument", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteLegalDocument(int documentID)
        {
            try
            {
                object[] paras = { documentID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteLegalDocument", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LegalDocument GetLegalDocumentById(int documentID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetLegalDocumentById", new object[] { documentID }).Tables[0].Rows[0];
                LegalDocument document = new LegalDocument()
                {
                    DocumentID = int.Parse(row["DocumentID"].ToString()),
                    SerialNumber = row["SerialNumber"].ToString(),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    Summary = row["Summary"].ToString(),
                    CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                    FilePath = row["FilePath"].ToString()
                };
                return document;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            //public List<Document> GetList()
            //{
            //    try
            //    {
            //        List<Document> list = new List<Document>();
            //        foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetDocument", null).Tables[0].Rows)
            //        {
            //            Document document = new Document();
            //            document.DocumentID = Convert.ToInt32(row["DocumentID"]);
            //            document.Title = row["Title"].ToString();
            //            document.Content = row["Content"].ToString();
            //            document.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
            //            document.FilePath = row["FilePath"].ToString();
            //            list.Add(document);
            //        }
            //        return list;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            //public Document GetById(int id)
            //{
            //    try
            //    {
            //        DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetDocumentById", id).Tables[0].Rows[0];
            //        Document document = new Document();
            //        document.DocumentID = Convert.ToInt32(row["DocumentID"]);
            //        document.Title = row["Title"].ToString();
            //        document.Content = row["Content"].ToString();
            //        document.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
            //        document.FilePath = row["FilePath"].ToString();
            //        return document;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
    }
}
