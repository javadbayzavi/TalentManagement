using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Core.Sessions;
using ClubAdministration.Library.Core.Security;
using ClubAdministration.Models;
using System.Web;
using System.Web.Mvc;
using System;

namespace ClubAdministration.Library.Core.Pages
{
    [ZoneObserver("BaseController")]
    public class BaseController : Controller
    {
        protected clubAdminProxy db = new clubAdminProxy();
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public ControllerSetting Setting { get; set; }
        public bool Authorised { get; set; }
        public string Theme { get; set; }
        protected override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            base.Execute(requestContext);
        }
        protected override void ExecuteCore()
        {
            this.Area = (ControllerContext.RouteData.DataTokens[ReservedKeys.Area] == null) ? "" : ControllerContext.RouteData.DataTokens[ReservedKeys.Area].ToString();
            this.Controller = ControllerContext.RouteData.Values[ReservedKeys.Controller].ToString();
            this.Action = ControllerContext.RouteData.Values[ReservedKeys.Action].ToString();
            this.Setting = new ControllerSetting(this);

            this.identifyuser();

            //this.initUserSession();

            //TODO: this item need to be studied in more dept
            int culture = 0;
            if (this.Session == null || this.Session[ReservedKeys.CurrentCulture] == null)
            {
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings[ReservedKeys.Culture], out culture);
                this.Session[ReservedKeys.CurrentCulture] = culture;
            }
            else
            {
                culture = (int)this.Session[ReservedKeys.CurrentCulture];
            }

            //
            SessionManager.CurrentCulture = culture;

            //if (RegisterPermission(this.Controller, this.Action))
            //{
            //    if (CheckPermission(Session[ReservedKeys.UserSessionName].ToString(), this.Controller, this.Action))
            //    {
            //        this.Authorised = true;
            //    }
            //    else
            //    {
            //        this.Authorised = false;
            //    }
            //}

            //Load current selected theme for this controller's view
            //var item = db.templates.Where(i => i.isdefault == true && i.admin == true).FirstOrDefault().address;
            //this.Theme = item;

            //Set current theme into Session
            Session[ReservedKeys.ThemeRoot] = this.Theme;

            base.ExecuteCore();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //if (this.Authorised == false)
            //{
            //    if (Session[ReservedKeys.isAuthenticated].ToString() == "1")
            //    {
            //        Session[ReservedKeys.TransactionResult] = "LoginFailed";
            //        filterContext.Result = new RedirectResult("~/Index/Index", true);
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult("~/Login/Login", true);
            //    }
            //    return;
            //}
        }
        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
        protected void loadPermission(string userid)
        {
            //load permissions from db
        }

        public void identifyuser()
        {
            if(this.Session[ReservedKeys.UserSessionName] != null)
            {
                //User Authenticated

            }
            else
            {
                //User unAuthenticated
            }

            //Identify permission
            //1. Identify user Indetity
            //2. Identify user zone
            //3. Identify user service

            this.loadPermission("");
        }
        public void indentifyzone()
        {
            string userip = Request.UserHostAddress;
            if (Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        Response.Write("visited Localhost!");
                    }
                    else
                    {
                        Response.Write("visited Remote!");
                    }
                }
            }
        }
        public void indentifyservice()
        {
            //Check the requested controller and underlying actions with registered service

        }

    }
}