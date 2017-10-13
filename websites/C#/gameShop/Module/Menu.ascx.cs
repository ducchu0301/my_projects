using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Business;

namespace gameShop.Module
{
    public partial class Menu : System.Web.UI.UserControl
    {
        private string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow aRow;
                DataColumn column;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Name";
                dt.Columns.Add(column);

                // Create second column.
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "Link";
                dt.Columns.Add(column);

                aRow =  dt.NewRow();
                aRow["Name"]="Home";
                aRow["Link"] = "/";
                dt.Rows.Add(aRow);

                

                aRow = dt.NewRow();
                aRow["Name"] = "Cart";
                aRow["Link"] = "/Cart/";
                dt.Rows.Add(aRow);
                
                LoadMenu(dt);
              
                ltrMenu.Text = s;
            }
        }
        public void LoadMenu(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += "\n<li><a href=\"" + dt.Rows[i]["Link"] + "\">" + dt.Rows[i]["Name"] + "</a></li>";
            }
        }
    }
}