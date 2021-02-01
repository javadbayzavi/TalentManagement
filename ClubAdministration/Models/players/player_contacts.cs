namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public long? phone { get; set; }

        [StringLength(2)]
        public string address { get; set; }

        public virtual player player { get; set; }
    }
}
