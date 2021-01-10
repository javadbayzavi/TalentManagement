using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class session_costs
    {
        public int session_id { get; set; }

        public training_terms training_terms { get; set; }

        public int session_closed { get; set; }

        public string session_date 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.se_date).ToString());
            }
            set
            {
                this.se_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }
        public int se_date { get; set; }
        public int registerantscount { get; set; }

        public System.Double baseprice { get; set; }
    }
}