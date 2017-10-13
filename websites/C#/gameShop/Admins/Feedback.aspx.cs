using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Business;
using System.Data;
using gameShop.Common;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace gameShop.Admins
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                pnSend.Visible = false;
            }
        }

        private void BindGrid()
        {
            grdFeedback.DataSource = FeedbackService.Feedback_GetByAll();
            grdFeedback.DataBind();
        }

        public string get_Customer(string id)
        {
            DataTable customer = CustomerService.Customer_GetById(id);
            return customer.Rows[0]["Name"].ToString();
        }

        protected void grdFeedback_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            if (e.CommandName == "Send")
            {
                DataTable feedback = FeedbackService.Feedback_GetById(strCA);
                DataTable customer = CustomerService.Customer_GetById(feedback.Rows[0]["Customer_Id"].ToString());
                txtCustomer.Text = customer.Rows[0]["Mail"].ToString();
                pnSend.Visible = true;
                pnShow.Visible = false;
                command.InnerText = "Send a Feedback Mail";
            }
        }

        protected void lblBack_Click(object sender, EventArgs e)
        {
            pnSend.Visible = false;
            pnShow.Visible = true;
            txtContent.Text = "";
            command.InnerText = "";
        }

        protected void lblSend_Click(object sender, EventArgs e)
        {
            #region[TestInput]

            if (txtContent.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Content can not be empty!");
                txtContent.Focus();
                return;
            }
            #endregion
            send_Mail(txtContent.Text.ToString(), txtCustomer.Text.ToString());
            pnSend.Visible = false;
            pnShow.Visible = true;
            txtContent.Text = "";
            command.InnerText = "";
        }

        protected void grdFeedback_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdFeedback.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected string send_Mail(string content, string Mail) //Mail la Email cua nguoi nhan
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
                
                //
                sb.Append("<tr><td>" + add_br(content) + "</td></tr>");
                sb.Append("</table>");
                sb.Append("</body>");
                sb.Append("</html>");
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress("zzhankunzz@gmail.com", "Game Shop");
                msg.Subject = "Reply Feedback";
                msg.To.Add(Mail);
                msg.Body = sb.ToString();
                
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.Normal;
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

        public string add_br(string content)
        {
            string a = content;
            a = a.Replace("\r\n", "<br/>");
            a = a.Replace(" ", "&nbsp;");
            return a;
        }
    }
}