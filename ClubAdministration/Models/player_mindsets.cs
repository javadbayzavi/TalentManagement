namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_mindsets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? passion_love { get; set; }

        public int? composure_mentalstrength { get; set; }

        public int? coachability { get; set; }

        public int? self_motivation { get; set; }

        public virtual player player { get; set; }
    }
}
