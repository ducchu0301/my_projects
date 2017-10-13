using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
using gameShop.Data;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace gameShop.Admins
{
    public partial class Order : System.Web.UI.Page
    {
        static bool Insert = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			
				BindGrid();
                pnUpdate.Visible = false;
			
		}
		private void BindGrid()
		{
            if (Session["OrderStatus"] != null)
            {
                if (int.Parse(Session["OrderStatus"].ToString()) != 1)
                {
                    grdOrder.DataSource = OrderService.db.Order_GetByOption("Status = " + Session["OrderStatus"], "");
                }
                else
                {
                    grdOrder.DataSource = OrderService.db.Order_GetByAll();
                }    
            }
            else
            {
                grdOrder.DataSource = OrderService.db.Order_GetByAll();
            }
            grdOrder.DataBind();
            ShowDdl();
            if (Session["OrderStatus"] != null)
            {
                ddlSearchStatus.SelectedValue = Session["OrderStatus"].ToString();
            }
            else
            {
                ddlSearchStatus.SelectedValue = "1";
            }
		}
        public string get_Customer(string id)
        {
            DataTable customer = CustomerService.Customer_GetById(id);
            return customer.Rows[0]["Name"].ToString();
        }
        public string get_Status(string id)
        {
            switch (id)
            {
                case "0": return "Cancelled";

                case "2": return "New";

                case "3": return "Shipped";
                case "4": return "Completed";
                
                default: return "";
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
		protected void btnThem_Click(object sender, EventArgs e)
		{
			pnShow.Visible = false;
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(pnUpdate);
			txtTotalMoney.Text = "0";
			Insert=true;
            command.InnerText = "Add an Order";
		}
		
		protected void grdOrder_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA= e.CommandArgument.ToString();
            if (e.CommandName == "Confirm")
            {
                DataTable dt = OrderService.Order_GetById(strCA);
                if (dt.Rows[0]["Status"].ToString().Equals("2"))
                {
                    DataTable customer = CustomerService.Customer_GetById(dt.Rows[0]["Customer_Id"].ToString());
                    send_Mail(strCA, customer.Rows[0]["Mail"].ToString());
                }
                if (int.Parse(dt.Rows[0]["Status"].ToString()) != 4)
                {
                    OrderInfo obj = new OrderInfo();
                    obj.Id = dt.Rows[0]["Id"].ToString();
                    obj.Customer_Id = dt.Rows[0]["Customer_Id"].ToString();
                    obj.TotalMoney = dt.Rows[0]["TotalMoney"].ToString();
                    obj.Date = dt.Rows[0]["Date"].ToString();
                    int status = int.Parse(dt.Rows[0]["Status"].ToString()) + 1;
                    if (status == 1)
                    {
                        status = status + 1;
                    }
                    obj.Status = status.ToString();
                    OrderService.Order_Update(obj);
                    BindGrid();
                }
            }
            if (e.CommandName == "Edit")
            {
                DataTable dt = OrderService.Order_GetById(strCA);
                txtId.Text = dt.Rows[0]["Id"].ToString();
                //txtCustomer_Id.Text = dt.Rows[0]["Customer_Id"].ToString();
                txtTotalMoney.Text = dt.Rows[0]["TotalMoney"].ToString();
                //txtDate.Text=dt.Rows[0]["Date"].ToString();
                //ddlType.SelectedValue=dt.Rows[0]["Type"].ToString();
                //txtOrd.Text=dt.Rows[0]["Ord"].ToString();
                ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                ddlCustomer_Id_Update.SelectedValue = dt.Rows[0]["Customer_Id"].ToString();
                pnUpdate.Visible = true;
                pnShow.Visible = false;
                command.InnerText = "Edit Order";
            }
            if (e.CommandName == "Delete")
            {
                OrderService.Order_Delete(strCA);
                BindGrid();
            }
            if (e.CommandName == "Cancel")
            {
                DataTable dt = OrderService.Order_GetById(strCA);
                if (int.Parse(dt.Rows[0]["Status"].ToString()) != 4)
                {
                    OrderInfo obj = new OrderInfo();
                    obj.Id = dt.Rows[0]["Id"].ToString();
                    obj.Customer_Id = dt.Rows[0]["Customer_Id"].ToString();
                    obj.TotalMoney = dt.Rows[0]["TotalMoney"].ToString();
                    obj.Date = dt.Rows[0]["Date"].ToString();
                    int status = 0;
                    obj.Status = status.ToString();
                    OrderService.Order_Update(obj);
                    BindGrid();
                }
            }
		}
		protected void lblBack_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = false;
			pnShow.Visible = true;
			Insert=false;
            command.InnerText = "";
		}
		protected void lblUpdate_Click(object sender, EventArgs e)
		{
			
			#region[TestInput]
			
			if (txtTotalMoney.Text.Trim().Equals(""))
			{
                WebMsgBox.Show("TotalMoney can not be empty!");
				txtTotalMoney.Focus();
				return;
			}
			
			/*if (txtImage.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Image không thể trống !");
				txtImage.Focus();
				return;
			}*/
			/*if (txtPriceNew.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("PriceNew không thể trống !");
				txtPriceNew.Focus();
				return;
			}*/
			
			/*if (txtType.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Type không thể trống !");
				txtType.Focus();
				return;
			}*/
			/*if (txtOrd.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Ord không thể trống !");
				txtOrd.Focus();
				return;
			}*/
			/*if (txtStatus.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Status không thể trống !");
				txtStatus.Focus();
				return;
			}*/
            if (ddlCustomer_Id_Update.SelectedValue.Trim().Equals(""))
            {
                WebMsgBox.Show("Customer_Id can not be empty");
                ddlCustomer_Id_Update.Focus();
                return;
            }
			#endregion
			OrderInfo obj=new OrderInfo();
			obj.Id = txtId.Text;
            obj.Customer_Id = ddlCustomer_Id_Update.SelectedValue;
            DataTable customer = CustomerService.Customer_GetById(obj.Customer_Id);
            obj.TotalMoney = txtTotalMoney.Text;
            obj.Date = DateTime.Now.ToString();
			//obj.Type = ddlType.SelectedValue;
			//obj.Ord = txtOrd.Text;
			obj.Status = ddlStatus.SelectedValue;
            if (obj.Status.Equals("3"))
            {
                send_Mail(obj.Id, customer.Rows[0]["Mail"].ToString());
            }
            if (Insert == true)
            {
                OrderService.Order_Insert(obj);
            }
            else
            {
                OrderService.Order_Update(obj);
            }
			BindGrid();
			pnShow.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
            command.InnerText = "";
		}
		protected void grdOrder_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdOrder.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void ShowDdl()
		{			
			var dt = new DataTable();
			dt = CustomerService.Customer_GetByAll();
			
            ddlCustomer_Id_Update.DataSource = dt;
            ddlCustomer_Id_Update.DataTextField = "Name";
            ddlCustomer_Id_Update.DataValueField = "Id";
            ddlCustomer_Id_Update.DataBind();
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {

            if (ddlSearchStatus.SelectedValue != "1")
            {
                string Where = "Status = " + ddlSearchStatus.SelectedValue;
                grdOrder.DataSource = OrderService.db.Order_GetByOption(Where, "");
            }
            else
            {
                grdOrder.DataSource = OrderService.Order_GetByAll();
            }
            Session["OrderStatus"] = ddlSearchStatus.SelectedValue;
            grdOrder.DataBind();
        }

		

        public void BindGrid(string Where, string Order)
        {

            grdOrder.DataSource = OrderService.db.Order_GetByOption(Where, Order);
            grdOrder.DataBind();
            ShowDdl();
        }


        protected string send_Mail(string Order_Id, string Mail) //Mail la Email cua nguoi nhan
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><head>");
                sb.Append("<link rel='stylesheet' type='text/css' href='theme.css' />");
                sb.Append("</head>");
                sb.Append("<body>");
                sb.Append("<table>");
                //
                DataTable order = OrderService.Order_GetById(Order_Id);
                string content = "";
                content += "Confirm Order<br/>";
                content += "We have confirmed your Order. It'll be shipped as soon as possible.<br/>";
                content += "Below is your Order's information.<br/><hr/>";
                content += "Your Order Id: " + order.Rows[0]["Id"].ToString() + "<br/>";
                DataTable orderdetail = OrderDetailService.OrderDetail_GetByOption("Order_Id = " + order.Rows[0]["Id"].ToString(), "");
                content += "<table border='1'><tr><td>Product Name</td><td>Price</td><td>Quantity</td></tr>";
                for (int i = 0; i < orderdetail.Rows.Count; i++)
                {
                    DataTable product = ProductService.Product_GetById(orderdetail.Rows[i]["Product_Id"].ToString());
                    content += "<tr><td>" + product.Rows[0]["Name"].ToString() + "</td><td>" + Format_Price(product.Rows[0]["Price"].ToString()) + "</td><td>" + orderdetail.Rows[i]["Quantity"].ToString() + "</td></tr>";
                }
                content += "</table>";
                content += "Total Money: " + Format_Price(order.Rows[0]["TotalMoney"].ToString())+"<br/><hr/>";
                content += "Customer's Information:<br/><hr/>";
                DataTable customer = CustomerService.Customer_GetById(order.Rows[0]["Customer_Id"].ToString());
                content += "Name: " + customer.Rows[0]["Name"].ToString() + "<br/>";
                content += "Birthday: " + get_time(customer.Rows[0]["BirthDay"].ToString()) + "<br/>";
                content += "Address: " + customer.Rows[0]["Address"].ToString() + "<br/>";
                content += "Tel: " + customer.Rows[0]["Tel"].ToString() + "<br/>";
                content += "<hr/><br/>";
                content += "Thanks for buying our products!<br/>";
                //
                sb.Append("<tr><td>"+content+"</td></tr>");
                sb.Append("</table>");
                sb.Append("</body>");
                sb.Append("</html>");
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress("zzhankunzz@gmail.com", "Game Shop", System.Text.Encoding.UTF8);
                msg.Subject = "Confirm Order";
                msg.To.Add(Mail);
                msg.Body = sb.ToString();
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                //Add the Creddentials
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("zzhankunzz@gmail.com", "99u7o9u87"),
                    EnableSsl = true,
                    Timeout = 10000
                };
                
                smtp.Send(msg);
                return "Successfull!";
            }
            catch (Exception ms)
            {
                return ms.Message;
            }
        }

        public string get_time(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            string get = dt.Day + "/" + dt.Month + "/" + dt.Year;
            return get;
        }
	}
}