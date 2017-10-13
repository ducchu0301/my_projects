using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gameShop.Module
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Session["Search"] = txtSearch.Text;
            Response.Redirect("/Search/");
        }
        
    }
}