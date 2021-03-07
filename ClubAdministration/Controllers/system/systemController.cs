using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Models;
using ClubAdministration.Models.system;
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers.system
{
    public partial class systemController : BaseController
    {
        //private clubAdminProxy db = new clubAdminProxy();

        // GET: system
        [HttpGet]
        public ActionResult Index()
        {
            var security_overview = new security_overviews()
            {
                groups = db.groups.Take(10).ToList(),
                roles = db.roles.Take(10).ToList(),
                permissions = db.permissions.Take(10).ToList()
            };
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(security_overview);
        }

        public JsonResult getPermissions()
        {
            var permissions = db.permissions.Take(10);
            return new JsonResult { Data = permissions, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }

        public JsonResult getRoles()
        {
            var roles = db.roles.Take(10);
            return new JsonResult { Data = roles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getGroups()
        {
            var groups = db.groups.Take(10);
            return new JsonResult { Data = groups, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}