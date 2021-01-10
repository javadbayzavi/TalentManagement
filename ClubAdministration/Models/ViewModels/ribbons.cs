using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class ribbons
    {
        public string title { get; set; }

        public string controller { get; set; }

        public string action { get; set; }

        public string logsrc { get; set; }

        public string placeholder { get; set; }

        //Define whether user must have made a selection before form submission or not
        public bool selectionneeded { get; set; }

        //Root parameters are used to redirect to the destination path
        public object rootparam { get; set; }

        //Define whether the ribbon wants to submit the hostform or not
        public bool postback { get; set; }

        //Define whether a user can have multiple record selection
        public bool multiselect { get; set; }

        //Target form that the ribbon try to submit its data
        public string hostform { get; set; }
    }
}