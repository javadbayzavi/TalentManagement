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
    public partial class groupsController : BaseController
    {
        //GET groups/groups/5 Return the subscriptions for player with ID 5
        public ActionResult users(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var users = db.user_groups.Where(e => e.group_id == id).Include(a => a.user).Include(a => a.group)
                .Where(a => a.user.title.Contains(this.Setting.PageSetting.SearchItem));
            var group = db.groups.Find(id);
            ViewBag.group = group;

            return View(users);
        }
        //GET: groups/detailsGroup/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult detailsUser(int? id)
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

        [HttpPost, ActionName("users")]
        public ActionResult usersPostBack(int id)
        {
            return this.users(id);
        }

        //GET groups/addUser/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult addUser(int? id)
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

            var users = db.users.Select(a => 
                new SelectListItem()
                {
                    Text = a.title,
                    Value = a.ID.ToString(),
                    Selected = a.groups.Any(aa => aa.group_id == group.ID && aa.user_id == a.ID)
                }
                ); 


            ViewBag.user_id = users;
            ViewBag.group = group;
            return View();
        }

        //POST groups/addUser/5 
        [HttpPost, ActionName("addUser")]
        [ValidateAntiForgeryToken]
        public ActionResult addUser([Bind(Include = "group_id,user_id")] group_userinput r_p)
        {
            string[] users = this.Request["usersid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(a => a != "false").ToArray(); 
            if (ModelState.IsValid)
            {
                for (int index = 0; index < users.Length; index++)
                {
                    int groupID = Int32.Parse(users[index]);
                    //Check for repeatitve entry
                    if (db.user_groups.Any(a => a.group_id == r_p.group_id && a.user_id == groupID))
                    {
                        continue;
                    }

                    db.user_groups.Add(
                        new user_groups()
                        {
                            user_id = Int32.Parse(users[index]),
                            group_id  = r_p.group_id
                        }
                        );
                }

                db.SaveChanges();

                return RedirectToAction("users", new { id = r_p.group_id });
            }
            return RedirectToAction("users", new { id = r_p.group_id });
        }
        //GET: groups/deleteUser/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult deleteUser(int? id)
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

        //POST: groups/deleteUser/5 Delete player subscription with ID 5
        [HttpPost, ActionName("deleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteUserConfirmed(int id)
        {
            var user_per = db.user_groups.Find(id);
            int user_id = user_per.user_id;
            db.user_groups.Remove(user_per);
            db.SaveChanges();
            return RedirectToAction("users", new { id = user_id });
        }

    }
}
