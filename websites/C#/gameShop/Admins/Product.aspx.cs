using System;
using System.Data;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
using gameShop.Data;
namespace gameShop.Admins
{
	public partial class Product : System.Web.UI.Page
	{
		static bool Insert = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["folder"] = "Product";
				BindGrid();
			}
		}
		private void BindGrid()
		{
			grdProduct.DataSource = ProductService.Product_GetByAll();
			grdProduct.DataBind();
            ShowDdl();
		}
        public string get_Category(string id)
        {
            DataTable category = CategoryService.Category_GetById(id);
            return category.Rows[0]["Name"].ToString();
        }
        public string get_Status(string id)
        {
            switch (id)
            {
                case "0" : return "Hide";
                            
                case "1" : return "Show";
                            
                default : return "";
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
			Session["upload"] = null;
			Insert=true;
            command.InnerText = "Add a Product";
		}
		
		protected void grdProduct_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA= e.CommandArgument.ToString(); 
			if  (e.CommandName=="Edit")
			{
				DataTable dt = ProductService.Product_GetById(strCA);
				txtId.Text=dt.Rows[0]["Id"].ToString();
				txtName.Text=dt.Rows[0]["Name"].ToString();
				txtDetails.Text=dt.Rows[0]["Detail"].ToString();
				txtPrice.Text=dt.Rows[0]["Price"].ToString();
                Session["upload"] = dt.Rows[0]["Image"].ToString();
                uploader1.LoadImageLink();
				txtPriceNew.Text=dt.Rows[0]["PriceSale"].ToString();
				//txtDate.Text=dt.Rows[0]["Date"].ToString();
				//ddlType.SelectedValue=dt.Rows[0]["Type"].ToString();
				//txtOrd.Text=dt.Rows[0]["Ord"].ToString();
				ddlStatus.SelectedValue=dt.Rows[0]["Status"].ToString();
                ddlCategory_Id_Update.SelectedValue=dt.Rows[0]["Category_Id"].ToString();
				pnUpdate.Visible = true;
				pnShow.Visible = false;
                command.InnerText = "Edit Product";
			} 
			if(e.CommandName=="Delete")
			{
                delete_picture(strCA);
				ProductService.Product_Delete(strCA);
				BindGrid();
			}
		}
		protected void lblBack_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = false;
			pnShow.Visible = true;
            if (Session["upload"] != null && Insert == true)
            {
                delete_picturebyLink(Session["upload"].ToString());
            }
			Insert=false;
            command.InnerText = "";
		}
		protected void lblUpdate_Click(object sender, EventArgs e)
		{
			string image = Session["upload"] == null ? "" : Session["upload"].ToString();
			#region[TestInput]
			if (txtName.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Name can not be empty!");
				txtName.Focus();
				return;
			}
			if (txtDetails.Text.Trim().Equals(""))
			{
                WebMsgBox.Show("Detail can not be empty!");
				txtDetails.Focus();
				return;
			}
			if (txtPrice.Text.Trim().Equals(""))
			{
                WebMsgBox.Show("Price can not be empty!");
				txtPrice.Focus();
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
			/*if (txtDate.Text.Trim().Equals(""))
			{
                WebMsgBox.Show("Date can not be empty!");
				txtDate.Focus();
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
            if (ddlCategory_Id_Update.SelectedValue.Trim().Equals(""))
            {
                WebMsgBox.Show("Category_Id can not be empty");
                ddlCategory_Id_Update.Focus();
                return;
            }
			#endregion
			ProductInfo obj=new ProductInfo();
			obj.Id = txtId.Text;
			obj.Name = txtName.Text;
			obj.Detail = txtDetails.Text;
			obj.Price = txtPrice.Text;
            obj.Image = Session["upload"].ToString();
			obj.PriceSale = txtPriceNew.Text;
			//obj.Date = txtDate.Text;
            obj.Date = DateTime.Now.ToString();
			//obj.Type = ddlType.SelectedValue;
			//obj.Ord = txtOrd.Text;
			obj.Status = ddlStatus.SelectedValue;
            obj.Category_Id = ddlCategory_Id_Update.SelectedValue;
			if (Insert == true)
			{
				ProductService.Product_Insert(obj);
			}else
			{
				ProductService.Product_Update(obj);
			}
			BindGrid();
			pnShow.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
            command.InnerText = "";
		}
		protected void grdProduct_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdProduct.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void ShowDdl()
		{			
			var dt = new DataTable();
			dt = CategoryService.Category_GetByAll();
			ddlCategory_Id.DataSource = dt;
			ddlCategory_Id.DataTextField = "Name";
			ddlCategory_Id.DataValueField = "Id";
			ddlCategory_Id.DataBind();
            ddlCategory_Id_Update.DataSource = dt;
            ddlCategory_Id_Update.DataTextField = "Name";
            ddlCategory_Id_Update.DataValueField = "Id";
            ddlCategory_Id_Update.DataBind();
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            string Where = "Category_Id = " + ddlCategory_Id.SelectedValue;
            grdProduct.DataSource =ProductService.db.Product_GetByOption(Where,"");
            grdProduct.DataBind();
        }

        public void BindGrid(string Where, string Order)
        {

            grdProduct.DataSource = ProductService.db.Product_GetByOption(Where, Order);
            grdProduct.DataBind();
            ShowDdl();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "Name like N'%" + txtSearch.Text + "%'";
            BindGrid(Where, "");
        }
        public void delete_picture(string id)
        {
            try
            {
                DataTable product = ProductService.db.Product_GetById(id);
                string picture = product.Rows[0]["Image"].ToString();
                string fileName = Server.MapPath(picture);
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);
                }
                
            }
            catch (Exception ms)
            {
                Console.WriteLine("{0} Exception caught.", ms);
            }
        }

        public void delete_picturebyLink(string link)
        {
            try
            {
                string fileName = Server.MapPath(link);
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);
                }

            }
            catch (Exception ms)
            {
                Console.WriteLine("{0} Exception caught.", ms);
            }
        }
	}
}