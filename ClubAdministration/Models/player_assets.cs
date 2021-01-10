namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_assets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int asset_id { get; set; }

        public int delivery_date { get; set; }

        public int playerpayment_id { get; set; }

        public int deliveryback_date { get; set; }

        public virtual club_assets club_assets { get; set; }

        public virtual player_payouts player_payouts { get; set; }
    }
}
