namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class drill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        [Required]
        public string drill_target { get; set; }

        [Required]
        [StringLength(350)]
        public string drill_title { get; set; }

        [Required]
        //the purpose of the drill
        public string drill_goals { get; set; }

        [Required]
        //procedure of the drill
        public string drill_execution { get; set; }

        [Required]
        //the different variations of a drill that can be executed
        public string drill_variations { get; set; }

        [Required]
        //A description that shows the enhancement tips for the drill
        public string drill_progression { get; set; }

        [Required]
        //tip and guidance for coaches during the drill execution
        public string drill_coachingtips { get; set; }

        [Required]
        public string drill_organization { get; set; }

        [Required]
        public string drill_competition { get; set; }

        //Things like Passing, Ball Control
        public int drill_emphasisid { get; set; }
        [ForeignKey("drill_emphasisid")]
        public drill_emphasises drill_emphasis { get; set; }

        [Required]
        public int agelevel_id { get; set; }
        [ForeignKey("agelevel_id")]
        public agelevel agelevel { get; set; }

        //Things like Beginner, Intermediate, Advanced
        public int drill_levelplay { get; set; }

        //Descripe drill sequence : Warmup, Progression, Main point / Emphasis
        public string drill_structure { get; set; }

        //Things like Individual, in pairs , etc
        [Required]
        public int drill_typeid { get; set; }

        [ForeignKey("drill_typeid")]
        public drill_types drill_type { get; set; }

        [Required]
        public int drill_playernumbers { get; set; }

        //Things like Whole team, Goalkeepers , etc
        [Required]
        public int participating_positionsid { get; set; }

        [ForeignKey("participating_positionsid")]
        public position participating_positions { get; set; }

        //Things like Any, Saloon, pitch, etc
        [Required]
        public int drill_locationid { get; set; }

        [ForeignKey("drill_locationid")]
        public drill_locations drill_location { get; set; }

        [Required]
        [StringLength(50)]
        public string drill_duration { get; set; }

        [Required]
        [StringLength(50)]
        public string drill_fieldsize { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<drill_materials> drillmaterials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<drill_skills> drillskills { get; set; }
    }
}
