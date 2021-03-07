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
using ClubAdministration.Library.Utilities;
using ClubAdministration.Models;
using ClubAdministration.Resources.modules.club;

namespace ClubAdministration.Controllers
{
    public partial class trainingsController : BaseController
    {
        //private clubAdminProxy db = new clubAdminProxy();

        // GET: trainingsController
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.training_terms.Include(a => a.agelevel).ToList().Where(a => 
            a.term_title.Contains(this.Setting.PageSetting.SearchItem)||
            a.start_date.Contains(this.Setting.PageSetting.SearchItem)||
            a.end_date.Contains(this.Setting.PageSetting.SearchItem)
            ).ToList());
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        public ActionResult Sessions(int? id)
        {
            if (id == null)
            {
                
                Session["TACTION_RESULT"] = lang.sessionShowError;
                return this.RedirectToAction("Index");
            }
            training_terms training_terms = db.training_terms.Find(id);
            if (training_terms == null)
            {
                Session["TACTION_RESULT"] = lang.sessionNotFound;
                return this.RedirectToAction("Index");
            }

            ViewBag.training = training_terms;

            return View(training_terms.training_sessions.Where(a => a.session_date.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }
        [HttpPost]
        [ActionName("Sessions")]
        [ValidateAntiForgeryToken]
        public ActionResult SessionsPostBack(int? id)
        {
            return this.Sessions(id);
        }

        public ActionResult Coaches(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = lang.coachShowError;
                return this.RedirectToAction("Index");
            }
            training_terms training_terms = db.training_terms.Find(id);
            if (training_terms == null)
            {
                Session["TACTION_RESULT"] = lang.coachNotFound;
                return this.RedirectToAction("Index");
            }

            ViewBag.training = training_terms;

            return View(training_terms.coach_training.Where(a => a.coach.coach_name.Contains(this.Setting.PageSetting.SearchItem) ||
            a.coach.coach_family.Contains(this.Setting.PageSetting.SearchItem)
            ).ToList());
        }
        [HttpPost]
        [ActionName("Coaches")]
        [ValidateAntiForgeryToken]
        public ActionResult CoachesPostBack(int? id)
        {
            return this.Coaches(id);
        }

        public ActionResult Players(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = lang.playerShowError;
                return this.RedirectToAction("Index");
            }
            training_terms training_terms = db.training_terms.Find(id);
            if (training_terms == null)
            {
                Session["TACTION_RESULT"] = lang.playerNotFound;
                return this.RedirectToAction("Index");
            }

            ViewBag.training = training_terms;

            return View(training_terms.player_registerations
                .Where(a =>
                a.player.name.Contains(this.Setting.PageSetting.SearchItem)
                || a.player.familiy.Contains(this.Setting.PageSetting.SearchItem)
                ).ToList());
        }
        [HttpPost]
        [ActionName("Players")]
        [ValidateAntiForgeryToken]
        public ActionResult PlayersPostBack(int? id)
        {
            return this.Players(id);
        }

        // GET: trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = lang.trainingShowError;
                return this.RedirectToAction("Index");
            }
            training_terms training_terms = db.training_terms.Where(a => a.ID == id).Include(a => a.agelevel).FirstOrDefault();
            if (training_terms == null)
            {
                Session["TACTION_RESULT"] = lang.trainingNotFound;
                return this.RedirectToAction("Index");
            }

            return View(training_terms);
        }

        // GET: trainings/Create
        public ActionResult Create()
        {
            //TODO: This action need to be deeply reviewed
            ViewBag.level_id = new SelectList(db.agelevels.ToList(), "ID", "level");
            return View();
        }

        // POST: clubController/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,term_title,start_date,max_player,session_per_week,weekdays,active,end_date,fee_type,level_id,start_time,end_time")] training_terms training_terms)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.training_terms.Add(training_terms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training_terms);
        }

        // GET: trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_terms training_terms = db.training_terms.Find(id);

            if (training_terms == null)
            {
                return HttpNotFound();
            }
            ViewBag.level_id = new SelectList(db.agelevels.ToList(), "ID", "level", training_terms.level_id);

            return View(training_terms);
        }

        // POST: trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,term_title,start_date,max_player,session_per_week,weekdays,active,end_date,fee_type,level_id,start_time,end_time")] training_terms training_terms)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(training_terms).State = EntityState.Modified;
                db.SaveChanges();
                //TODO : cascade update on players end subscriptions for the players whose subscription dates not passed
                return RedirectToAction("Index");
            }
            return View(training_terms);
        }

        // GET: trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_terms training_terms = db.training_terms.Where(a => a.ID == id).Include(a => a.agelevel).FirstOrDefault();
            if (training_terms == null)
            {
                return HttpNotFound();
            }

            return View(training_terms);
        }

        // POST: trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            training_terms training_terms = db.training_terms.Find(id);
            db.training_terms.Remove(training_terms);
            db.SaveChanges();
            return RedirectToAction("Index");
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