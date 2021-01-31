namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class training_patterns
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("training_id")]
        public training_terms training { get; set; }
        public int training_id { get; set; }

        [ForeignKey("pattern_id")]
        public drill_patterns pattern { get; set; }
        public int pattern_id { get; set; }

        public int s_date { get; set; }
        [NotMapped]
        public string start_date 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.s_date).ToString());
            }
            set
            {
                this.s_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }


        public int e_date { get; set; }
        [NotMapped]
        public string end_date 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.e_date).ToString());
            }
            set
            {
                this.e_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }
        public int order { get; set; }
    }
}
