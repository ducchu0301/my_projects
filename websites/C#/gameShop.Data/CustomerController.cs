using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class CustomerController : SqlDataProvider
    {
        #region[Customer_Insert]
        public void Customer_Insert(CustomerInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@BirthDay", data.BirthDay));
                cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
                cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
                cmd.Parameters.Add(new SqlParameter("@User_Id", data.User_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Customer_Insert_With_Id]
        public void Customer_Insert_With_Id(CustomerInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_Insert_With_Id", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@BirthDay", data.BirthDay));
                cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
                cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
                cmd.Parameters.Add(new SqlParameter("@User_Id", data.User_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Customer_Update]
        public void Customer_Update(CustomerInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@BirthDay", data.BirthDay));
                cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
                cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
                cmd.Parameters.Add(new SqlParameter("@User_Id", data.User_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Customer_Delete]
        public void Customer_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Customer_GetByAll]
        public DataTable Customer_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Customer_GetById]
        public DataTable Customer_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_GetById", GetConnection()))
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
        #region[Customer_GetByOption]
        public DataTable Customer_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Customer_GetByOption", GetConnection()))
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
    }
}
