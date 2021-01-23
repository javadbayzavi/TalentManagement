namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class metric_instances
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //The alias to the name of metric
        [StringLength(150)]
        public string alias { get; set; }
        
        // The baseline of the metric object
        public string baseline { get; set;}

        // The target of the metric object
        public string target { get; set;}

        // The frequency of the metric object
        public int frequency { get; set;}
       
        public int metric_id { get; set; }
        [ForeignKey("metric_id")]
        public metrics metric { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<metric_values> values { get; set; }
        
    }
}
