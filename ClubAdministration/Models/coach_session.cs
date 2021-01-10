namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class coach_sessions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int coach_id { get; set; }

        public int session_id { get; set; }

        [ForeignKey("coach_id")]
        public virtual coach coach { get; set; }

        [ForeignKey("session_id")]
        public virtual training_sessions session { get; set; }
    }
}
