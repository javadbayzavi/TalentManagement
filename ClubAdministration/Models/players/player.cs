namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public player()
        {
            player_bodyshapes = new HashSet<player_bodyshapes>();
            player_contacts = new HashSet<player_contacts>();
            player_intelligences = new HashSet<player_intelligences>();
            player_mindsets = new HashSet<player_mindsets>();
            player_payouts = new HashSet<player_payouts>();
            player_physical_fitness = new HashSet<player_physical_fitness>();
            player_posts = new HashSet<player_posts>();
            player_registerations = new HashSet<player_registerations>();
            player_sessions = new HashSet<player_sessions>();
            player_techniques = new HashSet<player_techniques>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(8)]
        public string name { get; set; }

        [StringLength(9)]
        public string familiy { get; set; }

        public int birthyear { get; set; }

        public int birthmonth { get; set; }

        [StringLength(4)]
        public string Technical_Foot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_bodyshapes> player_bodyshapes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_contacts> player_contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_mindsets> player_mindsets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_payouts> player_payouts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_physical_fitness> player_physical_fitness { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_posts> player_posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_registerations> player_registerations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_techniques> player_techniques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_intelligences> player_intelligences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player_sessions> player_sessions { get; set; }


        //NotMapped members
        public string fullname 
        { 
            get
            {
                return this.name + " " + this.familiy;
            }
        }
    }
}
