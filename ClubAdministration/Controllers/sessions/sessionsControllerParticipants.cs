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
        //GET: sessions/Participants/5
        public ActionResult Participants(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.session = db.training_sessions.Find(id);

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            var list = db.player_sessions.ToList().Where(e => e.session_id == id &&
                (e.player.name.Contains(this.Setting.PageSetting.SearchItem) ||
                e.player.familiy.Contains(this.Setting.PageSetting.SearchItem) ||
                e.hour_in.Contains(this.Setting.PageSetting.SearchItem) ||
                e.hour_out.Contains(this.Setting.PageSetting.SearchItem))
            ).ToList();

            return View(list);
        }

        [HttpPost, ActionName("Participants"), ValidateAntiForgeryToken]
        public ActionResult ParticipantsPostBack(int? id)
        {
            return this.Participants(id);
        }

        public ActionResult AddParticipant(int? id)
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

            //3. Find players who are registered at training term
            var players = db.player_registerations.Where(e => e.training_id == sessionObj.trainingterms_id && e.re_date < sessionObj.se_date && sessionObj.se_date <= e.ree_date).ToList();

            //4. Select players whose participations did not logged at system
            var unattended = players.Where(e => !db.player_sessions.Any(f => f.player_id == e.player_id && f.session_id == sessionObj.ID)).Select(
                e => new SelectListItem
                {
                    Text = e.player.name + " " + e.player.familiy,
                    Value = e.player_id.ToString()
                }
                ).ToList();

            //5. Send unattended players to view control
            ViewBag.player_id = unattended;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParticipant([Bind(Include = "ID,player_id,session_id,hour_in,hour_out")]player_sessions participation)
        {
            if (ModelState.IsValid)
            {
                db.player_sessions.Add(participation);
                db.SaveChanges();
                return RedirectToAction("AddParticipant", new { id = participation.session_id });
            }

            return View(participation);
        }

        public ActionResult DetailsParticipant(int id)
        {
            var participant = db.player_sessions.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }
        public ActionResult EditParticipant(int id)
        {
            var participant = db.player_sessions.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditParticipant([Bind(Include = "ID,hour_in,hour_out,player_id,session_id")] player_sessions participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Participants", new { id = participant.session_id });
            }
            return View(participant);
        }
        public ActionResult DeleteParticipant(int id)
        {
            var participant = db.player_sessions.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }


        [HttpPost, ActionName("DeleteParticipant")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteParticipants(int id)
        {
            var participant = db.player_sessions.Find(id);
            var session_id = participant.session_id;
            if (participant != null)
            {
                db.player_sessions.Remove(participant);

                db.SaveChanges();
            }
            return RedirectToAction("Participants", new { id = session_id });
        }
    }
}