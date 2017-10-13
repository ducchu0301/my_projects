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
namespace gameShop.Admins
{
    public partial class Customer : System.Web.UI.Page
    {
        static bool Insert = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                pnUpdate.Visible = false;
            }
        }
        private void BindGrid()
        {
            grdCustomer.DataSource = CustomerService.db.Customer_GetByAll();
            grdCustomer.DataBind();
            ShowDdl();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pnShow.Visible = false;
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);

            Insert = true;
            command.InnerText = "Add a Customer";
        }
        
        protected void grdCustomer_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                DataTable dt = CustomerService.Customer_GetById(strCA);
                txtId.Text = dt.Rows[0]["Id"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtBirthDay.Text = dt.Rows[0]["BirthDay"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtTel.Text = dt.Rows[0]["Tel"].ToString();
                txtMail.Text = dt.Rows[0]["Mail"].ToString();
                ddlUser_Id_Update.SelectedValue = dt.Rows[0]["User_Id"].ToString();
                pnUpdate.Visible = true;
                pnShow.Visible = false;
                command.InnerText = "Edit Customer";
            }
            if (e.CommandName == "Delete")
            {
                CustomerService.Customer_Delete(strCA);
                BindGrid();
            }
        }
        protected void lblBack_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
            pnShow.Visible = true;
            Insert = false;
            command.InnerText = "";
        }
        protected void lblUpdate_Click(object sender, EventArgs e)
        {

            #region[TestInput]

            if (txtName.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Name can not be empty!");
                txtName.Focus();
                return;
            }
            if (txtBirthDay.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Birthday can not be empty!");
                txtBirthDay.Focus();
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
           
            if (ddlUser_Id_Update.SelectedValue.Trim().Equals(""))
            {
                WebMsgBox.Show("User_Id can not be empty");
                ddlUser_Id_Update.Focus();
                return;
            }
            #endregion
            CustomerInfo obj = new CustomerInfo();
            obj.Id = txtId.Text;
            obj.Name = txtName.Text;
            obj.BirthDay = txtBirthDay.Text;
            obj.Address = txtAddress.Text;
            
            obj.Mail = txtMail.Text;
            obj.Tel = txtTel.Text;
            obj.User_Id = ddlUser_Id_Update.SelectedValue;
            
            //obj.Type = ddlType.SelectedValue;
            //obj.Ord = txtOrd.Text;
            
            if (Insert == true)
            {
                CustomerService.Customer_Insert(obj);
            }
            else
            {
                CustomerService.Customer_Update(obj);
            }
            BindGrid();
            pnShow.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
            command.InnerText = "";
        }
        protected void grdCustomer_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdCustomer.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void ShowDdl()
        {
            var dt = new DataTable();
            dt = UserService.User_GetByAll();
            ddlUser_Id_Update.DataSource = dt;
            ddlUser_Id_Update.DataTextField = "Name";
            ddlUser_Id_Update.DataValueField = "Id";
            ddlUser_Id_Update.DataBind();

            ddlSearchUser.DataSource = dt;
            ddlSearchUser.DataTextField = "Name";
            ddlSearchUser.DataValueField = "Id";
            ddlSearchUser.DataBind();
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            string Where = "User_Id = " + ddlSearchUser.SelectedValue;
            grdCustomer.DataSource = CustomerService.Customer_GetByOption(Where, "");
            grdCustomer.DataBind();
        }


        public void BindGrid(string Where, string Order)
        {

            grdCustomer.DataSource = CustomerService.db.Customer_GetByOption(Where, Order);
            grdCustomer.DataBind();
            ShowDdl();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "Name like N'%" + txtSearch.Text + "%'";
            BindGrid(Where, "");
        }

        public string get_User(string id)
        {
            DataTable user = UserService.User_GetById(id);
            return user.Rows[0]["Name"].ToString();
        }
        public string get_time(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            string get = dt.Day + "/" + dt.Month + "/" + dt.Year;
            return get;
        }
    }
}