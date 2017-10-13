using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class UserController : SqlDataProvider
    {
        #region[User_Insert]
        public void User_Insert(UserInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                cmd.Parameters.Add(new SqlParameter("@Rule", data.Rule));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[User_Update]
        public void User_Update(UserInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                cmd.Parameters.Add(new SqlParameter("@Rule", data.Rule));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[User_Delete]
        public void User_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[User_GetByAll]
        public DataTable User_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[User_GetById]
        public DataTable User_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_GetById", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[User_GetByOption]
        public DataTable User_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_GetByOption", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Where", Where));
                cmd.Parameters.Add(new SqlParameter("@Order", Order));
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[User_CheckLogin]
        public int User_CheckLogin(string Username, string Password)
        {
            using (SqlCommand cmd = new SqlCommand("sp_User_CheckLogin", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", Username));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    if (dt.Rows[0]["Status"].ToString().Equals("0"))
                    {
                        return 0;
                    }
                    else return int.Parse(dt.Rows[0]["Rule"].ToString());
                }
                else
                {
                    return -1;
                }
            }
        }
        #endregion
    }
}
