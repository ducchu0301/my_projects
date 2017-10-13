using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gameShop.Business;
using gameShop.Common;
namespace gameShop
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if (Session["Username"] != null)
                {
                    Checkout.Visible = true;
                    LoginToCheckout.Visible = false;
                }
                else
                {
                    LoginToCheckout.Visible = true;
                    Checkout.Visible = false;
                }
            }
        }
        private void BindGrid()
        {
            DataTable aCart;
            if (Session["Cart"] == null)
            {
                message.InnerText = "You don't have any product in cart.";
            }
            else
            {
                aCart = (DataTable)Session["Cart"];
                float total = 0;
                for (int i = 0; i < aCart.Rows.Count; i++)
                {
                    total = total + float.Parse(Total_Price(aCart.Rows[i]["ID"].ToString()));
                }
                grdCart.DataSource = aCart;
                grdCart.DataBind();
                message.InnerText = "Total: " + Format_Price(total.ToString());
            }
            
        }

        public string Total_Price(string id)
        {
            DataTable aCart;
            string totalprice="";
            if (Session["Cart"] != null)
            {
                aCart = (DataTable)Session["Cart"];
                for (int i = 0; i < aCart.Rows.Count; i++)
                {
                    if (aCart.Rows[i]["ID"].ToString() == id)
                    {
                        int quantity = int.Parse(aCart.Rows[i]["Quantity"].ToString());
                        float price = float.Parse(aCart.Rows[i]["Price"].ToString());
                        totalprice = (quantity * price).ToString();
                        break;
                    }
                }
            }
            
            return totalprice;
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
        public string get_picture(string id)
        {
            DataTable product = ProductService.Product_GetById(id);
            return product.Rows[0]["Image"].ToString();
        }
        protected void grdCart_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            string Quantity = "1";
            if (e.CommandName == "Edit")
            {
                foreach (DataGridItem dataGridItem in grdCart.Items)
                {
                    var test = ((Label)dataGridItem.FindControl("grdLblId")).Text;
                    if (test == strCA)
                    {
                        Quantity = ((TextBox)dataGridItem.FindControl("grdLblQuantity")).Text;
                        break;
                    }
                }
                DataTable aCart;
                DataTable Product = ProductService.Product_GetById(strCA);
                int a = 0;
                if (Session["Cart"] != null)
                {
                    aCart = (DataTable)Session["Cart"];
                    for (int i = 0; i < aCart.Rows.Count; i++)
                    {
                        if (aCart.Rows[i]["ID"].ToString() == strCA)
                        {
                            a = i;
                            break;
                        }
                    }
                    aCart.Rows.RemoveAt(a);
                    DataRow row = aCart.NewRow();
                    row["ID"] = strCA;
                    row["Name"] = Product.Rows[0]["Name"].ToString();
                    row["Quantity"] = Quantity;
                    row["Price"] = Product.Rows[0]["Price"].ToString();
                    aCart.Rows.Add(row);
                    Session["Cart"] = aCart;
                    BindGrid();
                    
                }
            }
            if (e.CommandName == "Delete")
            {
                DataTable aCart;
                int a = 0;
                if (Session["Cart"] != null)
                {
                    aCart = (DataTable)Session["Cart"];
                    for (int i = 0; i < aCart.Rows.Count; i++)
                    {
                        if (aCart.Rows[i]["ID"].ToString() == strCA)
                        {
                            a = i;
                            break;
                        }
                    }
                    aCart.Rows.RemoveAt(a);
                    Session["Cart"] = aCart;
                    BindGrid();
                    
                }

            }
        }

        protected void grdCart_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCart.CurrentPageIndex= e.NewPageIndex;
            BindGrid();
        }

        protected void btncheckout_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                WebMsgBox.Show("Your cart is empty! Can't checkout!");
            }
            else
            {
                Session.Remove("OrderId");
                Response.Redirect("/Checkout/");

            }
        }
    }
}