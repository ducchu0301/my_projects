using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class OrderService
    {
        public static OrderController db = new OrderController();
        #region[Order_Insert]
        public static void Order_Insert(OrderInfo data)
        {
            db.Order_Insert(data);
        }
        #endregion
        #region[Order_Update]
        public static void Order_Update(OrderInfo data)
        {
            db.Order_Update(data);
        }
        #endregion
        #region[Order_Delete]
        public static void Order_Delete(string Id)
        {
            db.Order_Delete(Id);
        }
        #endregion
        #region[Order_GetByAll]
        public static DataTable Order_GetByAll()
        {
            return db.Order_GetByAll();
        }
        #endregion
        #region[Order_GetById]
        public static DataTable Order_GetById(string Id)
        {
            return db.Order_GetById(Id);
        }
        #endregion
        #region[Order_GetByOption]
        public static DataTable Order_GetByOption(string Where, string Order)
        {
            return db.Order_GetByOption(Where, Order);
        }
        #endregion
    }
}
