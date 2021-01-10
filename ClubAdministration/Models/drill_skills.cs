namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class drill_skills
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        //the purpose of the drill
        public int skill_id { get; set; }
        [ForeignKey("skill_id")]
        public skill skill { get; set; }

        [Required]
        public int drill_id { get; set; }
        [ForeignKey("drill_id")]
        public drill drill { get; set; }
    }
}
