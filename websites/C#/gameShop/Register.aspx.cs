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
    public partial class Register : System.Web.UI.Page
    {
        static string prevPage="/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }
            }
        }

        protected void lbtRegister_Click(object sender, EventArgs e)
        {
            #region[TestInput]
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
            DataTable aUser = UserService.db.User_GetByOption("Username = '"+txtUsername.Text+"'", "");
            if (aUser.Rows.Count > 0)
            {
                WebMsgBox.Show("Username had used!");
                txtUsername.Focus();
                return;
            }
            var obj = new UserInfo();
            obj.Id = txtId.Text;
            obj.Name = txtName.Text;
            obj.Username = txtUsername.Text;
            obj.Password = txtPassword.Text;
            obj.Rule = ddlRule.SelectedValue;
            obj.Status = ddlStatus.SelectedValue;
            UserService.db.User_Insert(obj);
            Response.Redirect(prevPage);
        }

        protected void lbtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

    }
}