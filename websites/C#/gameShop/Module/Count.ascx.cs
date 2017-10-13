using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gameShop.Module
{
    public partial class Count : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCounter.Text = Application["Counter"].ToString();
            lblOnline.Text = Application["Online"].ToString();
        }
    }
}