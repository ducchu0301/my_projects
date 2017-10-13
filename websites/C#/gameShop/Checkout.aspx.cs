using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
using gameShop.Data;
namespace gameShop
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderId"] != null)
            {
                OrderEnd.Visible = true;
                CheckoutCustomer.Visible = false;
                GetOrder(Session["OrderId"].ToString());
                
            }
            else if (Session["Cart"] == null || Session["Username"] == null)
            {
                Response.Redirect("/Cart/");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Name can not be empty!");
                txtName.Focus();
                return;
            }
            if (txtDay.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birthday can not be empty!");
                txtDay.Focus();
                return;
            }
            if (txtMonth.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birthday can not be empty!");
                txtMonth.Focus();
                return;
            }
            if (txtYear.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birthday can not be empty!");
                txtYear.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Address can not be empty!");
                txtAddress.Focus();
                return;
            }
            if (txtTel.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Tel can not be empty!");
                txtTel.Focus();
                return;
            }
            if (txtMail.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Mail can not be empty!");
                txtMail.Focus();
                return;
            }

            
            #endregion
            string username = "";
            if (Session["Username"] != null)
            {
                username = Session["Username"].ToString();
            }
            DataTable aUser = UserService.db.User_GetByOption("Username = '"+username+"'", "");
            if (aUser.Rows.Count == 1)
            {
                string UID = aUser.Rows[0]["Id"].ToString();
                
                CustomerInfo obj = new CustomerInfo();
                obj.Name = txtName.Text;
                string time = txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text;
                obj.BirthDay = time;
                obj.Address = txtAddress.Text;
                obj.Mail = txtMail.Text;
                obj.Tel = txtTel.Text;
                obj.User_Id = UID;
                CustomerService.Customer_Insert(obj);
                DataTable getidcustomer = CustomerService.Customer_GetByOption("Name ='" + obj.Name + "' AND Address = '" + obj.Address + "' AND Mail = '" + obj.Mail + "' AND Tel = '" + obj.Tel + "'", "[Id] Desc ");
                string customerid = "";
                if (getidcustomer.Rows.Count >= 1)
                {
                    customerid = getidcustomer.Rows[0]["Id"].ToString();
                }
                OrderInfo addOrder = new OrderInfo();
                string totalmoney = Total_Money().ToString();
                addOrder.Customer_Id = customerid;
                addOrder.TotalMoney = totalmoney;
                addOrder.Date = DateTime.Now.ToString();
                addOrder.Status = "2";
                OrderService.Order_Insert(addOrder);

                DataTable aCart;
                DataTable anOrder = OrderService.Order_GetByOption("Customer_Id ="+customerid,"");
                string OID = anOrder.Rows[0]["Id"].ToString();
                OrderDetailInfo addOrderDetail = new OrderDetailInfo();
                if (Session["Cart"] != null)
                {
                    aCart = (DataTable)Session["Cart"];
                    for (int i = 0; i < aCart.Rows.Count; i++)
                    {
                        addOrderDetail.Order_Id = OID;
                        addOrderDetail.Product_Id = aCart.Rows[i]["ID"].ToString();
                        addOrderDetail.Quantity = aCart.Rows[i]["Quantity"].ToString();
                        OrderDetailService.OrderDetail_Insert(addOrderDetail);
                    }
                }
                Session.Remove("Cart");
                Session["OrderId"] = OID;
                Response.Redirect("/Checkout/");
            }
            
            
        }
        public float Total_Money()
        {
            DataTable aCart;
            float total = 0;
            if (Session["Cart"] != null)
            {
                aCart = (DataTable)Session["Cart"];
                for (int i = 0; i < aCart.Rows.Count; i++)
                {
                    total = total + float.Parse(Total_Price(aCart.Rows[i]["ID"].ToString()));
                }
                
            }
            return total;
        }
        public string Total_Price(string id)
        {
            DataTable aCart;
            string totalprice = "";
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

        public void GetOrder(string id)
        {
            DataTable anOrder = OrderService.Order_GetById(id);
            string customerId = anOrder.Rows[0]["Customer_Id"].ToString();
            OrderId.InnerText = "Order Id: " + anOrder.Rows[0]["Id"].ToString();
            OrderTotalMoney.InnerText = "Total: " + Format_Price(anOrder.Rows[0]["TotalMoney"].ToString());
            DataTable anOrderDetail = OrderDetailService.OrderDetail_GetByOption("Order_Id = " + id, "");
            grdOrderDetail.DataSource = anOrderDetail;
            grdOrderDetail.DataBind();
            DataTable aCustomer = CustomerService.Customer_GetById(customerId);
            OrderCustomer.InnerText = "Ship to Mr(Ms): " + aCustomer.Rows[0]["Name"].ToString() + " at " + aCustomer.Rows[0]["Address"].ToString();
            OrderFeedback.InnerText = "We'll contact by email: " + aCustomer.Rows[0]["Mail"].ToString() + " when we confirm this order. Thanks for buying our products."; 
        }
        public string getNameProduct(string id)
        {
            DataTable aProduct = ProductService.Product_GetById(id);
            return aProduct.Rows[0]["Name"].ToString();
        }
        public string getPriceProduct(string id)
        {
            DataTable aProduct = ProductService.Product_GetById(id);
            return aProduct.Rows[0]["Price"].ToString();
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
        protected void btnShopping_Click(object sender, EventArgs e)
        {
            Session.Remove("OrderId");
            Response.Redirect("/");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!txtFeedback.Text.Trim().Equals(""))
            {
                DataTable order = OrderService.Order_GetById(Session["OrderId"].ToString());
                FeedbackInfo fb = new FeedbackInfo();
                fb.Customer_Id = order.Rows[0]["Customer_Id"].ToString();
                fb.Content = txtFeedback.Text;
                FeedbackService.Feedback_Insert(fb);
            }
            Session.Remove("OrderId");
            Response.Redirect("/");
            
        }
    }
}