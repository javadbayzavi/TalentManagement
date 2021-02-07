namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class menus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        [Required]
        [StringLength(150)]
        public string title { get; set; }

        public string target { get; set; }

        public string palceholder { get; set; }

        [Required]
        public int parent { get; set; }

        [Required]
        [StringLength(150)]
        public string menuClass { get; set; }
        public bool isDefault { get; set; }
    }
}
