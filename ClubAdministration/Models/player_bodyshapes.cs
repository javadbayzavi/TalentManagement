namespace ClubAdministration.Models
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player_bodyshapes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? player_id { get; set; }

        public int? height { get; set; }

        public int? weight { get; set; }

        public Int64 datereg { get; set; }

        [NotMapped]
        public string examin_date
        {
            get
            {
                return DateConvertor.ConvertToPersian(BaseDate.GetDateFromDateOffsetSystemStartDate(this.datereg).ToString());
            }
            set
            {
                this.datereg = BaseDate.CalculateDateDiffInMinutes(value);
            }
        }

        public virtual player player { get; set; }
    }
}
