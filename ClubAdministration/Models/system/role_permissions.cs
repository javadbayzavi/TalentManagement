namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_permissions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        public string role_id { get; set; }

        [ForeignKey("role_id")]
        public roles role { get; set; }

        public int permission_id { get; set; }

        [ForeignKey("permission_id")]
        public permissions permission { get; set; }

    }   
}
