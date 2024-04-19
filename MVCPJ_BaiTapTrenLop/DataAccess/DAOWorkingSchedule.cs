using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;  // Thư viện chứa các phương thức truy cập dữ liệu
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOWorkingSchedule : DAOBase
    {
        private static DAOWorkingSchedule instance;
        public static DAOWorkingSchedule Instance { get { if (instance == null) instance = new DAOWorkingSchedule(); return instance; } set { instance = value; } }

        public List<WorkingSchedule> GetAllWorkingSchedules()
        {
            try
            {
                List<WorkingSchedule> list = new List<WorkingSchedule>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "GetAllWorkingSchedules", null).Tables[0].Rows)
                {
                    WorkingSchedule schedule = new WorkingSchedule()
                    {
                        ScheduleID = int.Parse(row["ScheduleID"].ToString()),
                        Title = row["Title"].ToString(),
                        Content = row["Content"].ToString(),
                        CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                        Location = row["Location"].ToString(),
                        Participants = row["Participants"].ToString(),
                        Note = row["Note"].ToString()
                    };
                    list.Add(schedule);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateWorkingSchedule(WorkingSchedule schedule)
        {
            try
            {
                object[] paras = { schedule.ScheduleID, schedule.Title, schedule.Content, schedule.CreatedDate, schedule.Location, schedule.Participants, schedule.Note };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "UpdateWorkingSchedule", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertWorkingSchedule(WorkingSchedule schedule)
        {
            try
            {
                object[] paras = { schedule.Title, schedule.Content, schedule.CreatedDate, schedule.Location, schedule.Participants, schedule.Note };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "InsertWorkingSchedule", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteWorkingSchedule(int scheduleID)
        {
            try
            {
                object[] paras = { scheduleID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "DeleteWorkingSchedule", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WorkingSchedule GetWorkingScheduleById(int scheduleID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "GetWorkingScheduleById", new object[] { scheduleID }).Tables[0].Rows[0];
                WorkingSchedule schedule = new WorkingSchedule()
                {
                    ScheduleID = int.Parse(row["ScheduleID"].ToString()),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                    Location = row["Location"].ToString(),
                    Participants = row["Participants"].ToString(),
                    Note = row["Note"].ToString()
                };
                return schedule;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
