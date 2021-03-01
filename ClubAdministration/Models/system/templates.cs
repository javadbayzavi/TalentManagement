namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class templates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string title { get; set; }   
    }
}
