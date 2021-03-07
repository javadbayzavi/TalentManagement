using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Models;

namespace ClubAdministration.Controllers
{
    public partial class sessionsController : BaseController
    {
        //private clubAdminProxy db = new clubAdminProxy();

        // GET: sessions
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            var training_sessions = db.training_sessions.Include(t => t.training_terms).ToList();
            return View(training_sessions.Where(a =>
            a.session_date.Contains(this.Setting.PageSetting.SearchItem) ||
            a.training_terms.term_title.Contains(this.Setting.PageSetting.SearchItem)
            ).ToList());
        }

        [HttpPost, ActionName("Index"), ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }
        // GET: sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_sessions training_sessions = db.training_sessions.Find(id);
            if (training_sessions == null)
            {
                return HttpNotFound();
            }
            return View(training_sessions);
        }

        // GET: sessions/Create
        public ActionResult Create()
        {
            ViewBag.trainingterms_id = new SelectList(db.training_terms, "ID", "term_title");
            return View();
        }

        // POST: sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,trainingterms_id,session_date,attendance_number,session_closed,start_time,end_time")] training_sessions training_sessions)
        {
            if (ModelState.IsValid)
            {
                db.training_sessions.Add(training_sessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trainingterms_id = new SelectList(db.training_terms, "ID", "term_title", training_sessions.trainingterms_id);
            return View(training_sessions);
        }

        // GET: sessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_sessions training_sessions = db.training_sessions.Find(id);
            if (training_sessions == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainingterms_id = new SelectList(db.training_terms, "ID", "term_title", training_sessions.trainingterms_id);
            return View(training_sessions);
        }

        // POST: sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,trainingterms_id,session_date,attendance_number,session_closed,start_time,end_time")] training_sessions training_sessions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training_sessions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trainingterms_id = new SelectList(db.training_terms, "ID", "term_title", training_sessions.trainingterms_id);
            return View(training_sessions);
        }

        // GET: sessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_sessions training_sessions = db.training_sessions.Find(id);
            if (training_sessions == null)
            {
                return HttpNotFound();
            }
            return View(training_sessions);
        }

        // POST: sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            training_sessions training_sessions = db.training_sessions.Find(id);
            db.training_sessions.Remove(training_sessions);
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
