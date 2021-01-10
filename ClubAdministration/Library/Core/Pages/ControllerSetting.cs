using ClubAdministration.Library.Core.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubAdministration.Library.Core.Pages
{
    public class ControllerSetting
    {
        public string SourceHost { 
            get {
                return this.parentController.Request.UserHostName;
            } 
        }
        public string SourceAddress { get { return this.parentController.Request.UserHostAddress; } }
        public int ReferredDateTime { get { return BaseDate.CalculateDateDiffInMinutes(DateTime.Now); } }
        public string Browser { get { return this.parentController.Request.UserAgent; } }
        public string OperatingSystem { get {  return ""; /*TODO: Need to be developed*/ } }
        public string OSVersion { get { return ""; /*TODO: Need to be developed*/ } }
        public string UserTimeZone { get { return ""; /*TODO: Need to be developed*/  } }
        public string SessionId { get { return this.parentController.Session.SessionID; } }
        public string ReferredAction { get { return this.parentController.Action; } }
        public string Protocol { get { return "";  /*TODO: Need to be developed*/ } }
        public string ProtocolMethod { get { return this.parentController.Request.HttpMethod; } }
        public int ContentSize { get { return this.parentController.Request.ContentLength; } }
        public string ContentType { get { return this.parentController.Request.ContentType; } }
        public BaseController parentController { get; set; }
        public PageSetting PageSetting { get; set; }
        public ControllerSetting(BaseController parent)
        {
            this.PageSetting = new PageSetting(parent);
            this.parentController = parent;
        }
    }
}
