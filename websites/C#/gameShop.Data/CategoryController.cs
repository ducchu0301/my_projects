using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class CategoryController : SqlDataProvider
    {
        #region[Category_Insert]
        public void Category_Insert(CategoryInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Images", data.Images));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@Parent_Id", data.Parent_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Category_Update]
        public void Category_Update(CategoryInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Images", data.Images));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@Parent_Id", data.Parent_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Category_Delete]
        public void Category_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Category_GetByAll]
        public DataTable Category_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Category_GetById]
        public DataTable Category_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_GetById", GetConnection()))
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
        #region[Category_GetByOption]
        public DataTable Category_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Category_GetByOption", GetConnection()))
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
