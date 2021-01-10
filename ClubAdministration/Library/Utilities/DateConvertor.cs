using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Utilities
{
    public class DateConvertor
    {
        public static string ConvertToPersian(string date)
        {
            if (date != null && date != "")
            {
                DateTime d = DateTime.Parse(date);
                PersianCalendar pc = new PersianCalendar();
                return string.Format("{0}/{1}/{2} {3}:{4}:{5}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), 
                    pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d));
            }
            else
                return "";
        }
    }
}