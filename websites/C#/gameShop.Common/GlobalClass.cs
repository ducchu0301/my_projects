using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace gameShop.Common
{
    public class GlobalClass
    {
        #region[Declare variables]
        private static string _Mail_Smtp;
        private static string _Mail_Port;
        private static string _Mail_Info;
        private static string _Mail_Noreply;
        private static string _Mail_Password;
        private static string _PlaceHead;
        private static string _PlaceBody;
        private static string _GoogleId;
        private static string _Contact;
        private static string _Copyright;
        private static string _Title;
        private static string _Description;
        private static string _Keyword;
        private static string _Lang;
        #endregion
        #region[Public Properties]
        public static string Mail_Smtp { get { return _Mail_Smtp; } set { _Mail_Smtp = value; } }
        public static string Mail_Port { get { return _Mail_Port; } set { _Mail_Port = value; } }
        public static string Mail_Info { get { return _Mail_Info; } set { _Mail_Info = value; } }
        public static string Mail_Noreply { get { return _Mail_Noreply; } set { _Mail_Noreply = value; } }
        public static string Mail_Password { get { return _Mail_Password; } set { _Mail_Password = value; } }
        public static string PlaceHead { get { return _PlaceHead; } set { _PlaceHead = value; } }
        public static string PlaceBody { get { return _PlaceBody; } set { _PlaceBody = value; } }
        public static string GoogleId { get { return _GoogleId; } set { _GoogleId = value; } }
        public static string Contact { get { return _Contact; } set { _Contact = value; } }
        public static string Copyright { get { return _Copyright; } set { _Copyright = value; } }
        public static string Title { get { return _Title; } set { _Title = value; } }
        public static string Description { get { return _Description; } set { _Description = value; } }
        public static string Keyword { get { return _Keyword; } set { _Keyword = value; } }
        public static string Lang { get { return _Lang; } set { _Lang = value; } }
        #endregion
        static GlobalClass()
        {
       
        }

        static public String GetUrlUpload()
        {
            try
            {
                return ApplicationPath + "/Uploads";
            }
            catch { return ""; }
        }

        static public String GetUrlScripts()
        {
            try
            {
                return ApplicationPath + "/Scripts";
            }
            catch { return ""; }
        }
        static public String GetUrlAdminStyle() 
        {
            try
            {
                return ApplicationPath + "/App_Themes/Admin/";
            }
            catch { return ""; }
        }
        static public String GetUrlAdminImage() 
        {
            try
            {
                return ApplicationPath + "/App_Themes/Admin/Images/";
            }
            catch { return ""; }
        }
        //static public string PhysicalApplicationPath 
        //{
        //    get
        //    {
                
        //        return HttpContext.Current.Request.PhysicalApplicationPath.ToString();
        //    }
        //}
        static public string ApplicationPath
        {

            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;
                if (applicationPath == "/")
                {
                    return string.Empty;
                }
                else
                {
                    return applicationPath;
                }
            }

        }

        public static void ErrorMessage(string strError)
        {
            HttpContext.Current.Response.Redirect(ApplicationPath + "/error.aspx?error=" + strError);
        }

        static public String PhysicalApplicationPath()
        {
            return HttpContext.Current.Request.PhysicalApplicationPath.ToString();
        }

        static public String PhysicalApplicationPath(string Path)
        {
            return PhysicalApplicationPath() + Path.Replace("/","\\");
        }
    }
}
