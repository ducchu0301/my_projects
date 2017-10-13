using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Business;
using gameShop.Common;
using gameShop.Data;
using System.Data;
namespace gameShop.Admins
{
    public partial class User : System.Web.UI.Page
    {
        public static bool Insert;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                pnUpdate.Visible = false;
            }
        }
        public void BindGrid()
        {
            grdUser.DataSource = UserService.db.User_GetByAll();
            grdUser.DataBind();
        }
        public void BindGrid(string Where, string Order)
        {
            grdUser.DataSource = UserService.db.User_GetByOption(Where, Order);
            grdUser.DataBind();
        }
        public string get_Status(string id)
        {
            switch (id)
            {
                case "0": return "Block";

                case "1": return "Active";

                default: return "";
            }
        }
        public string get_Rule(string id)
        {
            switch (id)
            {
                case "1": return "Admin";

                case "2": return "User";

                default: return "";
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            pnShow.Visible = false;
            ControlClass.ResetControlValues(pnUpdate);
            Insert = true;
            command.InnerText = "Add a user";
        }

        protected void grdUser_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            UserInfo obj = new UserInfo();
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Insert = false;
                command.InnerText = "Update User";
                DataTable dt = UserService.db.User_GetById(Id);
                txtId.Text = Id;
                txtUsername.Text = dt.Rows[0]["Username"].ToString();
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                ddlRule.SelectedValue = dt.Rows[0]["Rule"].ToString();
                ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                pnUpdate.Visible = true;
                pnShow.Visible = false;
            }
            else
            {
                UserService.db.User_Delete(Id);
                BindGrid();
            }
        }

        protected void lbtUpdate_Click(object sender, EventArgs e)
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
            var obj = new UserInfo();
            obj.Id = txtId.Text;
            obj.Name = txtName.Text;
            obj.Username = txtUsername.Text;
            obj.Password = txtPassword.Text;
            obj.Rule = ddlRule.SelectedValue;
            obj.Status = ddlStatus.SelectedValue;
            if (Insert)
            {
                UserService.db.User_Insert(obj);
            }
            else
            {
                UserService.db.User_Update(obj);
            }
            BindGrid();
            pnUpdate.Visible = false;
            pnShow.Visible = true;
            Insert = false;
            command.InnerText = "";
        }

        protected void lbtBack_Click(object sender, EventArgs e)
        {
            pnShow.Visible = true;
            pnUpdate.Visible = false;
            command.InnerText = "";
        }

        protected void grdUser_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdUser.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "Username like N'%" + txtSearch.Text + "%'";
            BindGrid(Where, "");
        }

    }
}