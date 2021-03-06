﻿using System;
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
    public partial class playersController : BaseController
    {
        //GET players/Subscriptions/5 Return the subscriptions for player with ID 5
        public ActionResult Subscriptions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subcription = db.player_registerations.Where(e => e.player_id == id).ToList()
                .Where(aa => aa.training_terms.term_title.Contains(this.Setting.PageSetting.SearchItem));
            var pl = db.players.Find(id);
            ViewBag.fullname = pl.name + " " + pl.familiy;
            ViewBag.pl_id = pl.ID;

            return View(subcription);
        }


        //GET players/Subscribe/5/edit  Show the creation form for subscribing player with ID 5 to new classes
        public ActionResult Subscribe(int? id)
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

            //Business rules in class registeration:
            //1. Player cannot register twice in a same class
            //2.Player cannot register in a class that is currently closed
            //3. Max capacity of classes must be checked
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

        //POST players/Subscribe/5 
        [HttpPost, ActionName("Subscribe")]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Include = "player_id,training_id,registeration_date,resignation_date")] player_registerations subscription)
        {
            if (ModelState.IsValid)
            {
                db.player_registerations.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Subscriptions", new { id = subscription.player_id });
            }
            return RedirectToAction("Subscriptions", new { id = subscription.player_id });
        }

        public ActionResult Resubscribe(int? id)
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

        //POST players/Resubscribe
        [HttpPost, ActionName("Resubscribe")]
        [ValidateAntiForgeryToken]
        public ActionResult Resubscribe([Bind(Include = "ID,player_id,training_id,registeration_date,resignation_date")] player_registerations subscripti)
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
        //GET: players/Unsubcribe/5 Show the unsubscription confirmation for palyer subcription with subscription id 5
        public ActionResult Unsubscribe(int? id)
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

        //POST: players/Unsubscribe/5 Delete player subscription with ID 5
        [HttpPost, ActionName("Unsubscribe")]
        [ValidateAntiForgeryToken]
        public ActionResult UnsubscribeConfirmed(int id)
        {
            var subscribe = db.player_registerations.Find(id);
            int player_id = subscribe.player_id.GetValueOrDefault();
            db.player_registerations.Remove(subscribe);
            db.SaveChanges();
            return RedirectToAction("Subscriptions", new { id = player_id });
        }

        //GET players/Subscriptions/5 Return the subscriptions for player with ID 5
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
