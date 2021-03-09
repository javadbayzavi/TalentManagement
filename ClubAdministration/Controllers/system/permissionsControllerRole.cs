using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Defaults;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Models;
using ClubAdministration.Models.system;

namespace ClubAdministration.Controllers.system
{
    //List of all commands
    //GET roles/permissions Show the list of
    public partial class rolesController : BaseController
    {
        //GET roles/permissions/5 Return the subscriptions for player with ID 5
        public ActionResult permissions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var permissions = db.role_permissions.Where(e => e.role_id == id).Include(a => a.permission).Include(a => a.role)
                .Where(a => a.permission.title.Contains(this.Setting.PageSetting.SearchItem) ||
                a.permission.command.Contains(this.Setting.PageSetting.SearchItem));
            var role = db.roles.Find(id);
            ViewBag.role = role;

            return View(permissions);
        }
        //GET: roles/deletePermission/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult detailsPermission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            role_permissions r_p = db.role_permissions.Where(a => a.ID == id).Include(a => a.permission).Include(a => a.role).FirstOrDefault();

            if (r_p == null)
            {
                //TODO : define styled error response through logging
                return HttpNotFound();
            }

            return View(r_p);
        }

        [HttpPost, ActionName("permissions")]
        public ActionResult permissionsPostBack(int id)
        {
            return this.permissions(id);
        }

        //GET roles/addPermission/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult addPermission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = db.roles.Find(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var perms = db.permissions.Select(a => 
                new SelectListItem()
                {
                    Text = a.title,
                    Value = a.ID.ToString(),
                    Selected = a.roles.Any(aa => aa.role_id == role.ID && aa.permission_id == a.ID)
                }
                ); 
                //new SelectList(db.permissions, "ID", "title");


            ViewBag.permission_id = perms;
            ViewBag.role = role;
            return View();
        }

        //POST roles/addPermission/5 
        [HttpPost, ActionName("addPermission")]
        [ValidateAntiForgeryToken]
        public ActionResult addPermission([Bind(Include = "role_id,permission_id")] role_permissionsinput r_p)
        {
            string[] permissions = this.Request["permissionsid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(a => a != "false").ToArray(); 
            if (ModelState.IsValid)
            {
                for (int index = 0; index < permissions.Length; index++)
                {
                    int perID = Int32.Parse(permissions[index]);
                    //Check for repeatitve entry
                    if (db.role_permissions.Any(a => a.role_id == r_p.role_id && a.permission_id == perID))
                    {
                        continue;
                    }

                    db.role_permissions.Add(
                        new role_permissions()
                        {
                            permission_id = Int32.Parse(permissions[index]),
                            role_id  = r_p.role_id
                        }
                        );
                }

                db.SaveChanges();

                return RedirectToAction("permissions", new { id = r_p.role_id });
            }
            return RedirectToAction("permissions", new { id = r_p.role_id });
        }
        //GET: roles/deletePermission/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult deletePermission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            role_permissions r_p = db.role_permissions.Where(a => a.ID == id).Include(a => a.permission).Include(a => a.role).FirstOrDefault();

            if (r_p == null)
            {
                return HttpNotFound();
            }
            return View(r_p);
        }

        //POST: roles/deletePermission/5 Delete player subscription with ID 5
        [HttpPost, ActionName("deletePermission")]
        [ValidateAntiForgeryToken]
        public ActionResult deletePermissionConfirmed(int id)
        {
            var role_per = db.role_permissions.Find(id);
            int role_id = role_per.role_id;
            db.role_permissions.Remove(role_per);
            db.SaveChanges();
            return RedirectToAction("permissions", new { id = role_id });
        }

        //GET roles/Subscriptions/5 Return the subscriptions for player with ID 5
        public ActionResult SubscriptionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_registerations subcri = db.player_registerations.Find(id);
            if (subcri == null)
            {
                return HttpNotFound();
            }
            return View(subcri);
        }

    }
}
