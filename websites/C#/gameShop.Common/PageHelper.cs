using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace gameShop.Common
{
    public class PageHelper : System.Web.UI.UserControl
    {
        private string[] Separator = new string[] { ","};
        public static Control FindControl(Control Root, string Id) 
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControl(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }

        public static string ShowActiveImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "stop.png" : "start.png";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }

        public static string ShowCheckImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "check.gif" : "uncheck.gif";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }

        public static string ShowActiveToolTip(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Hide" : "Show";
        }

        public static string ShowActiveStatus(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Show" : "Hide";
        }

        public static void LoadDropDownList(DropDownList ddl, ArrayList array) 
        {
            ddl.DataSource = array;
            ddl.DataBind();
        }

        public static void LoadDropDownList(DropDownList ddl, string[] StringArray) 
        {
            LoadDropDownList(ddl, StringArray, false);
        }

        public static void LoadDropDownList(DropDownList ddl, string[] StringArray, bool ListItem)
        {
            if (ListItem){
                ddl.DataSource = StringArray2ListItem(StringArray);
                ddl.DataTextField = "Text";
                ddl.DataValueField = "Value";
                
            }else{
                ddl.DataSource = StringArray2ArrayList(StringArray);
            }
            ddl.DataBind();
        }

        public static List<ListItem> StringArray2ListItem(string[] StringArray) 
        {
            char[] splitter = { ',',';' };
            List<ListItem> list = new List<ListItem>();
            for (int i = 0; i < StringArray.Length; i++)
            {
                string[] arr = StringArray[i].Split(splitter);
                if (arr.Length > 1){
                    list.Add(new ListItem(arr[1], arr[0]));
                }
                else{
                    list.Add(new ListItem(arr[0], arr[0]));
                }
            }
            return list;
        }

        public static ArrayList StringArray2ArrayList(string[] StringArray)
        {
            ArrayList arrlist = new ArrayList();
            for (int i = 0; i < StringArray.Length; i++)
            {
                arrlist.Add(StringArray[i]);
            }
            return arrlist;
        }

        public static void LoadDropDownListTarget(DropDownList ddl) 
        {
            string[] myArr = new string[] { "_self", "_blank" };
            ddl.DataSource = StringArray2ArrayList(myArr);
            ddl.DataBind();
        }

        public static void LoadDropDownListNumber(DropDownList ddl, int BeginNumber, int EndNumber)
        {
            for (int i = BeginNumber; i <= EndNumber; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static void LoadDropDownListPosition(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Logo", "2,Banner", "3,Partners", "5,Advertise" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListYesNo(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Yes", "0,No" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListCoKhong(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Có", "0,Không" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListActive(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Yes", "0,No" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListPagePosition(DropDownList ddl) 
        {
            string[] myArr = new string[] { "1,Top Menu", "2,Main Menu", "3,Bottom Menu" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListPageType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Hyperlink", "2,Content Page"};
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListAdvertiseType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Image", "2,Content" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowPageType(string ActiveCode)
        {
            return ActiveCode == "1" ? "Hyperlink" : "Content Page";
        }

        public static void LoadDropDownListAreaType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Ground Area", "2,Ocean Area", "3,Orther Area" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowAreaType(string Type)
        {
            return Type == "1" ? "Ground Area" : Type == "2" ? "Ocean Area" : "Orther Are";
        }

        public static void LoadDropDownListSupportType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Yahoo messenger", "2,Skype", "3,Google talk" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowSupportType(string Type) 
        {
            return Type == "1" ? "Yahoo messenger" : Type == "2" ? "Skype" : "Google talk";
        }

        public static string GetContent(string URL)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string s = sr.ReadToEnd();
            //return sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return s;
        }

        public static string GetContent(string URL, string strStart, string strEnd)
        {
            string Content = GetContent(URL);
            int pStart = Content.IndexOf(strStart);
            int pEnd = Content.IndexOf(strEnd);
            string strReturn = Content.Substring(pStart, pEnd - pStart);
            return StripATag(strReturn);
        }
        public static string StripATag(string text)
        {
            return Regex.Replace(text, @"<a[^>]*?href\s*=\s*[""']?([^'"" >]+?)[ '""]?/?>|<.a*?>", string.Empty);
        }
    }
}
