using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Security
{
    public enum source
    {
        All,
        Local,
        Remote
    }
    public enum secure
    {
        Either,
        Secure,
        Plain
    }
    public enum target
    {
        Anonymous,
        Web,
        Mobile,
        IOS,
        Android,
        API
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct |
                           System.AttributeTargets.Method)]
    public class ZoneObserver : System.Attribute
    {
        private string zone;
        public source src { get; set; }
        public secure sec { get; set; }
        public target trgt { get; set; }

        public ZoneObserver(string name,source source = source.All, secure secure = secure.Either, target target = target.Anonymous)
        {
            this.src = source;
            this.trgt = target;
            this.sec = secure;
            this.zone = name;
        }
    }
}