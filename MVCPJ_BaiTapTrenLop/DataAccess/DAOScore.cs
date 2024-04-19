using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOScore : DAOBase
    {
        public List<Score> GetScores()
        {
            try
            {
                List<Score> list = new List<Score>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetScores", null).Tables[0].Rows)
                {
                    Score score = new Score()
                    {
                        ScoreID = int.Parse(row["ScoreID"].ToString()),
                        SubjectID = int.Parse(row["SubjectID"].ToString()),
                        SubjectName = row["SubjectName"].ToString(),
                        ClassID = int.Parse(row["ClassID"].ToString()),
                        ClassName = row["ClassName"].ToString(),
                        ScoreImage = row["ScoreImage"].ToString()
                    };
                    list.Add(score);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateScore(Score score)
        {
            try
            {
                object[] paras = { score.ScoreID, score.SubjectID, score.ClassID, score.ScoreImage };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateScore", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertScore(Score score)
        {
            try
            {
                object[] paras = { score.SubjectID, score.ClassID, score.ScoreImage };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertScore", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteScore(int scoreID)
        {
            try
            {
                object[] paras = { scoreID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteScore", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Score GetScoreById(int scoreID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetScoreById", new object[] { scoreID }).Tables[0].Rows[0];
                Score score = new Score()
                {
                    ScoreID = int.Parse(row["ScoreID"].ToString()),
                    SubjectID = int.Parse(row["SubjectID"].ToString()),
                    SubjectName = row["SubjectName"].ToString(),
                    ClassID = int.Parse(row["ClassID"].ToString()),
                    ClassName = row["ClassName"].ToString(),
                    ScoreImage = row["ScoreImage"].ToString()
                };
                return score;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Score GetScoreByClassAndSubject(int classID, int subjectID)
        {
            try
            {
                DataTable dt = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetScoreByClassAndSubject", new object[] { subjectID, classID }).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Score score = new Score()
                    {
                        ScoreID = int.Parse(row["ScoreID"].ToString()),
                        SubjectID = int.Parse(row["SubjectID"].ToString()),
                        SubjectName = row["SubjectName"].ToString(),
                        ClassID = int.Parse(row["ClassID"].ToString()),
                        ClassName = row["ClassName"].ToString(),
                        ScoreImage = row["ScoreImage"].ToString()
                    };
                    return score;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
