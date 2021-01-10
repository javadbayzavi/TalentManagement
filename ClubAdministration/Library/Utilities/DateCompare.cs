using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Utilities
{
    public class DateCompare
    {
        public static int Compare(string date1, string date2)
        {
            if (date1 != null && date2 != "")
            {
                DateTime d1 = DateTime.Parse(date1);
                DateTime d2 = DateTime.Parse(date2);
                if (d1 <= d2)
                    return 1;
                else
                    return 2;
            }
            else
                return 0;
        }
    }
}