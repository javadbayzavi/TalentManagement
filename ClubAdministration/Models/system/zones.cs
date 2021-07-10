namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class zones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string title { get; set; }
        public bool local { get; set; }

        //Determine the access to service must be directed through https request
        public bool secured { get; set; }

        //Determine the access to service can be directed from api service (for mobile app users)
        public bool remote { get; set; }

        //net mask of the valid Ip address that have access to this zone
        public string netmask { get; set; }

    }
}
