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

namespace ClubAdministration.Controllers.coaches
{
    public partial class coachesController : BaseController
    {

        // GET: coaches
        public ActionResult Sessions(int? id)
        {
            return View(db.coaches.ToList().Where(
                a => a.FullName.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }

        // GET: coaches/Details/5
        public ActionResult DetailsSession(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // GET: coaches/Create
        public ActionResult CreateSession(int id)
        {
            return View();
        }

        // POST: coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSession([Bind(Include = "ID,coach_name,coach_family,coach_birthday,coach_gender,registeration_date")] coach coach)
        {
            if (ModelState.IsValid)
            {
                db.coaches.Add(coach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coach);
        }

        // GET: coaches/Edit/5
        public ActionResult EditSession(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: coaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSession([Bind(Include = "ID,coach_name,coach_family,coach_birthday,coach_gender,registeration_date")] coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        // GET: coaches/Delete/5
        public ActionResult DeleteSession(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSessionConfirmed(int id)
        {
            coach coach = db.coaches.Find(id);
            db.coaches.Remove(coach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
