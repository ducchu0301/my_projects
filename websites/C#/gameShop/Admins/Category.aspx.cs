using System;
using System.Data;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
using gameShop.Data;
namespace gameShop.Admins
{
	public partial class Category : System.Web.UI.Page
	{
		static bool Insert = false;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["folder"] = "Category";
				BindGrid();
			}
		}
		private void BindGrid()
		{
			grdCategory.DataSource = CategoryService.Category_GetByAll();
			grdCategory.DataBind();
		}
        public string get_Status(string id)
        {
            switch (id)
            {
                case "0": return "Hide";

                case "1": return "Show";

                default: return "";
            }
        }
        public void delete_picture(string id)
        {
            try
            {
                DataTable category = CategoryService.db.Category_GetById(id);
                string picture = category.Rows[0]["Images"].ToString();
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
		protected void btnThem_Click(object sender, EventArgs e)
		{
			pnShow.Visible = false;
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(pnUpdate);
			Session["upload"] = null;
			Insert=true;
            command.InnerText = "Add a Category";
		}
		
		protected void grdCategory_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA= e.CommandArgument.ToString();
            Session["upload"] = null;
			if  (e.CommandName=="Edit")
			{
                
				DataTable dt = CategoryService.Category_GetById(strCA);
				txtId.Text = dt.Rows[0]["Id"].ToString();
				txtName.Text = dt.Rows[0]["Name"].ToString();
				txtContents.Text = dt.Rows[0]["Content"].ToString();
                Session["upload"] = dt.Rows[0]["Images"].ToString();
                uploader1.LoadImageLink();
                //txtImages.Text = dt.Rows[0]["Images"].ToString();
				//txtOrd.Text = dt.Rows[0]["Ord"].ToString();
				ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                txtParent_Id.Text = dt.Rows[0]["Parent_Id"].ToString();
				pnUpdate.Visible = true;
				pnShow.Visible = false;
                command.InnerText = "Edit Category";
			} 
			if(e.CommandName=="Delete")
			{
                delete_picture(strCA);
				CategoryService.Category_Delete(strCA);
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
				WebMsgBox.Show("Name can't empty !");
				txtName.Focus();
				return;
			}
			if (txtContents.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Content can't empty !");
				txtContents.Focus();
				return;
			}
			/*if (txtImages.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Images không thể trống !");
				txtImages.Focus();
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
			#endregion
			CategoryInfo obj=new CategoryInfo();
			obj.Id = txtId.Text;
			obj.Name = txtName.Text;
			obj.Content = txtContents.Text;
            obj.Images = Session["upload"].ToString();
			//obj.Ord = txtOrd.Text;
            obj.Parent_Id = txtParent_Id.Text;
            obj.Status = ddlStatus.SelectedValue;
			if (Insert == true)
			{
				CategoryService.Category_Insert(obj);
			}else
			{
				CategoryService.Category_Update(obj);
			}
			BindGrid();
			pnShow.Visible = true;
			pnUpdate.Visible = false;
			Insert = false;
            command.InnerText = "";
		}
		protected void grdCategory_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdCategory.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		
        public void BindGrid(string Where, string Order)
        {

            grdCategory.DataSource = CategoryService.db.Category_GetByOption(Where, Order);
            grdCategory.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "Name like N'%" + txtSearch.Text + "%'";
            BindGrid(Where, "");
        }
	}
}