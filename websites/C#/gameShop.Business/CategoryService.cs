using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class CategoryService
    {
        public static CategoryController db = new CategoryController();
        #region[Category_Insert]
        public static void Category_Insert(CategoryInfo data)
        {
            db.Category_Insert(data);
        }
        #endregion
        #region[Category_Update]
        public static void Category_Update(CategoryInfo data)
        {
            db.Category_Update(data);
        }
        #endregion
        #region[Category_Delete]
        public static void Category_Delete(string Id)
        {
            db.Category_Delete(Id);
        }
        #endregion
        #region[Category_GetByAll]
        public static DataTable Category_GetByAll()
        {
            return db.Category_GetByAll();
        }
        #endregion
        #region[Category_GetById]
        public static DataTable Category_GetById(string Id)
        {
            return db.Category_GetById(Id);
        }
        #endregion
        #region[Category_GetByOption]
        public static DataTable Category_GetByOption(string Where, string Order)
        {
            return db.Category_GetByOption(Where, Order);
        }
        #endregion
    }
}
