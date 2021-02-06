using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClubAdministration.Library.Core.Defaults
{
  public class BaseDate
    {
      public const string DateSeparator = "/";
      public const string TimeSeparator = ":";
      public const string DateTimeValidFormat = "mm" + DateSeparator + "dd" + DateSeparator + "yyyy " + "hh" + TimeSeparator + "mm";
      public static DateTime SystemStartDateTime = new DateTime(2019, 11, 1, 0, 0, 0, 0);
      public int FirstDayofWeek = 0;

      public static DateTime GetDateFromDateOffsetSystemStartDate(Int64 offset)
      {
            return SystemStartDateTime.AddMinutes(offset);
      }
      /**
       * Return different date from system default date to current date in minutes
       **/
      public static int CalculateDateDiffInMinutes(DateTime endPoint)
      {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            return Convert.ToInt32(Math.Round((endPoint - BaseDate.SystemStartDateTime).TotalMinutes).ToString());
      }
      public static int CalculateDateDiffInMinutes(string endPoint)
      {
            if(endPoint != null && endPoint != "")
            {
                PersianCalendar pc = new PersianCalendar();
                string[] dateparts = endPoint.Split('/', ':', ' ').Where(a => a != null && a != "").ToArray();
                DateTime gd = pc.ToDateTime(Convert.ToInt32(dateparts[0]), Convert.ToInt32(dateparts[1]),
                    Convert.ToInt32(dateparts[2]), Convert.ToInt32(dateparts[3]),
                    Convert.ToInt32(dateparts[4]), Convert.ToInt32(dateparts[5]),0);
                return CalculateDateDiffInMinutes(gd);
            }
            return 0;
      }
      //Result format yyyy mm dd hh mm
      public static int[] changeStingPersianDateToIntDate(string entryDate)
      {
          int[] res = new int[3];
          res[0] = Int32.Parse(entryDate.Substring(0, 4));
          res[1] = Int32.Parse(entryDate.Substring(5, 2));
          res[2] = Int32.Parse(entryDate.Substring(8, 2));
          return res;
      }
      //Result format hh mm
      public static int[] changeStingTimeToIntTime(string entryTime)
      {
          int[] res = new int[2];
          res[0] = Int32.Parse(entryTime.Substring(0, 2));
          res[1] = Int32.Parse(entryTime.Substring(3, 2));
          return res;
      }
      public static string DefaultHour()
      {
          return "00" + TimeSeparator + "00";
      }
    }
}
