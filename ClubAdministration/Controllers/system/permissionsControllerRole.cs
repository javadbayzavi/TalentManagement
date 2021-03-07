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

namespace ClubAdministration.Controllers
{
    //List of all commands
    //GET players/Subscriptions Show the list of
    public partial class rolesController : BaseController
    {
        //GET roles/Subscriptions/5 Return the subscriptions for player with ID 5
        public ActionResult permissions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var permissions = db.role_permissions.Where(e => e.player_id == id).ToList()
                .Where(aa => aa.training_terms.term_title.Contains(this.Setting.PageSetting.SearchItem));
            var pl = db.players.Find(id);
            ViewBag.fullname = pl.name + " " + pl.familiy;
            ViewBag.pl_id = pl.ID;

            return View(permissions);
        }


        //GET roles/Subscribe/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult addPermission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = db.players.Find(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            int today = BaseDate.CalculateDateDiffInMinutes(DateTime.Today);
            var trtrm = db.training_terms
                .Where(a =>
                a.e_date > today &&
                a.player_registerations.Any(pl => pl.player_id == player.ID) == false &&
                a.player_registerations.Count < a.max_player
                ).ToList();

            ViewBag.training_id = new SelectList(trtrm, "ID", "term_title");

            ViewBag.player = player;
            return View();
        }

        //POST roles/addPermission/5 
        [HttpPost, ActionName("addPermission")]
        [ValidateAntiForgeryToken]
        public ActionResult addPermission([Bind(Include = "player_id,training_id,registeration_date,resignation_date")] player_registerations subscription)
        {
            if (ModelState.IsValid)
            {
                db.player_registerations.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Subscriptions", new { id = subscription.player_id });
            }
            return RedirectToAction("Subscriptions", new { id = subscription.player_id });
        }

        public ActionResult editPermission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_registerations p_r;
            p_r = db.player_registerations.Find(id);


            ViewBag.training_id = new SelectList(db.training_terms, "ID", "term_title", p_r.training_id);


            return View(p_r);
        }

        //POST roles/editPermission
        [HttpPost, ActionName("editPermission")]
        [ValidateAntiForgeryToken]
        public ActionResult editPermission([Bind(Include = "ID,player_id,training_id,registeration_date,resignation_date")] player_registerations subscripti)
        {
            //It must be check for various conditions:
            //1.start date must be bigger than the class start date
            //2.end date must be smaller than the class end date
            //3. start date must be smaller than end date
            var trn = db.training_terms.Find(subscripti.training_id);
            if (subscripti.re_date < trn.s_date ||
                subscripti.re_date > trn.e_date ||
                subscripti.re_date > subscripti.ree_date ||
                subscripti.ree_date > trn.e_date)
            {
                Session["TACTION_RESULT"] = "تاريخ هاي ورودي را كنترل كنيد";
                return this.RedirectToAction("Resubscribe", subscripti); 
            }

            if(ModelState.IsValid)
            {
                db.Entry(subscripti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Subscriptions", new { id = subscripti.player_id });
            }
            return View(subscripti);
        }
        //GET: roles/deletePermission/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult deletePermission(int? id)
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

        //POST: roles/deletePermission/5 Delete player subscription with ID 5
        [HttpPost, ActionName("deletePermission")]
        [ValidateAntiForgeryToken]
        public ActionResult deletePermissionConfirmed(int id)
        {
            var subscribe = db.player_registerations.Find(id);
            int player_id = subscribe.player_id.GetValueOrDefault();
            db.player_registerations.Remove(subscribe);
            db.SaveChanges();
            return RedirectToAction("permissions", new { id = player_id });
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
