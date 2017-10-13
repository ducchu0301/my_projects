using System;
using System.Web;

namespace gameShop.Common
{
    public class ViewStateClass : System.Web.UI.UserControl 
    {
        /// <summary>
        /// Get a ViewState name
        /// </summary>
        /// <param name="ViewStateName">Name of ViewState</param>
        /// <returns></returns>
        public object viewState(string ViewStateName)  
        {
            return ViewState[ViewStateName];
        }
        /// <summary>
        /// Set a value for ViewState name
        /// </summary>
        /// <param name="ViewStateName">Name of ViewState</param>
        /// <param name="ViewStateValue">Value to set</param>
        public void viewState(string ViewStateName, string ViewStateValue) 
        {
               ViewState[ViewStateName] = ViewStateValue != null?ViewStateValue:null;
        }
    }
}
