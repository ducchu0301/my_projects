using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class ProductController : SqlDataProvider
    {
        #region[Product_Insert]
        public void Product_Insert(ProductInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Price", data.Price));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@PriceSale", data.PriceSale));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@Category_Id", data.Category_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Product_Update]
        public void Product_Update(ProductInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Price", data.Price));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@PriceSale", data.PriceSale));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@Category_Id", data.Category_Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Product_Delete]
        public void Product_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Product_GetByAll]
        public DataTable Product_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Product_GetById]
        public DataTable Product_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_GetById", GetConnection()))
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
        #region[Product_GetByOption]
        public DataTable Product_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Product_GetByOption", GetConnection()))
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
