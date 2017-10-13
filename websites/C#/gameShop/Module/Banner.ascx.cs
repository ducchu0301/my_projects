using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gameShop.Business;

namespace gameShop.Module
{
    public partial class Banner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgBanner.ImageUrl = "/Images/banner.png";
            }
        }
    }
}