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
    public partial class ProductDetail : System.Web.UI.Page
    {
        static string prevPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["id"] != null)
                {
                    string ID = Page.RouteData.Values["id"].ToString();
                    ProductInfo obj = new ProductInfo();
                    obj.Id = ID;
                    var dt = ProductService.Product_GetById(ID);
                    lblTitle.Text = "Detail of Product: " + dt.Rows[0]["Name"].ToString();
                    rptProduct.DataSource = ProductService.Product_GetById(ID);
                    rptProduct.DataBind();
                    set_detail(ID);
                    prevPage = Request.UrlReferrer.ToString();
                }
                else
                {
                    Response.Redirect("/");
                }
            }
        }
        public void set_detail(string id)
        {
            DataTable dt = ProductService.Product_GetById(id);
            DIVdetail.InnerHtml = add_br(dt.Rows[0]["Detail"].ToString());
            
        }
        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();
            if (e.CommandName == "Order")
            {
                TextBox txtQuantity = (TextBox)rptProduct.Items[0].FindControl("txtQuantity");
                int Quantity;
                try
                {
                    Quantity = int.Parse(txtQuantity.Text);
                }
                catch(Exception)
                {
                    WebMsgBox.Show("Add a quantity!");
                    return;
                }
                
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
                    row["Quantity"] = Quantity.ToString();
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
                        row["Quantity"] = dem + Quantity;
                        Cart.Rows.RemoveAt(a);
                    }
                    else
                    {
                        row["Quantity"] = Quantity;
                    }
                    row["Price"] = Product.Rows[0]["Price"].ToString();
                    Cart.Rows.Add(row);
                }
                Session["Cart"] = Cart;
                WebMsgBox.Show("Added to cart!");
            }
            if (e.CommandName == "Back")
            {
                Response.Redirect(prevPage);
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

        public string add_br(string content)
        {
            string a = content;
            a = a.Replace("\r\n", "<br/>");
            
            string b = "<table width='100%'><tr><td>" + a + "</td></tr></table>";
            return b;
        }
    }
}