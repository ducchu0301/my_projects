using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class OrderDetailService
    {
        public static OrderDetailController db = new OrderDetailController();
        #region[OrderDetail_Insert]
        public static void OrderDetail_Insert(OrderDetailInfo data)
        {
            db.OrderDetail_Insert(data);
        }
        #endregion
        #region[OrderDetail_Update]
        public static void OrderDetail_Update(OrderDetailInfo data)
        {
            db.OrderDetail_Update(data);
        }
        #endregion
        #region[OrderDetail_Delete]
        public static void OrderDetail_Delete(string Id)
        {
            db.OrderDetail_Delete(Id);
        }
        #endregion
        #region[OrderDetail_GetByAll]
        public static DataTable OrderDetail_GetByAll()
        {
            return db.OrderDetail_GetByAll();
        }
        #endregion
        #region[OrderDetail_GetById]
        public static DataTable OrderDetail_GetById(string Id)
        {
            return db.OrderDetail_GetById(Id);
        }
        #endregion
        #region[OrderDetail_GetByOption]
        public static DataTable OrderDetail_GetByOption(string Where, string Order)
        {
            return db.OrderDetail_GetByOption(Where, Order);
        }
        #endregion
    }
}
