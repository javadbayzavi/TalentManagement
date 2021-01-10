using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class menuitems
    {
        public string title { get; set; }

        public string controller { get; set; }

        public string action { get; set; }

        public bool active { get; set; }
    }
}