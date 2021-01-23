namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class metrics
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like number of passes
        [Required]
        [StringLength(150)]
        public string name { get; set; }
        // some description about this metric
        public string tips { get; set; }
        
        // Direction of the metric (Asc , Desc)
        public int direction { get; set; }
        
        // The Upper Bound of the metric definition
        public string upperBound { get; set;}

        // The Lower Bound of the metric definition
        public string lowerBound { get; set;}
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<metric_instances> instances { get; set; }
        
    }
}
