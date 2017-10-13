using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
namespace gameShop
{
    public class Global : System.Web.HttpApplication
    {
        private void RegisterRouter(RouteCollection Route)
        {
            RouteTable.Routes.MapPageRoute("Category", "Category/{gid}/", "~/Category.aspx");
            RouteTable.Routes.MapPageRoute("ProductDetail", "ProductDetail/{gid}/{id}/", "~/ProductDetail.aspx");
            RouteTable.Routes.MapPageRoute("OrderDetail", "Admins/OrderDetail/{oid}/", "~/Admins/OrderDetail.aspx");
            RouteTable.Routes.MapPageRoute("Cart", "Cart/", "~/Cart.aspx");
            RouteTable.Routes.MapPageRoute("Search", "Search/", "~/Search.aspx");
            RouteTable.Routes.MapPageRoute("Register", "Register/", "~/Register.aspx");
            RouteTable.Routes.MapPageRoute("Checkout", "Checkout/", "~/Checkout.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRouter(RouteTable.Routes);
            Application.Lock();
            //Check if exist file Count.txt
            //Not, create file
            if (!System.IO.File.Exists(Server.MapPath("~/Count.txt")))
                System.IO.File.WriteAllText(Server.MapPath("~/Count.txt"), "0");
            //Yes, Read file
            Application["counter"] =
            int.Parse(System.IO.File.ReadAllText(Server.MapPath("~/Count.txt")));
            Application.UnLock();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        
        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Application.Lock();
            // +1 view count
            Application["counter"] = int.Parse(Application["counter"].ToString())
            + 1;
            Application.UnLock();
            //to file
            System.IO.File.WriteAllText(Server.MapPath("~/Count.txt"),
            Application["counter"].ToString());
            //Online
            //
            Application.Lock();
            if (Application["Online"] == null)// if not exist
                Application["Online"] = 1;
            else
                Application["Online"] = int.Parse(Application["Online"].ToString()) + 1;
            Application.UnLock();
        }


        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            Application.Lock();
            Application["Online"] = int.Parse(Application["Online"].ToString()) - 1;
            Application.UnLock();
        }

    }
    
}
