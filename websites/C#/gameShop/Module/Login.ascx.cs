using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
namespace gameShop.Module
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                loginForm.Visible = false;
                loginPanel.Visible = true;
                HelloUsername.InnerHtml = "&nbsp;&nbsp;&nbsp;Hi : " + Session["Username"];
            }
            else
            {
                loginForm.Visible = true;
                loginPanel.Visible = false;
            }
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
            if (qh < 3 && qh > -1)
            {
                if (qh == 0)
                {
                    WebMsgBox.Show("This user have been blocked!");

                }
                else
                {
                    Session["Username"] = txtUsername.Text.Trim();
                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    if (!path.Equals("/default.aspx"))
                    {
                        Response.Redirect(path);
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
                }
            }
            else
            {
                WebMsgBox.Show("Wrong username or password!");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register/");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Session.Remove("Rule");
            loginForm.Visible = true;
            loginPanel.Visible = false;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
                    if (!path.Equals("/default.aspx"))
                    {
                        Response.Redirect(path);
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
        }
    }
}