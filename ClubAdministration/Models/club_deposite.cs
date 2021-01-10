namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class club_deposite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public club_deposite()
        {
            player_payouts = new HashSet<player_payouts>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(200)]
        public string payment_item { get; set; }

        public int payment_fee { get; set; }

        public int payment_type { get; set; }

        public int payment_method { get; set; }

        [NotMapped]
        public string payment_date {
            get 
            { 
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.pa_date).ToString());
            }
            set 
            { 
                this.pa_date = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public Int64 pa_date { get; set; }
        [StringLength(50)]
        public string payment_group { get; set; }

        public int payment_order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_payouts> player_payouts { get; set; }

        public int category_id { get; set; }

        public virtual payment_category payment_category { get; set; }

        public int bankaccount_id { get; set; }

        public virtual club_bankaccounts club_bankaccount { get; set; }

    }
}
