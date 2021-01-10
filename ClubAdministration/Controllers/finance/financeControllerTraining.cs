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
    public partial class financeController : BaseController
    {
        //GET: finance/TrainingCosts/1 return the overall costs of all session for training_term with ID  = 1
        [HttpPost, ActionName("TrainingCosts"), ValidateAntiForgeryToken]
        public ActionResult TrainingCostsPostBack(int id)
        {
            return this.TrainingCosts(id);
        }
        public ActionResult TrainingCosts(int id)
        {
            if (id < 1)
                return HttpNotFound();

            //1. Fetch the list of all sessions
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            var sessions = db.training_terms.Find(id).training_sessions
                .ToList().Where(a => a.session_date.Contains(this.Setting.PageSetting.SearchItem));
            foreach (var item in sessions)
            {
                var ss = item.training_terms.player_registerations.Where(b => b.re_date <= item.se_date && item.se_date <= b.ree_date).Count();
            }
            //2. Set the the cost of each session from the last price update of the training_fee
            var sessionwithbaseprice = sessions.OrderByDescending(a => a.se_date).Select(a => new session_costs()
            {
                session_id = a.ID,
                training_terms = a.training_terms,
                session_closed = a.session_closed.GetValueOrDefault(),
                session_date = a.session_date,
                registerantscount = a.training_terms.player_registerations.Where(b => b.re_date <= a.se_date && a.se_date <= b.ree_date).Count(),
                baseprice = a.training_terms.training_fees.OrderByDescending(or => or.ap_date).Where(b => b.ap_date <= a.se_date).Last().fee.GetValueOrDefault()
            }
            ).ToList();

            ViewBag.training = db.training_terms.Find(id);
            return View(sessionwithbaseprice);
        }

        //GET: finance/SessionCosts/1 return the overall player costs of a session with ID = 1
        public ActionResult SessionCosts(int id)
        {
            if (id < 1)
                return HttpNotFound();
            var session = db.training_sessions.Find(id);

            if (session == null)
                return HttpNotFound();
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            var baseprice = session.training_terms.training_fees.OrderByDescending(or => or.ap_date).Where(a => a.ap_date <= session.se_date).Last().fee;
            ViewBag.players = db.player_registerations
                .Where(a =>
                    a.re_date < session.se_date && a.training_id == session.trainingterms_id).ToList()
                    .Where(a => a.registeration_date.Contains(this.Setting.PageSetting.SearchItem))
                    .ToList();

            ViewBag.price = baseprice;
            ViewBag.session = session;

            //return View(players);
            return View();
        }

        [HttpPost, ActionName("SessionCosts"), ValidateAntiForgeryToken]
        public ActionResult SessionCostsPostBack(int id)
        {
            return this.SessionCosts(id);
        }
    }
}
