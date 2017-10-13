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
    public partial class OrderDetail : System.Web.UI.Page
    {
        static bool Insert = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                
                if (Page.RouteData.Values["oid"] != null)
                {
                   string ID = Page.RouteData.Values["oid"].ToString();
                   BindGrid(ID);
                   pnUpdate.Visible = false;
                }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                
                
            
        }
        private void BindGrid()
        {
            grdOrderDetail.DataSource = OrderDetailService.db.OrderDetail_GetByAll();
            grdOrderDetail.DataBind();
            ShowDdl();
        }
        private void BindGrid(string id)
        {
            grdOrderDetail.DataSource = OrderDetailService.db.OrderDetail_GetByOption("Order_Id = " + id, "");
            grdOrderDetail.DataBind();
            ShowDdl();
        }
        public string get_Product(string id)
        {
            DataTable product = ProductService.Product_GetById(id);
            return product.Rows[0]["Name"].ToString();
        }
        public string get_ProductPrice(string id)
        {
            DataTable product = ProductService.Product_GetById(id);
            return product.Rows[0]["Price"].ToString();
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

            Insert = true;
            command.InnerText = "Add an OrderDetail";
        }
        
        protected void grdOrderDetail_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                DataTable dt = OrderDetailService.OrderDetail_GetById(strCA);
                txtId.Text = dt.Rows[0]["Id"].ToString();
                ddlOrder_Id_Update.SelectedValue = dt.Rows[0]["Order_Id"].ToString();
                //txtCustomer_Id.Text = dt.Rows[0]["Customer_Id"].ToString();
                //txtTotalMoney.Text = dt.Rows[0]["TotalMoney"].ToString();
                //txtDate.Text=dt.Rows[0]["Date"].ToString();
                //ddlType.SelectedValue=dt.Rows[0]["Type"].ToString();
                //txtOrd.Text=dt.Rows[0]["Ord"].ToString();
                
                ddlProduct_Id_Update.SelectedValue = dt.Rows[0]["Product_Id"].ToString();
                
                txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                pnUpdate.Visible = true;
                pnShow.Visible = false;
                command.InnerText = "Edit OrderDetail";
            }
            if (e.CommandName == "Delete")
            {
                DataTable orderdetail = OrderDetailService.OrderDetail_GetById(strCA);
                if (orderdetail.Rows.Count >= 1)
                {
                    DataTable product = ProductService.Product_GetById(orderdetail.Rows[0]["Product_Id"].ToString());
                    float submoney = float.Parse(product.Rows[0]["Price"].ToString()) * int.Parse(orderdetail.Rows[0]["Quantity"].ToString());
                    DataTable order = OrderService.Order_GetById(orderdetail.Rows[0]["Order_Id"].ToString());

                    OrderInfo obj2 = new OrderInfo();
                    obj2.Id = order.Rows[0]["Id"].ToString();
                    obj2.Customer_Id = order.Rows[0]["Customer_Id"].ToString();
                    obj2.Date = order.Rows[0]["Date"].ToString();
                    obj2.Status = order.Rows[0]["Status"].ToString();
                    float totalmoney = float.Parse(order.Rows[0]["TotalMoney"].ToString()) - submoney;
                    obj2.TotalMoney = totalmoney.ToString();
                    OrderService.Order_Update(obj2);
                    OrderDetailService.OrderDetail_Delete(strCA);

                    BindGrid();
                }
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

            if (txtQuantity.Text.Trim().Equals(""))
            {
                WebMsgBox.Show("Quantity can not be empty!");
                txtQuantity.Focus();
                return;
            }

            if (ddlOrder_Id_Update.SelectedValue.Trim().Equals(""))
            {
                WebMsgBox.Show("Order Id can not be empty!");
                ddlOrder_Id_Update.Focus();
                return;
            }
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
            if (ddlProduct_Id_Update.SelectedValue.Trim().Equals(""))
            {
                WebMsgBox.Show("Product_Id can not be empty");
                ddlProduct_Id_Update.Focus();
                return;
            }
            #endregion
            OrderDetailInfo obj = new OrderDetailInfo();
            obj.Id = txtId.Text;
            obj.Order_Id = ddlOrder_Id_Update.SelectedValue;
            obj.Product_Id = ddlProduct_Id_Update.SelectedValue;
            obj.Quantity = txtQuantity.Text;
            //obj.Type = ddlType.SelectedValue;
            //obj.Ord = txtOrd.Text;
            //obj.Status = ddlStatus.SelectedValue;
            DataTable orderdetail = OrderDetailService.OrderDetail_GetByOption("Order_Id = " + obj.Order_Id + " AND Product_Id = " + obj.Product_Id, "[Id] Desc");
            if (Insert == true && orderdetail.Rows.Count == 0)
            {
                OrderDetailService.OrderDetail_Insert(obj);
                DataTable product = ProductService.Product_GetById(obj.Product_Id);
                DataTable order = OrderService.Order_GetById(obj.Order_Id);
                OrderInfo obj2 = new OrderInfo();
                obj2.Id = order.Rows[0]["Id"].ToString();
                obj2.Customer_Id = order.Rows[0]["Customer_Id"].ToString();
                obj2.Date = order.Rows[0]["Date"].ToString();
                obj2.Status = order.Rows[0]["Status"].ToString();
                float addmoney = float.Parse(product.Rows[0]["Price"].ToString())*int.Parse(obj.Quantity);
                float totalmoney = float.Parse(order.Rows[0]["TotalMoney"].ToString()) + addmoney;
                obj2.TotalMoney = totalmoney.ToString();
                OrderService.Order_Update(obj2);
            }
            else
            {
                obj.Id = orderdetail.Rows[0]["Id"].ToString();
                DataTable od = OrderDetailService.OrderDetail_GetById(obj.Id);
                OrderDetailService.OrderDetail_Update(obj);
                DataTable product = ProductService.Product_GetById(obj.Product_Id);
                DataTable order = OrderService.Order_GetById(obj.Order_Id);
                OrderInfo obj2 = new OrderInfo();
                obj2.Id = order.Rows[0]["Id"].ToString();
                obj2.Customer_Id = order.Rows[0]["Customer_Id"].ToString();
                obj2.Date = order.Rows[0]["Date"].ToString();
                obj2.Status = order.Rows[0]["Status"].ToString();
                float submoney = float.Parse(product.Rows[0]["Price"].ToString()) * int.Parse(orderdetail.Rows[0]["Quantity"].ToString());
                float addmoney = float.Parse(product.Rows[0]["Price"].ToString()) * int.Parse(obj.Quantity);
                float totalmoney = float.Parse(order.Rows[0]["TotalMoney"].ToString()) + addmoney - submoney;
                obj2.TotalMoney = totalmoney.ToString();
                OrderService.Order_Update(obj2);
            }
            BindGrid();
            pnShow.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
            command.InnerText = "";
        }
        protected void grdOrderDetail_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdOrderDetail.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void ShowDdl()
        {
            var dt = new DataTable();
            dt = OrderService.Order_GetByOption("Status !=1","");
            ddlOrder_Id_Update.DataSource = dt;
            ddlOrder_Id_Update.DataTextField = "Id";
            ddlOrder_Id_Update.DataValueField = "Id";
            ddlOrder_Id_Update.DataBind();
            
            ddlSearchOrderId.DataSource = dt;
            ddlSearchOrderId.DataTextField = "Id";
            ddlSearchOrderId.DataValueField = "Id";
            ddlSearchOrderId.DataBind();

            var dt2 = new DataTable();
            dt2 = ProductService.Product_GetByAll();
            ddlProduct_Id_Update.DataSource = dt2;
            ddlProduct_Id_Update.DataTextField = "Name";
            ddlProduct_Id_Update.DataValueField = "Id";
            ddlProduct_Id_Update.DataBind();

        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            string Where = "Order_Id = " + ddlSearchOrderId.SelectedValue;
            grdOrderDetail.DataSource = OrderDetailService.db.OrderDetail_GetByOption(Where, "");
            grdOrderDetail.DataBind();
        }

        

        public void BindGrid(string Where, string Order)
        {

            grdOrderDetail.DataSource = OrderDetailService.db.OrderDetail_GetByOption(Where, Order);
            grdOrderDetail.DataBind();
            ShowDdl();
        }

       

    }
}