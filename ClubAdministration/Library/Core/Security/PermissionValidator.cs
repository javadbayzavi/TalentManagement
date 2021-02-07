using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Security
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)]
    public class PermissionValidator : System.Attribute
    {
        private string name;
        public string method;

        public PermissionValidator(string name)
        {
            this.name = name;
            method = "get";
        }
    }
}