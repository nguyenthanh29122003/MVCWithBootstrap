using MVCPJ_BaiTapTrenLop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataAccess;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;

namespace MVCPJ_BaiTapTrenLop.DataAccess
{
    public class DAOUser : DAOBase
    {
        public User Login(string userName, string password)
        {
            object[] paras = { userName, password };
            try
            {
                DataTable dt = SqlDataAccess.ExecuteDataset(connectionString, "SP_Login", paras).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    User user = new User() { ID = int.Parse(row["ID"].ToString()), Username = row["Username"].ToString() , Password = "", FullName = row["FullName"].ToString(), Email = row["Email"].ToString(), PhoneNumber = row["PhoneNumber"].ToString(), DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString()), Address = row["Address"].ToString(), RoleId = int.Parse(row["RoleId"].ToString()), RoleName = row["RoleName"].ToString(), Avatar = row["Avatar"].ToString() };
                    return user;
                }return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditProfile(User user)
        {
            object[] paras = { user.ID, user.FullName, user.Avatar, user.Email, user.PhoneNumber, user.DateOfBirth, user.Address};
            try
            {
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_EditProfile", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetById(int id)
        {
            try
            {
                DataTable dt = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetById", id).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    User user = new User() { ID = int.Parse(row["ID"].ToString()), Username = row["Username"].ToString(), Password = "", FullName = row["FullName"].ToString(), Email = row["Email"].ToString(), PhoneNumber = row["PhoneNumber"].ToString(), DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString()), Address = row["Address"].ToString(), RoleId = int.Parse(row["RoleId"].ToString()), RoleName = row["RoleName"].ToString(), Avatar = row["Avatar"].ToString() };
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                List<User> list = new List<User>();
                foreach (DataRow row in SqlDataAccess.ExecuteDataset(connectionString, "sp_GetAllUsers", null).Tables[0].Rows)
                {
                    User user = new User()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Username = row["Username"].ToString(),
                        Password = row["Password"].ToString(),
                        FullName = row["FullName"].ToString(),
                        Avatar = row["Avatar"].ToString(),
                        Email = row["Email"].ToString(),
                        PhoneNumber = row["PhoneNumber"].ToString(),
                        DateOfBirth = row["DateOfBirth"] != DBNull.Value ? (DateTime?)row["DateOfBirth"] : null,
                        Address = row["Address"].ToString(),
                        RoleId = int.Parse(row["RoleId"].ToString()),
                        RoleName = row["RoleName"].ToString()
                    };
                    list.Add(user);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateUser(User user)
        {
            try
            {
                object[] paras = { user.ID, user.Username, user.Password, user.FullName, user.Avatar, user.Email, user.PhoneNumber, user.DateOfBirth, user.Address, user.RoleId };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_UpdateUser", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertUser(User user)
        {
            try
            {
                object[] paras = { user.Username, user.Password, user.FullName, user.Avatar, user.Email, user.PhoneNumber, user.DateOfBirth, user.Address, user.RoleId };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_InsertUser", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteUser(int userId)
        {
            try
            {
                object[] paras = { userId };
                return SqlDataAccess.ExecuteNonQuery(connectionString, "SP_DeleteUser", paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                DataRow row = SqlDataAccess.ExecuteDataset(connectionString, "SP_GetUserById", new object[] { userId }).Tables[0].Rows[0];
                User user = new User()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Avatar = row["Avatar"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    DateOfBirth = row["DateOfBirth"] != DBNull.Value ? (DateTime?)row["DateOfBirth"] : null,
                    Address = row["Address"].ToString(),
                    RoleId = int.Parse(row["RoleId"].ToString()),
                    RoleName = row["RoleName"].ToString()
                };
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}