namespace ClubAdministration.Models.ViewModels
{
    using ClubAdministration.Library.Core.Defaults;
    using ClubAdministration.Library.Utilities;
    using ClubAdministration.Models.system;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class security_overviews
    {
        public virtual ICollection<groups> groups { get; set; }
        public virtual ICollection<roles> roles { get; set; }
        public virtual ICollection<permissions> permissions { get; set; }

    }
}
