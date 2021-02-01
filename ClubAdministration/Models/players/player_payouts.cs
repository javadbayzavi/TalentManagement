namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_payouts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public player_payouts()
        {
            player_assets = new HashSet<player_assets>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? clubdeposite_id { get; set; }

        [NotMapped]
        public string billed_date
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.bl_date).ToString());
            }
            set
            {
                this.bl_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }


        public int? fee_status { get; set; }

        public long bl_date { get; set; }

        public virtual club_deposite club_deposite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_assets> player_assets { get; set; }

        public virtual player player { get; set; }
    }
}
