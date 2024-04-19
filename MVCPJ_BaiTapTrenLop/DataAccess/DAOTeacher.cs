using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using MVCPJ_BaiTapTrenLop.Models;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOTeacher : DAOBase
    {
        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> list = new List<Teacher>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "SP_GetTeachers", null).Tables[0].Rows)
                {
                    Teacher teacher = new Teacher()
                    {
                        TeacherID = int.Parse(row["TeacherID"].ToString()),
                        FullName = row["FullName"].ToString(),
                        Email = row["Email"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString()),
                        //DateOfBirth = row["DateOfBirth"] != DBNull.Value ? (DateTime?)row["DateOfBirth"] : null,
                        Gender = row["Gender"].ToString(),
                        ImagePath = row["ImagePath"].ToString(),
                        Department = row["Department"].ToString()
                    };
                    list.Add(teacher);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateTeacher(Teacher teacher)
        {
            try
            {
                object[] paras = { teacher.TeacherID, teacher.FullName, teacher.Email, teacher.PhoneNumber, teacher.Address, teacher.DateOfBirth, teacher.Gender, teacher.ImagePath, teacher.Department };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateTeacher", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertTeacher(Teacher teacher)
        {
            try
            {
                object[] paras = { teacher.FullName, teacher.Email, teacher.PhoneNumber, teacher.Address, teacher.DateOfBirth, teacher.Gender, teacher.ImagePath, teacher.Department };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertTeacher", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteTeacher(int teacherID)
        {
            try
            {
                object[] paras = { teacherID };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteTeacher", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Teacher GetTeacherById(int teacherID)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetTeacherById", new object[] { teacherID }).Tables[0].Rows[0];
                Teacher teacher = new Teacher()
                {
                    TeacherID = int.Parse(row["TeacherID"].ToString()),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Address = row["Address"].ToString(),
                    DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString()),
                    //DateOfBirth = row["DateOfBirth"] != DBNull.Value ? (DateTime?)row["DateOfBirth"] : null,
                    Gender = row["Gender"].ToString(),
                    ImagePath = row["ImagePath"].ToString(),
                    Department = row["Department"].ToString()
                };
                return teacher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
