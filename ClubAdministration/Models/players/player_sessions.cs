namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_sessions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? session_id { get; set; }

        [StringLength(50)]
        public string hour_in { get; set; }

        [StringLength(50)]
        public string hour_out { get; set; }

        public virtual player player { get; set; }

        public virtual training_sessions session { get; set; }
    }
}
