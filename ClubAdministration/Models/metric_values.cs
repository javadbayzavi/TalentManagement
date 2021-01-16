namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class metric_values
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like number of passes
        [Required]
        [StringLength(150)]
        public string value { get; set; }
        // the date that metric value has updated / initiated
        public int modified_date { get; set; }
        [ForeignKey("instance_id")]
        public metric_instances instance { get; set; }
        public int instance_id { get; set; }
        
    }
}
