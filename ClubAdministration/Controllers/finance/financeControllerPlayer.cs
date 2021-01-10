using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Library.Utilities;
using ClubAdministration.Models;
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers
{
    //TODO: This section need to be reviewed and tuned with new changes
    public partial class financeController : BaseController
    {
        //GET: finance/PlayerCosts/1 return the overall player costs of a player with ID = 1 for all of his session
        public ActionResult PlayerCosts(int id)
        {
            if (id < 1)
                return HttpNotFound();

            var player = db.players.Find(id);
            ViewBag.player = player;

            if (player == null)
                return HttpNotFound();

            //1. Find the list of registered training_terms for the player
            var regtraining = db.player_registerations.Where(b => b.player_id == id).ToList();

            //2. Find the list of sessions of each registered training_terms for the player
            List<training_sessions> sessions = new List<training_sessions>();
            foreach (var item in regtraining)
            {
                var ses = item.training_terms.training_sessions.Where(a => item.re_date < a.se_date).ToList();
                sessions.AddRange(ses);
            }
            //3. Find the base price of each session after registeration
            
            var list = sessions.Select(a => new player_costs()
            {
                session = a,
                fee = a.training_terms.training_fees.OrderByDescending(or => or.ap_date).Where(b => b.ap_date <= a.se_date).Last().fee.GetValueOrDefault() /
                a.training_terms.player_registerations.Where(c => c.re_date < a.se_date).ToList().Count
            }
            ).ToList();
            //4. Find the list of payment that submited and billed for the player

            //5. Calculate the billing for the player 
            return View(list);
        }

        [HttpPost, ActionName("PlayerCosts"),ValidateAntiForgeryToken]
        public ActionResult PlayerCostsPostBack(int id)
        {
            return this.PlayerCosts(id);
        }

        public ActionResult PlayerInvoices(int id)
        {
            if (id < 1)
                return HttpNotFound();

            var player = db.players.Find(id);
            ViewBag.player = player;

            if (player == null)
                return HttpNotFound();

            ViewBag.payouts = player.player_payouts.ToList();


            var regtraining = db.player_registerations.Where(b => b.player_id == id).ToList();

            //2. Find the list of sessions of each registered training_terms for the player
            List<training_sessions> sessions = new List<training_sessions>();
            foreach (var item in regtraining)
            {
                var ses = item.training_terms.training_sessions.Where(a => item.re_date < a.se_date).ToList();
                sessions.AddRange(ses);
            }
            //3. Find the base price of each session after registeration

            var incoves = sessions.Select(a => new player_costs()
            {
                session = a,
                fee = a.training_terms.training_fees.OrderByDescending(or => or.ap_date).Where(b => b.ap_date <= a.se_date).Last().fee.GetValueOrDefault() /
                a.training_terms.player_registerations.Where(c => c.re_date < a.se_date).ToList().Count
            }
            ).GroupBy(a => a.session.training_terms).Select(a => new player_invoices()
            {
                overallcost = a.Sum(b => b.fee),
                training_term = a.First().session.training_terms
            }).ToList();

            ViewBag.player = player;

            return View(incoves);
        }
        
        public ActionResult PlayersInvoices()
        {
            var players = db.players.ToList();
            if (players == null)
                return HttpNotFound();
            List<players_invoices> invoices = new List<players_invoices>();
            foreach (var player in players)
            {
                var regtraining = db.player_registerations.Where(b => b.player_id == player.ID 
                && (b.player.name.Contains(this.Setting.PageSetting.SearchItem) || b.player.familiy.Contains(this.Setting.PageSetting.SearchItem))).ToList();

                //2. Find the list of sessions of each registered training_terms for the player
                List<training_sessions> sessions = new List<training_sessions>();
                foreach (var item in regtraining)
                {
                    var ses = item.training_terms.training_sessions.Where(a => item.re_date < a.se_date).ToList();
                    sessions.AddRange(ses);
                }
                //3. Find the base price of each session after registeration

                var balance = sessions.Select(a => new player_costs()
                {
                    session = a,
                    fee = a.training_terms.training_fees.OrderByDescending(or => or.ap_date).Where(b => b.ap_date <= a.se_date).Last().fee.GetValueOrDefault() /
                    a.training_terms.player_registerations.Where(c => c.re_date < a.se_date).ToList().Count
                }
                ).GroupBy(a => a.session.training_terms).Select(a => new players_invoices()
                {
                    player = player,
                    overallcost = a.Sum(b => b.fee),
                }).GroupBy(a => a.player).Select(a => new players_invoices() 
                { 
                    player = a.First().player,
                    invoice_balance =  (
                    player.player_payouts.Where(ba => ba.club_deposite.payment_type == 1).Sum(b => b.club_deposite.payment_fee)) - 
                    (
                        (a.Sum(b => b.overallcost)) +
                        player.player_payouts.Where(b => b.club_deposite.payment_type == 2).Sum(b => b.club_deposite.payment_fee)
                    ),
                }).ToList();

                invoices.AddRange(balance);
                

            }
            return View(invoices);
        }
        [HttpPost, ActionName("PlayersInvoices"),ValidateAntiForgeryToken]
        public ActionResult PlayersInvoicesPostBack()
        {
            return this.PlayersInvoices();
        }

        //GET finance/PlayerPayments/5
        public ActionResult PLayerPayments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.pl_id = id;

            var payments = db.player_payouts.Where(e => e.player_id == id && 
            (e.club_deposite.payment_fee.ToString().Contains(this.Setting.PageSetting.SearchItem) || e.club_deposite.payment_item.Contains(this.Setting.PageSetting.SearchItem))
            ).ToList();

            ViewBag.fullname = db.players.Find(id).fullname;
            return View(payments);
        }

        [HttpPost, ActionName("PlayerPayments"),ValidateAntiForgeryToken]
        public ActionResult PlayerPaymentsPostBack(int? id)
        {
            return this.PLayerPayments(id);
        }

        //GET finance/CreatePlayerPayment/ Add a new payment to the payment list of a player with ID = 5
        public ActionResult CreatePlayerPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pl = db.players.Find(id);

            if (pl == null)
            {
                return HttpNotFound();
            }

            //Retrieve payments that not attached to any other players payment records.
            var payments = db.club_deposite.Where(e => !e.player_payouts.Any(f => f.clubdeposite_id == e.ID)).Select(a => new
            {
                title = a.payment_item + " : " + a.payment_fee,
                id = a.ID.ToString()
            }
            );

            ViewBag.clubdeposite_id = new SelectList(payments, "id", "title");
            ViewBag.player = pl;
            return View();
        }

        //POST finance/AddPlayerPayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlayerPayment([Bind(Include = "ID,player_id,clubdeposite_id,billed_date,fee_status")] player_payouts payment)
        {
            if (ModelState.IsValid)
            {
                db.player_payouts.Add(payment);
                db.SaveChanges();
                return RedirectToAction("PlayerPayments", new { id = payment.player_id });
            }
            return View(payment);
        }

        //GET finance/DetailsPlayerPayment/5 Show the details of a payment with ID = 5
        public ActionResult DetailsPlayerPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_payouts player_payouts = db.player_payouts.Find(id);
            if (player_payouts == null)
            {
                return HttpNotFound();
            }
            return View(player_payouts);
        }

        public ActionResult EditPlayerPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var payout = db.player_payouts.Find(id);
            if (payout == null)
                return HttpNotFound();

            var payments = db.club_deposite.Where(e => !e.player_payouts.Any(f => f.clubdeposite_id == e.ID) || e.player_payouts.Any(f => f.player_id == payout.player_id)).Select(a => new SelectListItem()
            {
                Text = a.payment_item + " : " + a.payment_fee,
                Value = a.ID.ToString()
            }
            ).ToList();
            ViewBag.clubdeposite_id = new SelectList(payments, "Value", "Text", payout.clubdeposite_id);

            return View(payout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlayerPayment([Bind(Include = "ID,player_id,clubdeposite_id,billed_date,fee_status")] player_payouts payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PlayerPayments", new { id = payment.player_id });
            }
            return View(payment);
        }

        //GET finance/DeletePlayerPayment/5
        public ActionResult DeletePlayerPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payment = db.player_payouts.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //finance/DeletePlayerPayment
        [HttpPost, ActionName("DeletePlayerPayment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlayerPaymentConfimed(int id)
        {
            var payment = db.player_payouts.Find(id);
            int pid = payment.player_id.GetValueOrDefault();
            db.player_payouts.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("PlayerPayments", new { id = pid });
        }
    }
}

