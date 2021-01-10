namespace ClubAdministration.Models.ViewModels
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class drillinputmodel
    {
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
        
        public SelectList drill_emphasis { get; set; }

        [Required]
        public int agelevel_id { get; set; }
        public SelectList agelevel { get; set; }

        //Things like Beginner, Intermediate, Advanced
        public int drill_levelplay { get; set; }

        //Descripe drill sequence : Warmup, Progression, Main point / Emphasis
        public string drill_structure { get; set; }

        //Things like Individual, in pairs , etc
        [Required]
        public int drill_typeid { get; set; }

        public SelectList drill_type { get; set; }

        [Required]
        public int drill_playernumbers { get; set; }

        //Things like Whole team, Goalkeepers , etc
        [Required]
        public int participating_positionsid { get; set; }

        [Required]
        public SelectList participating_positions { get; set; }

        //Things like Any, Saloon, pitch, etc
        [Required]
        public int drill_locationid { get; set; }

        public SelectList drill_location { get; set; }

        [Required]
        [StringLength(50)]
        public string drill_duration { get; set; }

        [Required]
        [StringLength(50)]
        public string drill_fieldsize { get; set; }
        public SelectList drillmaterials { get; set; }
        public SelectList drillskills { get; set; }
    }
}
