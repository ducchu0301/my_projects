using System;
using System.Data;
using System.Web.UI.WebControls;
using gameShop.Common;
using gameShop.Business;
using gameShop.Data;
namespace MyWeb.Admins
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
                pnUpdate.Visible = false;
			}
		}
		private void BindGrid()
		{
			grdCategory.DataSource = CategoryService.Category_GetByAll();
			grdCategory.DataBind();
		}
		protected void btnThem_Click(object sender, EventArgs e)
		{
			pnShow.Visible = false;
			pnUpdate.Visible = true;
			ControlClass.ResetControlValues(pnUpdate);
			Session["upload"] = null;
			Insert=true;
		}
		protected void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridItem item = default(DataGridItem);
				for (int i = 0; i < grdCategory.Items.Count; i++)
				{
					item = grdCategory.Items[i];
					if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
					{
						if (((CheckBox)item.FindControl("ChkSelect")).Checked)
						{
							string strId = item.Cells[1].Text;
							try
							{
								CategoryService.Category_Delete(strId);
							}
							catch
							{
							}
						}
					}
				}
                grdCategory.CurrentPageIndex = 0;
					BindGrid();
			}catch
			{
			}
		}
		protected void grdCategory_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA= e.CommandArgument.ToString(); 
			if  (e.CommandName=="Edit")
			{
				DataTable dt = CategoryService.Category_GetById(strCA);
				txtId.Text = dt.Rows[0]["Id"].ToString();
				txtName.Text = dt.Rows[0]["Name"].ToString();
				txtContent.Text = dt.Rows[0]["Content"].ToString();
                Session["upload"] = dt.Rows[0]["Images"].ToString();
				//txtOrd.Text = dt.Rows[0]["Ord"].ToString();
				ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                txtParent_Id.Text = dt.Rows[0]["Parent_Id"].ToString();
				pnUpdate.Visible = true;
				pnShow.Visible = false;
			} 
			if(e.CommandName=="Delete")
			{
				CategoryService.Category_Delete(strCA);
				BindGrid();
			}
		}
		protected void lbtBack_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = false;
			pnShow.Visible = true;
			Insert=false;
		}
		protected void lbtUpdate_Click(object sender, EventArgs e)
		{
			string image = Session["upload"] == null ? "" : Session["upload"].ToString();
			#region[TestInput]
			if (txtName.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Name is required!");
				txtName.Focus();
				return;
			}
			/*if (txtContents.Text.Trim().Equals(""))
			{
				WebMsgBox.Show("Contents không thể trống !");
				txtContents.Focus();
				return;
			}/*
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
			obj.Content = txtContent.Text;
            obj.Images = Session["upload"].ToString();
			//obj.Ord = txtOrd.Text;
            obj.Status = ddlStatus.SelectedValue;
            obj.Parent_Id = txtParent_Id.Text;
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
		}
		protected void grdCategory_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdCategory.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		protected void grdCategory_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			ListItemType itemType = e.Item.ItemType;
			if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
			{
				if (itemType == ListItemType.Header)
				{
					object checkBox = e.Item.FindControl("chkSelectAll");
					if ((checkBox != null))
					{
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
					}
				}
				else
				{
					string tableRowId = grdCategory.ClientID + "_row" + e.Item.ItemIndex.ToString();
					e.Item.Attributes.Add("id", tableRowId);
					object checkBox = e.Item.FindControl("chkSelect");
					if (checkBox != null)
					{
						e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
						e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex + ")");
						((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex + ")");
					}
				}
			}
		}
	}
}