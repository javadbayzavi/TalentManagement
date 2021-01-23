namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class coach_training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int coach_id { get; set; }

        public int training_id { get; set; }

        [NotMapped]
        public string registeration_date 
        { 
            get 
            { 
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.re_date).ToString());
            }
            set
            {
                this.re_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public Int64 re_date { get; set; }
        [NotMapped]
        public string resignation_date
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.ree_date).ToString());
            }
            set
            {
                this.ree_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public Int64 ree_date { get; set; }

        [ForeignKey("coach_id")]
        public virtual coach coach { get; set; }

        [ForeignKey("training_id")]
        public virtual training_terms training_terms { get; set; }
    }
}
