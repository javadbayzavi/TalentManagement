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
    public partial class groupsController : BaseController
    {
        //GET groups/roles/5 Return the subscriptions for player with ID 5
        public ActionResult roles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = db.group_roles.Where(e => e.group_id == id).Include(a => a.role).Include(a => a.group)
                .Where(a => a.role.title.Contains(this.Setting.PageSetting.SearchItem));
            var group = db.groups.Find(id);
            ViewBag.group = group;

            return View(roles);
        }
        //GET: groups/deleteRole/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult detailsRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            group_roles r_p = db.group_roles.Where(a => a.ID == id).Include(a => a.role).Include(a => a.group).FirstOrDefault();

            if (r_p == null)
            {
                //TODO : define styled error response through logging
                return HttpNotFound();
            }

            return View(r_p);
        }

        [HttpPost, ActionName("roles")]
        public ActionResult rolesPostBack(int id)
        {
            return this.roles(id);
        }

        //GET groups/addRole/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult addRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = db.groups.Find(id);

            if (group == null)
            {
                return HttpNotFound();
            }

            var roles = db.roles.Select(a => 
                new SelectListItem()
                {
                    Text = a.title,
                    Value = a.ID.ToString(),
                    Selected = a.groups.Any(aa => aa.group_id == group.ID && aa.role_id == a.ID)
                }
                ); 


            ViewBag.role_id = roles;
            ViewBag.group = group;
            return View();
        }

        //POST groups/addRole/5 
        [HttpPost, ActionName("addRole")]
        [ValidateAntiForgeryToken]
        public ActionResult addRole([Bind(Include = "group_id,role_id")] group_roleinput r_p)
        {
            string[] roles = this.Request["rolesid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(a => a != "false").ToArray(); 
            if (ModelState.IsValid)
            {
                for (int index = 0; index < roles.Length; index++)
                {
                    int rolID = Int32.Parse(roles[index]);
                    //Check for repeatitve entry
                    if (db.group_roles.Any(a => a.group_id == r_p.group_id && a.role_id == rolID))
                    {
                        continue;
                    }

                    db.group_roles.Add(
                        new group_roles()
                        {
                            role_id = Int32.Parse(roles[index]),
                            group_id  = r_p.group_id
                        }
                        );
                }

                db.SaveChanges();

                return RedirectToAction("roles", new { id = r_p.group_id });
            }
            return RedirectToAction("roles", new { id = r_p.group_id });
        }
        //GET: groups/deleteRole/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult deleteRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            group_roles r_p = db.group_roles.Where(a => a.ID == id).Include(a => a.role).Include(a => a.group).FirstOrDefault();

            if (r_p == null)
            {
                return HttpNotFound();
            }
            return View(r_p);
        }

        //POST: groups/deleteRole/5 Delete player subscription with ID 5
        [HttpPost, ActionName("deleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteRoleConfirmed(int id)
        {
            var role_per = db.group_roles.Find(id);
            int group_id = role_per.role_id;
            db.group_roles.Remove(role_per);
            db.SaveChanges();
            return RedirectToAction("roles", new { id = group_id });
        }

    }
}
