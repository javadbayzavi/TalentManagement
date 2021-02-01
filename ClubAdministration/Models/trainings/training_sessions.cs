namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class training_sessions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? trainingterms_id { get; set; }

        [NotMapped]
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

        public Int64 se_date { get; set; }

        public string start_time { get; set; }

        public string end_time { get; set; }

        public int? attendance_number { get; set; }

        public int? session_closed { get; set; }
        public virtual training_terms training_terms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_sessions> participants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coach_sessions> coaches { get; set; }

    }
}
