using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gameShop.Data;
using gameShop.Business;
using gameShop.Common;
namespace gameShop
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["gid"] != null)
                {
                    string ID = Page.RouteData.Values["gid"].ToString();
                    CategoryInfo obj = new CategoryInfo();
                    obj.Id = ID;
                    var dt = CategoryService.Category_GetById(ID);
                    lblTitle.Text = dt.Rows[0]["Name"].ToString();
                    BindData(ID);
                }
                else
                {
                    Response.Redirect("/");
                }
            }
        }

        public void BindData(string id)
        {
            listproduct.DataSource = ProductService.Product_GetByOption("Category_Id =" + id, "");
            listproduct.DataBind();
        }
        protected void listproduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DataTable Cart;
            DataTable Product;
            string strCA = e.CommandArgument.ToString();
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