using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Text;

namespace gameShop.Common
{
    public class DateTimeClass
    {
        public static string DatePicker(TextBox htmlHelper, string name, string value)
        {
            return "<script type=\"text/javascript\">" +
                     "$(function() {" +
                     "$(\"#" + name + "\").datepicker();" +
                     "});" +
                     "</script>" +
                     "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";
        }

        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="Date">string Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(string Date)
        {
            return ConvertDate(Date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="Date">string Date to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(string Date, string DateFormat)
        {
            DateTime dt = Convert.ToDateTime(Date);
            return dt.ToString(DateFormat);
        }

        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="Date">Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(DateTime Date)
        {
            return ConvertDate(Date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="Date">Date</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(DateTime Date, string DateFormat)
        {
            return Date.ToString(DateFormat);
        }

        public static DateTime Convert2Date(string Date)
        {
            DateTime dt = Convert.ToDateTime(Date);
            return dt;
        }

        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="DateTime">string Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(string DateTimes) 
        {
            try
            {
                if (DateTimes.Length == 0)
                {
                    DateTimes = DateTime.Now.ToString();
                }
                else
                {
                    //DateTimes = DateTimes;
                }
                return ConvertDateTime(DateTimes, "dd/MM/yyyy hh:mm:ss tt");
            }
            catch 
            {
                return DateTimes;
            }
        }
        public static string ConvertDateTime_hhmm(string DateTime)
        {
            try
            {
                return ConvertDateTime(DateTime, "hh:mm");
            }
            catch
            {
                return DateTime;
            }
        }
        public static string ConvertDateTime_ddmmyyyy(string DateTime)
        {
            try
            {
                return ConvertDateTime(DateTime, "dd/MM/yyyy");
            }
            catch
            {
                return DateTime;
            }
        }
        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="DateTime">string Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(string DateTime, string DateFormat)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = Convert.ToDateTime(DateTime);
            }
            catch { }
            return dt.ToString(DateFormat);
        }

        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(DateTime DateTime)
        {
            return ConvertDateTime(DateTime, "dd/MM/yyyy HH:mm:ss tt");
        }
        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(DateTime DateTime, string DateFormat)
        {
            return DateTime.ToString(DateFormat);
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="Time">string Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(string Time) 
        {
            return ConvertTime(Time, "HH:mm:ss");
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="Time">string Time to convert</param>
        /// <param name="TimeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(string Time, string TimeFormat)
        {
            DateTime dt = Convert.ToDateTime(Time);
            return dt.ToString(TimeFormat);
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="Time">Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(DateTime Time)
        {
            return ConvertTime(Time, "HH:mm:ss");
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="Time">Time to convert</param>
        /// <param name="TimeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(DateTime Time, string TimeFormat)
        {
            return Time.ToString(TimeFormat);
        }

        public static string DayOfWeek(string Date)
        {
            DateTime dt= new DateTime();
            try
            {
                dt = Convert.ToDateTime(Date);
            }
            catch { }
            return DayOfWeek(dt);
        }

        public static string DayOfWeek(DateTime Date)
        {
            string strReturn = "";
            switch (Date.DayOfWeek.ToString())
            {
                case "Sunday":
                    strReturn = "Sunday";
                    break;
                case "Monday":
                    strReturn = "Monday";
                    break;
                case "Tuesday":
                    strReturn = "Tuesday";
                    break;
                case "Wednesday":
                    strReturn = "Wednesday";
                    break;
                case "Thursday":
                    strReturn = "Thursday";
                    break;
                case "Friday":
                    strReturn = "Friday";
                    break;
                case "Saturday":
                    strReturn = "Saturday";
                    break;  
            }
            return strReturn;
        }
        public static string DayOfWeekTuanvd(DateTime Date, string lang)
        {
            string strReturn = "";
            if (lang == "vi")
            {
                switch (Date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        strReturn = "Chủ nhật";
                        break;
                    case "Monday":
                        strReturn = "Thứ 2";
                        break;
                    case "Tuesday":
                        strReturn = "Thứ 3";
                        break;
                    case "Wednesday":
                        strReturn = "Thứ 4";
                        break;
                    case "Thursday":
                        strReturn = "Thứ 5";
                        break;
                    case "Friday":
                        strReturn = "Thứ 6";
                        break;
                    case "Saturday":
                        strReturn = "Thứ 7";
                        break;
                }
            }
            else
            {
                switch (Date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        strReturn = "Sunday";
                        break;
                    case "Monday":
                        strReturn = "Monday";
                        break;
                    case "Tuesday":
                        strReturn = "Tuesday";
                        break;
                    case "Wednesday":
                        strReturn = "Wednesday";
                        break;
                    case "Thursday":
                        strReturn = "Thursday";
                        break;
                    case "Friday":
                        strReturn = "Friday";
                        break;
                    case "Saturday":
                        strReturn = "Saturday";
                        break;
                }
            }
            return strReturn;
        }
    }
}
