using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Security
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct |
                           System.AttributeTargets.Method |
                           System.AttributeTargets.Field |
                           System.AttributeTargets.Property)]
    public class PermissionValidator : System.Attribute
    {
        private string name;

        public PermissionValidator(string name)
        {
            this.name = name;
        }
    }
}