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
    //TODO: This class need to be reviewed and tunned deeply especially from the ParticipantDetails definintion to the end of the file
    public partial class sessionsController : BaseController
    {
        //GET: sessions/Coaches/5
        public ActionResult Coaches(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.session = db.training_sessions.Find(id);

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            var list = db.coach_sessions.ToList().Where(e => e.session_id == id &&
                (e.coach.coach_name.Contains(this.Setting.PageSetting.SearchItem) ||
                e.coach.coach_family.Contains(this.Setting.PageSetting.SearchItem))
            ).ToList();

            return View(list);
        }

        [HttpPost, ActionName("Coaches"), ValidateAntiForgeryToken]
        public ActionResult CoachesPostBack(int? id)
        {
            return this.Coaches(id);
        }

        public ActionResult AddCoach(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //1. Find the selected training session
            var sessionObj = db.training_sessions.Find(id);
            ViewBag.session = sessionObj;

            //2. Store the session id for the next post back
            ViewBag.id = id;

            //3. Find coaches who are registered at training term
            var tempcoaches = db.coach_trainings.Where(e => e.training_id == sessionObj.trainingterms_id && e.re_date < sessionObj.se_date && sessionObj.se_date <= e.ree_date).ToList();

            //4. Select coaches whose participations did not logged at system
            var unattended = tempcoaches.Where(e => !db.coach_sessions.Any(f => f.coach_id == e.coach_id && f.session_id == sessionObj.ID)).Select(
                e => new SelectListItem
                {
                    //Text = e.player.name + " " + e.player.familiy,
                    Text = e.coach.FullName,
                    Value = e.coach_id.ToString()
                }
                ).ToList();

            //5. Send unattended players to view control
            ViewBag.coach_id = unattended;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCoach([Bind(Include = "ID,coach_id,session_id")]coach_sessions coaches)
        {
            if (ModelState.IsValid)
            {
                db.coach_sessions.Add(coaches);
                db.SaveChanges();
                return RedirectToAction("AddCoach", new { id = coaches.session_id });
            }

            return View(coaches);
        }

        public ActionResult DetailsCoach(int id)
        {
            var tempcoach = db.coach_sessions.Find(id);
            if (tempcoach == null)
            {
                return HttpNotFound();
            }
            return View(tempcoach);
        }
        public ActionResult EditCoach(int id)
        {
            var tempcoach = db.coach_sessions.Find(id);
            if (tempcoach == null)
            {
                return HttpNotFound();
            }
            return View(tempcoach);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCoach([Bind(Include = "ID,coach_id,session_id")] player_sessions tempcoach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempcoach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Coaches", new { id = tempcoach.session_id });
            }
            return View(tempcoach);
        }
        public ActionResult DeleteCoach(int id)
        {
            var tempcoach = db.coach_sessions.Find(id);
            if (tempcoach == null)
            {
                return HttpNotFound();
            }
            return View(tempcoach);
        }


        [HttpPost, ActionName("DeleteCoach")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCoachConfirmed(int id)
        {
            var tempcoach = db.coach_sessions.Find(id);
            var session_id = tempcoach.session_id;
            if (tempcoach != null)
            {
                db.coach_sessions.Remove(tempcoach);

                db.SaveChanges();
            }
            return RedirectToAction("Coaches", new { id = session_id });
        }
    }
}