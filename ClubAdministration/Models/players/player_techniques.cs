namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_techniques
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? ball_control { get; set; }

        public int? driblling_skills { get; set; }

        public int? pass_accuracy { get; set; }

        public int? body_control { get; set; }

        public virtual player player { get; set; }
    }
}
