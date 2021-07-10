namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class permissions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        [Required]
        [StringLength(150)]
        public string title { get; set; }
        public string command { get; set; }
        public int parent { get; set; }

        [ForeignKey("zone_id")]
        public zones zone { get; set; }
        public int zone_id { get; set; }

        [ForeignKey("service_id")]
        public services service { get; set; }
        public int service_id { get; set; }

        public virtual ICollection<role_permissions> roles { get; set; }
    }
}
