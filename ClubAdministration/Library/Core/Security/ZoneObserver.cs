using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Security
{
    public enum source
    {
        Local,
        Remote
    }
    public enum secure
    {
        Secure,
        Plain
    }
    public enum target
    {
        anonymous,
        web,
        mobile,
        ios,
        android,
        api
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)]
    public class ZoneObserver : System.Attribute
    {
        private string zone;

        public ZoneObserver(string name)
        {
            this.zone = name;
        }
    }
}