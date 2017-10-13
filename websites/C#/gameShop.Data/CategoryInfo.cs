using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class CategoryInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public string Status { get; set; }
        public string Parent_Id { get; set; }
    }
}
