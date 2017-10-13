using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class OrderInfo
    {
        public string Id { get; set; }
        public string Customer_Id { get; set; }
        public string TotalMoney { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
