using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models
{
    public class training_fees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? trainingterm_id { get; set; }

        public System.Double? fee { get; set; }

        [NotMapped]
        public string apply_date 
        {
            get 
            { 
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.ap_date).ToString());
            }
            set 
            { 
                this.ap_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public Int64 ap_date { get; set; }
        public training_terms training_term { get; set; }
    }
}