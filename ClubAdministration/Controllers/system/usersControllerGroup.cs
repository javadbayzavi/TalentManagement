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
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers.system
{
    //List of all commands
    //GET roles/permissions Show the list of
    public partial class usersController : BaseController
    {
        //GET users/groups/5 Return the subscriptions for player with ID 5
        public ActionResult groups(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var groups = db.user_groups.Where(e => e.user_id == id).Include(a => a.user).Include(a => a.group)
                .Where(a => a.group.title.Contains(this.Setting.PageSetting.SearchItem));
            var user = db.users.Find(id);
            ViewBag.user = user;

            return View(groups);
        }
        //GET: users/deleteRole/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult detailsGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            user_groups r_p = db.user_groups.Where(a => a.ID == id).Include(a => a.user).Include(a => a.group).FirstOrDefault();

            if (r_p == null)
            {
                //TODO : define styled error response through logging
                return HttpNotFound();
            }

            return View(r_p);
        }

        [HttpPost, ActionName("groups")]
        public ActionResult groupsPostBack(int id)
        {
            return this.groups(id);
        }

        //GET users/addGroup/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult addGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var groups = db.groups.Select(a => 
                new SelectListItem()
                {
                    Text = a.title,
                    Value = a.ID.ToString(),
                    Selected = a.users.Any(aa => aa.user_id == user.ID && aa.group_id == a.ID)
                }
                ); 


            ViewBag.group_id = groups;
            ViewBag.user = user;
            return View();
        }

        //POST users/addGroup/5 
        [HttpPost, ActionName("addGroup")]
        [ValidateAntiForgeryToken]
        public ActionResult addGroup([Bind(Include = "group_id,user_id")] user_groupinput r_p)
        {
            string[] groups = this.Request["groupsid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(a => a != "false").ToArray(); 
            if (ModelState.IsValid)
            {
                for (int index = 0; index < groups.Length; index++)
                {
                    int groupID = Int32.Parse(groups[index]);
                    //Check for repeatitve entry
                    if (db.user_groups.Any(a => a.user_id == r_p.user_id && a.group_id == groupID))
                    {
                        continue;
                    }

                    db.user_groups.Add(
                        new user_groups()
                        {
                            group_id = Int32.Parse(groups[index]),
                            user_id  = r_p.user_id
                        }
                        );
                }

                db.SaveChanges();

                return RedirectToAction("groups", new { id = r_p.group_id });
            }
            return RedirectToAction("groups", new { id = r_p.group_id });
        }
        //GET: users/deleteGroup/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult deleteGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            user_groups r_p = db.user_groups.Where(a => a.ID == id).Include(a => a.user).Include(a => a.group).FirstOrDefault();

            if (r_p == null)
            {
                return HttpNotFound();
            }
            return View(r_p);
        }

        //POST: users/deleteGroup/5 Delete player subscription with ID 5
        [HttpPost, ActionName("deleteGroup")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteGroupConfirmed(int id)
        {
            var group_per = db.user_groups.Find(id);
            int group_id = group_per.user_id;
            db.user_groups.Remove(group_per);
            db.SaveChanges();
            return RedirectToAction("groups", new { id = group_id });
        }

    }
}
