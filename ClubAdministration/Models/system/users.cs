namespace ClubAdministration.Models.system
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Things like Ball-Control
        [Required]
        [StringLength(150)]
        public string name { get; set; }

        public string family { get; set; }

        public string user_name { get; set; }

        //Determine the originitiy of the user {local, remote (google,facebook)}
        public int user_host { get; set; }

        public string mobile_phone { get; set; }

        [NotMapped]
        public string fullName 
        { 
            get
            {
                return this.name + " " + this.family;
            }
        }

        public ICollection<user_groups> groups { get; set; }
    }
}
