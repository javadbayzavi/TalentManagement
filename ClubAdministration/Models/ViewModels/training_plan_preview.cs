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
        public long drill_dt { get; set; }
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
        public string daysofWeek { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string recureStart { get; set; }
        public string recureEnd { get; set; }
        public string classification { get; set; }
    }
}