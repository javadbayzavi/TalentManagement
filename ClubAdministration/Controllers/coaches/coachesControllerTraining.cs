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

namespace ClubAdministration.Controllers.coaches
{
    public partial class coachesController : BaseController
    {

        // GET: coaches/Trainings
        public ActionResult Trainings(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش مدارك مربيگري";
                return this.RedirectToAction("Index");
            }

            coach coach = db.coaches.Find(id);

            if (coach == null)
            {
                Session["TACTION_RESULT"] = "كلاس آموزشي درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            var trainings = db.coach_trainings.Where(e => e.coach_id == id).ToList()
                .Where(aa => aa.training_terms.term_title.Contains(this.Setting.PageSetting.SearchItem));

            ViewBag.fullname = coach.FullName;
            ViewBag.pl_id = coach.ID;

            return View(trainings);

        }

        // POST: coaches/Trainings
        [HttpPost,ActionName("Trainings"),ValidateAntiForgeryToken]
        public ActionResult training(int? id)
        {
            return this.Trainings(id);
        }

        // GET: coaches/DetailsTraining/5
        public ActionResult DetailsTraining(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach_training subcri = db.coach_trainings.Find(id);
            if (subcri == null)
            {
                return HttpNotFound();
            }
            return View(subcri);
        }

        // GET: coaches/CreateTraining
        public ActionResult CreateTraining(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coach = db.coaches.Find(id);

            if (coach == null)
            {
                return HttpNotFound();
            }

            //Business rules in class registeration:
            //1. Coach cannot register twice in a same class
            //2.Coach cannot register in a class that is currently closed
            int today = BaseDate.CalculateDateDiffInMinutes(DateTime.Today);
            var trtrm = db.training_terms
                .Where(a =>
                a.e_date > today &&
                a.coach_training.Any(pl => pl.coach_id == coach.ID) == false
                ).ToList();

            ViewBag.training_id = new SelectList(trtrm, "ID", "term_title");

            ViewBag.coach = coach;
            return View();
        }

        // POST: coaches/CreateTraining
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTraining([Bind(Include = "coach_id,training_id,registeration_date,resignation_date")] coach_training subscription)
        {
            var trn = db.training_terms.Find(subscription.training_id);
            if (subscription.re_date < trn.s_date ||
                subscription.re_date > trn.e_date ||
                subscription.re_date > subscription.ree_date ||
                subscription.ree_date > trn.e_date)
            {
                Session["TACTION_RESULT"] = "تاريخ هاي ورودي را كنترل كنيد";
                return View(subscription);
            }
            if (ModelState.IsValid)
            {
                db.coach_trainings.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Trainings", new { id = subscription.coach_id });
            }

            return View(subscription);
        }

        // GET: coaches/EditTraining/5
        public ActionResult EditTraining(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coach_tr = db.coach_trainings.Find(id);

            if (coach_tr == null)
            {
                return HttpNotFound();
            }

            ViewBag.training_id = new SelectList(db.training_terms, "ID", "term_title", coach_tr.training_id);

            var coach = db.coaches.Find(coach_tr.coach_id);
            ViewBag.coach = coach;

            return View(coach_tr);
        }

        // POST: coaches/EditTraining/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("EditTraining")]
        public ActionResult EditTraining([Bind(Include = "ID,coach_id,training_id,registeration_date,resignation_date")] coach_training  subscripti)
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
                return this.RedirectToAction("Trainings", subscripti);
            }

            if (ModelState.IsValid)
            {
                db.Entry(subscripti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Trainings", new { id = subscripti.coach_id });
            }
            return View(subscripti);
        }

        // GET: coaches/DeleteTraining/5
        public ActionResult DeleteTraining(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach_training subcri = db.coach_trainings.Find(id);
            if (subcri == null)
            {
                return HttpNotFound();
            }
            return View(subcri);
        }

        // POST: coaches/DeleteTraining/5
        [HttpPost, ActionName("DeleteTraining")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTrainingConfirmed(int id)
        {
            var subscribe = db.coach_trainings.Find(id);
            int coach_id = subscribe.coach_id;
            db.coach_trainings.Remove(subscribe);
            db.SaveChanges();
            return RedirectToAction("Trainings", new { id = coach_id });
        }
    }
}
