using System;
using System.Linq;
using System.Text;
using System.Web;

namespace gameShop.Common
{
    public class Encodingvmms
    {
        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKey = "!5623a#de";
        #region[Encode for URL]
        public static string Encode(string src)
        {
            byte[] b;
            try
            {
                b = Encoding.Unicode.GetBytes(EncryptionKey + src);
            }
            catch { return src; }
            return Convert.ToBase64String(b);

        }
        public static string Decode(string src)
        {
            byte[] b;
            try
            {
                b = Convert.FromBase64String(src);
                src = Encoding.Unicode.GetString(b);
                // src = src.Substring(0, src.Length - 9);
                src = src.Remove(0, 9);
            }
            catch { return src; }
            return src;

        }
        #endregion

    }
    public class UserMember : System.Web.UI.Page
    {
        static CookieClass cookie = new CookieClass();
        /// <summary>
        /// Luu thong tin cua user dang nhap vao cookie tu bien
        /// </summary>
        public static void SaveUserToCookie(string strFullName, string strUserName)
        {
            cookie.SetCookie("FullName", strFullName);
            cookie.SetCookie("UserName", strUserName);
            cookie.SetCookie("IsAdmin", "0");
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao cookie
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        /// <param name="Is admin of website"></param>
        public static void SaveUserToCookie(string strFullName, string strUserName, string strIsAdmin)
        {
            cookie.SetCookie("FullName", strFullName);
            cookie.SetCookie("UserName", strUserName);
            cookie.SetCookie("IsAdmin", strIsAdmin);
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao bien
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        public void SaveUserToVariable(string strFullName, string strUserName)
        {
            Session["FullName"] = strFullName;
            Session["UserName"] = strUserName;
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao bien
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        /// <param name="Is admin of website"></param>
        public static void SaveUserToVariable(string strFullName, string strUserName, string strIsAdmin)
        {
            //GlobalClass.FullName = strFullName;
            //GlobalClass.UserName = strUserName;
            //GlobalClass.IsAdmin = strIsAdmin;
        }
        /// <summary>
        /// Luu thong tin cua user tu cookie
        /// </summary>
        public static void GetUserVariableFromCookie()  
        {
            //GlobalClass.FullName = cookie.GetCookie("FullName").ToString();
            //GlobalClass.UserName = cookie.GetCookie("UserName").ToString();
            //GlobalClass.IsAdmin = cookie.GetCookie("IsAdmin").ToString();
        }
    }
}
