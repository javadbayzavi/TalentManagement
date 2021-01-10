namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_intelligences
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? spatial_awareness { get; set; }

        public int? tactical_knowledge { get; set; }

        public int? risk_assessment { get; set; }

        public virtual player player { get; set; }
    }
}
