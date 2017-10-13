using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gameShop.Business;
using gameShop.Common;
namespace gameShop.Module
{
    public partial class HotProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listproduct.DataSource = ProductService.Product_GetByOption("Status = 1", "[Date] Desc");
                listproduct.DataBind();
            }
        }
        
        protected void listproduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DataTable Cart;
            DataTable Product;
            string strCA = e.CommandArgument.ToString();
            if (e.CommandName == "Order")
            {
                if (Session["Cart"] == null)
                {
                    Cart = new DataTable();
                    Cart.Columns.Add("ID", typeof(string));
                    Cart.Columns.Add("Name", typeof(string));
                    Cart.Columns.Add("Quantity", typeof(string));
                    Cart.Columns.Add("Price", typeof(string));
                    Product = ProductService.Product_GetById(strCA);
                    DataRow row = Cart.NewRow();
                    row["ID"] = strCA;
                    row["Name"] = Product.Rows[0]["Name"].ToString();
                    row["Quantity"] = 1;
                    row["Price"] = Product.Rows[0]["Price"].ToString();
                    Cart.Rows.Add(row);

                }
                else
                {
                    Cart = (DataTable)Session["Cart"];
                    Product = ProductService.Product_GetById(strCA);
                    int dem = 0;
                    int a = 0;
                    for (int i = 0; i < Cart.Rows.Count; i++)
                    {
                        if (Cart.Rows[i]["ID"].ToString() == strCA)
                        {
                            dem = int.Parse(Cart.Rows[i]["Quantity"].ToString());
                            a = i;
                            break;
                        }
                    }

                    DataRow row = Cart.NewRow();
                    row["ID"] = strCA;
                    row["Name"] = Product.Rows[0]["Name"].ToString();
                    if (dem != 0)
                    {
                        row["Quantity"] = dem + 1;
                        Cart.Rows.RemoveAt(a);
                    }
                    else
                    {
                        row["Quantity"] = 1;
                    }
                    row["Price"] = Product.Rows[0]["Price"].ToString();
                    Cart.Rows.Add(row);
                }
                Session["Cart"] = Cart;
                WebMsgBox.Show("Added to cart!");
            }
        }

        public string Format_Price(string Values)
        {
            Values = Values.Replace(",", "");
            Values = Values.Replace(",", "");
            string s = "";
            while (Values.Length > 3)
            {
                s = "." + Values.Substring(Values.Length - 3) + s;
                Values = Values.Substring(0, Values.Length - 3);
            }
            s = Values + s + " $";
            return s;
        }
    }
}