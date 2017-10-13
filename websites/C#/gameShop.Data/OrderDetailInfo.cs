using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class OrderDetailInfo
    {
        public string Id { get; set; }
        public string Order_Id { get; set; }
        public string Product_Id { get; set; }
        public string Quantity { get; set; }
    }
}
