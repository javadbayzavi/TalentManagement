namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class coach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public coach()
        {
            coach_certificates = new HashSet<coach_certificates>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string coach_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string coach_family { get; set; }

        public Int64 coach_bdate { get; set; }

        [NotMapped]
        public string coach_birthdate
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.coach_bdate).ToString());
            }
            set
            {
                this.coach_bdate = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public int coach_gender { get; set; }

        public Int64 reg_date { get; set; }

        [NotMapped]
        public string registeration_date 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.reg_date).ToString());
            }
            set
            {
                this.reg_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        [NotMapped]
        public string FullName {
            get 
            {
                return this.coach_name + " " + this.coach_family;
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coach_certificates> coach_certificates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coach_training> coach_trainings { get; set; }
    }
}
