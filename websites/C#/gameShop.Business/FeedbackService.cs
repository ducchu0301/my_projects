using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class FeedbackService
    {
        public static FeedbackController db = new FeedbackController();
        #region[Feedback_Insert]
        public static void Feedback_Insert(FeedbackInfo data)
        {
            db.Feedback_Insert(data);
        }
        #endregion
        #region[Feedback_Update]
        public static void Feedback_Update(FeedbackInfo data)
        {
            db.Feedback_Update(data);
        }
        #endregion
        #region[Feedback_Delete]
        public static void Feedback_Delete(string Id)
        {
            db.Feedback_Delete(Id);
        }
        #endregion
        #region[Feedback_GetByAll]
        public static DataTable Feedback_GetByAll()
        {
            return db.Feedback_GetByAll();
        }
        #endregion
        #region[Feedback_GetById]
        public static DataTable Feedback_GetById(string Id)
        {
            return db.Feedback_GetById(Id);
        }
        #endregion
        #region[Feedback_GetByOption]
        public static DataTable Feedback_GetByOption(string Where, string Order)
        {
            return db.Feedback_GetByOption(Where, Order);
        }
        #endregion
    }
}
