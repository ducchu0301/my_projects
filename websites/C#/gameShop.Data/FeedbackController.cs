using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace gameShop.Data
{
    public class FeedbackController :SqlDataProvider
    {
        #region[Feedback_Insert]
        public void Feedback_Insert(FeedbackInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Customer_Id", data.Customer_Id));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Feedback_Update]
        public void Feedback_Update(FeedbackInfo data)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Customer_Id", data.Customer_Id));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Feedback_Delete]
        public void Feedback_Delete(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region[Feedback_GetByAll]
        public DataTable Feedback_GetByAll()
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region[Feedback_GetById]
        public DataTable Feedback_GetById(string Id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_GetById", GetConnection()))
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
        #region[Feedback_GetByOption]
        public DataTable Feedback_GetByOption(string Where, string Order)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Feedback_GetByOption", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Where", Where));
                cmd.Parameters.Add(new SqlParameter("@Feedback", Order));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
