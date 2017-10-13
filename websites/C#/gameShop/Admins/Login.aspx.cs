using System;
using gameShop.Business;
using gameShop.Common;
using gameShop.Data;

namespace gameShop.Admins
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {
            #region[Test input]
            if (txtUsername.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Username is required!");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Password is required!");
                txtPassword.Focus();
                return;
            }
            #endregion
            int qh = UserService.db.User_CheckLogin(txtUsername.Text, txtPassword.Text);
            if (qh < 2 && qh >-1)
            {
                Session["Rule"] = qh;
                Session["Username"] = txtUsername.Text.Trim();
                Response.Redirect("~/Admins/Default.aspx");
            }
            else
            {
                WebMsgBox.Show("Wrong username or password!");
            }
        }
        protected void btnHuyBo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}