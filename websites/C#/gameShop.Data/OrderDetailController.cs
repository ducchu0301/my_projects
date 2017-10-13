using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class OrderDetailController : SqlDataProvider
    {
        #region[OrderDetail_Insert]
        public void OrderDetail_Insert(OrderDetailInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Order_Id", data.Order_Id));
                cmd.Parameters.Add(new SqlParameter("@Product_Id", data.Product_Id));
                cmd.Parameters.Add(new SqlParameter("@Quantity", data.Quantity));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[OrderDetail_Update]
        public void OrderDetail_Update(OrderDetailInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Order_Id", data.Order_Id));
                cmd.Parameters.Add(new SqlParameter("@Product_Id", data.Product_Id));
                cmd.Parameters.Add(new SqlParameter("@Quantity", data.Quantity));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[OrderDetail_Delete]
        public void OrderDetail_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[OrderDetail_GetByAll]
        public DataTable OrderDetail_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[OrderDetail_GetById]
        public DataTable OrderDetail_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_GetById", GetConnection()))
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
        #region[OrderDetail_GetByOption]
        public DataTable OrderDetail_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_OrderDetail_GetByOption", GetConnection()))
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
