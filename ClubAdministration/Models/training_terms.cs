namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class training_terms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(200)]
        public string term_title { get; set; }

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

        public int? max_player { get; set; }

        public int? session_per_week { get; set; }

        [StringLength(27)]
        public string weekdays { get; set; }

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

        public int? fee_type { get; set; }

        public int? active { get; set; }

        public long s_date { get; set; }

        public long e_date { get; set; }

        public string start_time { get; set; }

        public string end_time { get; set; }


        [ForeignKey("level_id")]
        public agelevel agelevel { get; set; }
        public int level_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_registerations> player_registerations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_fees> training_fees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_sessions> training_sessions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coach_training> coach_training { get; set; }
    }
}
