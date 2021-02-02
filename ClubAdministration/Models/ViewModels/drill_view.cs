using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class drill_view
    {
        public int drill_id { get; set; }
        public string drill_title { get; set; }

        public int drill_hour { get; set; }
    }
}