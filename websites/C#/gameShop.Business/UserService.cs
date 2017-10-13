using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;
namespace gameShop.Business
{
    public class UserService
    {
        public static UserController db = new UserController();
        #region[User_Insert]
        public static void User_Insert(UserInfo data)
        {
            db.User_Insert(data);
        }
        #endregion
        #region[User_Update]
        public static void User_Update(UserInfo data)
        {
            db.User_Update(data);
        }
        #endregion
        #region[User_Delete]
        public static void User_Delete(string Id)
        {
            db.User_Delete(Id);
        }
        #endregion
        #region[User_GetByAll]
        public static DataTable User_GetByAll()
        {
            return db.User_GetByAll();
        }
        #endregion
        #region[User_GetById]
        public static DataTable User_GetById(string Id)
        {
            return db.User_GetById(Id);
        }
        #endregion
        #region[User_GetByOption]
        public static DataTable User_GetByOption(string Where, string Order, string Limit, string Page)
        {
            return db.User_GetByOption(Where, Order);
        }
        #endregion
        #region[User_CheckLogin]
        public static int User_CheckLogin(string Username, string Password)
        {
            return db.User_CheckLogin(Username, Password);
        }
        #endregion
    }
}
