using System;
using System.Web.UI.WebControls;

namespace gameShop.Admins
{
    public partial class Administrator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rule"] == null) Response.Redirect("~/Admins/Login.aspx");
            if (Session["Username"] != null)
            {
                if (int.Parse(Session["Rule"].ToString()) == 1)
                    lbthoten.Text = "Hi : " + Session["Username"] + " - Administrator";
                else lbthoten.Text = "Hi : " + Session["Username"] + " - Employees";
            }
        }

        protected void Linkbutton_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            Response.Redirect("~/Admins/" + lbt.ID.Trim() + ".aspx");
        }
        protected void lbtthoat_Click(object sender, EventArgs e)
        {
            Session.Remove("Rule");
            Session.Remove("Username");
            Response.Redirect("~/Admins/Login.aspx");
        }
    }
}