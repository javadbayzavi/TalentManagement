namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class roles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        [Required]
        [StringLength(150)]
        public string title { get; set; }

        public virtual ICollection<role_permissions> permissions { get; set; }
        public virtual ICollection<group_roles> groups { get; set; }
    }
}
