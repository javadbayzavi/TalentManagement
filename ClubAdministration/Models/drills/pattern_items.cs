namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pattern_items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("pattern_id")]
        public drill_patterns pattern { get; set; }
        public int pattern_id { get; set; }

        [ForeignKey("drill_id")]
        public drill drill { get; set; }
        public int drill_id { get; set; }

        //This field indicates whether drill will be periodically placed in sessions or not
        public bool periodic { get; set; }

        //The order of the drill in pattern
        public int orders { get; set; }

        public int weekday { get; set; }

        //This filed determine mirning training session or evening session
        public int drill_hour { get; set; }
    }
}
