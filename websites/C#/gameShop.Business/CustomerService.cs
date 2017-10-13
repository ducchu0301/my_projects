using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class CustomerService
    {
        public static CustomerController db = new CustomerController();
        #region[Customer_Insert]
        public static void Customer_Insert(CustomerInfo data)
        {
            db.Customer_Insert(data);
        }
        #endregion
        #region[Customer_Insert_With_Id]
        public static void Customer_Insert_With_Id(CustomerInfo data)
        {
            db.Customer_Insert_With_Id(data);
        }
        #endregion
        #region[Customer_Update]
        public static void Customer_Update(CustomerInfo data)
        {
            db.Customer_Update(data);
        }
        #endregion
        #region[Customer_Delete]
        public static void Customer_Delete(string Id)
        {
            db.Customer_Delete(Id);
        }
        #endregion
        #region[Customer_GetByAll]
        public static DataTable Customer_GetByAll()
        {
            return db.Customer_GetByAll();
        }
        #endregion
        #region[Customer_GetById]
        public static DataTable Customer_GetById(string Id)
        {
            return db.Customer_GetById(Id);
        }
        #endregion
        #region[Customer_GetByOption]
        public static DataTable Customer_GetByOption(string Where,string Order)
        {
            return db.Customer_GetByOption(Where, Order);
        }
        #endregion
    }
}
