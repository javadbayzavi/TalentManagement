using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Security
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct |
                           System.AttributeTargets.Method)]
    public class ServiceValidator : System.Attribute
    {
        private string feature;

        public ServiceValidator(string name)
        {
            this.feature = name;
        }
    }
}