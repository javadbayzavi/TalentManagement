using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class training_plan_preview
    {
        public int drill_id { get; set; }
        public string drill_title { get; set; }

        public int drill_hour { get; set; }
        public List<drill_view> drills { get; set; }
        public long drill_dt { get; set; }
        public string drill_datefa 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.drill_dt).ToString());
            }
            set
            {
                this.drill_dt = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }
        public DateTime drill_date
        {
            get
            {
                return BaseDate.SystemStartDateTime.AddMinutes(this.drill_dt);
            }
            set
            {
                this.drill_dt = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }
        public string DayofWeeks { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool repeatitve { get; set; }

    }
}