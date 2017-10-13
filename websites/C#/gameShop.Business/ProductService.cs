using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameShop.Data;
using System.Data;

namespace gameShop.Business
{
    public class ProductService
    {
        public static ProductController db = new ProductController();
        #region[Product_Insert]
        public static void Product_Insert(ProductInfo data)
        {
            db.Product_Insert(data);
        }
        #endregion
        #region[Product_Update]
        public static void Product_Update(ProductInfo data)
        {
            db.Product_Update(data);
        }
        #endregion
        #region[Product_Delete]
        public static void Product_Delete(string Id)
        {
            db.Product_Delete(Id);
        }
        #endregion
        #region[Product_GetByAll]
        public static DataTable Product_GetByAll()
        {
            return db.Product_GetByAll();
        }
        #endregion
        #region[Product_GetById]
        public static DataTable Product_GetById(string Id)
        {
            return db.Product_GetById(Id);
        }
        #endregion
        #region[Product_GetByOption]
        public static DataTable Product_GetByOption(string Where, string Order)
        {
            return db.Product_GetByOption(Where, Order);
        }
        #endregion
    }
}
