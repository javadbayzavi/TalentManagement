using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Core.Sessions;
using System.Web;
using System.Web.Mvc;
namespace ClubAdministration.Library.Core.Pages
{
    public class BaseController : Controller
    {
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
            this.Theme = "professional";

            //Set current theme into Session
            Session[ReservedKeys.ThemeRoot] = this.Theme;

            base.ExecuteCore();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            //if (this.Authorised == false)
            //{
            //    if (Session[ReservedKeys.isAuthenticated].ToString() == "1")
            //    {
            //        Session["NotificationMessage"] = Message.AuthorizeError;
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
    }
}