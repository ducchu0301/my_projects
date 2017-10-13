using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class ContactController : SqlDataProvider
    {
        #region[Contact_Insert]
        public void Contact_Insert(ContactInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Company", data.Company));
                cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
                cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Contact_Update]
        public void Contact_Update(ContactInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Company", data.Company));
                cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
                cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Contact_Delete]
        public void Contact_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Contact_GetByAll]
        public DataTable Contact_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Contact_GetById]
        public DataTable Contact_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_GetById", GetConnection()))
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
        #region[Contact_GetByOption]
        public DataTable Contact_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Contact_GetByOption", GetConnection()))
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
