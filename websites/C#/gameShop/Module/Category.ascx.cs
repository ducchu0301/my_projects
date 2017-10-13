using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Business;

namespace gameShop.Module
{
    public partial class Category : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptCategory.DataSource = CategoryService.Category_GetByOption("Status = 1", "");
                rptCategory.DataBind();
            }
        }
    }
}