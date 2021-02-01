namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class drill_template
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("pattern_id")]
        public drill_patterns pattern { get; set; }
        public int pattern_id { get; set; }

        public int numberofdays { get; set; }
    }
}
