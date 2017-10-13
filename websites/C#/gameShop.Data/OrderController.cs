using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class OrderController : SqlDataProvider
    {
        #region[Order_Insert]
        public void Order_Insert(OrderInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Customer_Id", data.Customer_Id));
                cmd.Parameters.Add(new SqlParameter("@TotalMoney", data.TotalMoney));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Order_Update]
        public void Order_Update(OrderInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Customer_Id", data.Customer_Id));
                cmd.Parameters.Add(new SqlParameter("@TotalMoney", data.TotalMoney));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Order_Delete]
        public void Order_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Order_GetByAll]
        public DataTable Order_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Order_GetById]
        public DataTable Order_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_GetById", GetConnection()))
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
        #region[Order_GetByOption]
        public DataTable Order_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Order_GetByOption", GetConnection()))
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
