using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class ContactService
    {
        public static ContactController db = new ContactController();
        #region[Contact_Insert]
        public static void Contact_Insert(ContactInfo data)
        {
            db.Contact_Insert(data);
        }
        #endregion
        #region[Contact_Update]
        public static void Contact_Update(ContactInfo data)
        {
            db.Contact_Update(data);
        }
        #endregion
        #region[Contact_Delete]
        public static void Contact_Delete(string Id)
        {
            db.Contact_Delete(Id);
        }
        #endregion
        #region[Contact_GetByAll]
        public static DataTable Contact_GetByAll()
        {
            return db.Contact_GetByAll();
        }
        #endregion
        #region[Contact_GetById]
        public static DataTable Contact_GetById(string Id)
        {
            return db.Contact_GetById(Id);
        }
        #endregion
        #region[Contact_GetByOption]
        public static DataTable Contact_GetByOption(string Where, string Order)
        {
            return db.Contact_GetByOption(Where, Order);
        }
        #endregion
    }
}
