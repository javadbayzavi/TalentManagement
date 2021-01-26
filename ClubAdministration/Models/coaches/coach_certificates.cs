namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class coach_certificates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int coach_id { get; set; }

        [Required]
        [StringLength(200)]
        public string certificate_title { get; set; }

        public Int64 cert_date { get; set; }

        public Int64 cert_expdate { get; set; }

        [NotMapped]
        public string certificate_date 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.cert_date).ToString());
            }
            set
            {
                this.cert_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        [NotMapped]
        public string certificate_expiredate 
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.cert_expdate).ToString());
            }
            set
            {
                this.cert_expdate = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }


        [ForeignKey("coach_id")]
        public virtual coach coach { get; set; }

        public int issuer_id { get; set; }

        [ForeignKey("issuer_id")]
        public certificates_issuer issuer { get; set; }

        [ForeignKey("level_id")]
        public certificates_levels level { get; set; }
        public int level_id { get; set; }
    }
}
