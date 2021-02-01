namespace ClubAdministration.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_physical_fitness
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? endurance { get; set; }

        public int? balance_coordination { get; set; }

        public int? speed { get; set; }

        public int? stength_power { get; set; }

        public virtual player player { get; set; }
    }
}
