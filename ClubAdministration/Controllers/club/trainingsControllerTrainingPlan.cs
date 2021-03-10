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
using ClubAdministration.Models.ViewModels;
using ClubAdministration.Resources.modules.club.plans;

namespace ClubAdministration.Controllers
{
    public partial class trainingsController : BaseController
    {

        // GET: trainings/Plans
        public ActionResult Plans(int? id)
        {
            if (id == null)
            {
                Session[ReservedKeys.TransactionResult] = lang.trainingShowError;
                return this.RedirectToAction("Index");
            }

            var training = db.training_terms.Where(a => a.ID == id).Include(a => a.training_patterns.Select(aa => aa.pattern)).FirstOrDefault();

            if (training == null)
            {
                Session[ReservedKeys.TransactionResult] = lang.trainingNotFound;
                return this.RedirectToAction("Index");
            }

            ViewBag.training = training;

            return View(training.training_patterns.Where(e => e.training_id == id && e.pattern.title.Contains(this.Setting.PageSetting.SearchItem)
                ));

        }

        // GET: trainings/Preview/5
        public ActionResult Preview(int id)
        {
            if (id <= 0)
            {
                Session["TACTION_RESULT"] = lang.trainingShowError;
                return this.RedirectToAction("Index");
            }

            var training = db.training_terms.Where(a => a.ID == id)
                .Include(a => a.training_patterns
                .Select(aa => aa.pattern.items.Select(c => c.drill)))
                .FirstOrDefault();

            if (training == null)
            {
                Session["TACTION_RESULT"] = lang.trainingNotFound;
                return this.RedirectToAction("Index");
            }

            ViewBag.training = training.term_title;
            ViewBag.training_id = training.ID;
            @ViewBag.StoreAddess = "trainings/PreviewDrills/" + training.ID.ToString();
            return View();
        } 

        // GET(Json): trainings/Preview
        public JsonResult PreviewDrills(int id)
        {
            var training = db.training_terms.Where(a => a.ID == id)
                .Include(a => a.training_patterns
                .Select(aa => aa.pattern.items.Select(c => c.drill)))
                .FirstOrDefault();

            var plans = new List<training_plan_preview>();

            var patterns = training.training_patterns.OrderBy(a => a.s_date).OrderBy(a => a.orders);
            //Load all patterns related to today
            foreach (var pattern in patterns)
            {
                //Check wether has any drill for this pattern or not
                if (pattern.pattern.items.Count() > 0)
                {
                    foreach (var item in pattern.pattern.items)
                    {
                        var eventItem = new training_plan_preview();
                        //Check wether is this event recurring or not
                        if (item.periodic)
                        {
                            if (item.weekday == 8)
                            {
                                eventItem.daysofWeek = "['0','2','4']";
                            }
                            else if (item.weekday == 9)
                            {
                                eventItem.daysofWeek = "['1','3','5','6']";
                            }
                            else if (item.weekday == 10)
                            {
                                eventItem.daysofWeek = "";
                            }
                            else
                                eventItem.daysofWeek = ((item.weekday - 2) >= 0)? "['" + (item.weekday -2) + "']" : "['6']";

                            var strt = BaseDate.GetDateFromDateOffsetSystemStartDate(pattern.s_date);
                            var endd = BaseDate.GetDateFromDateOffsetSystemStartDate(pattern.e_date);

                            eventItem.recureStart = strt.Year.ToString() + "/" + strt.Month + "/" + strt.Day;
                            eventItem.recureEnd = endd.Year.ToString() + "/" + endd.Month + "/" + endd.Day;

                            eventItem.classification = item.ID.ToString() + "_" + item.pattern_id + "_" + item.drill_id;
                        }                    
                        else
                        {
                            eventItem.drill_dt = pattern.s_date;
                        }
                        var dd = DateTime.Today;
                        eventItem.drill_id = item.drill_id;
                        eventItem.drill_title = item.drill.drill_title;
                        eventItem.startTime = pattern.training.start_time;
                        eventItem.endTime = pattern.training.end_time;
                        plans.Add(eventItem);
                    }
                }
            }
            return new JsonResult { Data = plans, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // POST: trainings/Plans
        [HttpPost,ActionName("Plans"),ValidateAntiForgeryToken]
        public ActionResult PlanPostBack(int? id)
        {
            return this.Plans(id);
        }

        // GET: trainings/DetailsPlan/5
        public ActionResult DetailsPlan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var plan = db.training_patterns.Where(a => a.ID == id).Include(a => a.pattern).FirstOrDefault();

            if (plan == null)
            {
                Session["TACTION_RESULT"] = lang.dateError;
                return this.RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: trainings/CreatePlan
        public ActionResult CreatePlan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var training = db.training_terms.Find(id);

            if (training == null)
            {
                Session["TACTION_RESULT"] = lang.dateError;
                return this.RedirectToAction("Index");
            }

            //Load all age level related patterns for this class
            ViewBag.pattern_id = new SelectList(db.drill_patterns.Where(a => a.level_id == training.level_id), "ID", "title");
            
            ViewBag.training = training;
            
            return View();
        }

        // POST: trainings/CreatePlan
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlan([Bind(Include = "ID,pattern_id,training_id,start_date,end_date,orders")] training_patterns plan)
        {
            var trn = db.training_terms.Find(plan.training_id);
            if (plan.e_date < trn.s_date ||
                plan.e_date > trn.e_date ||
                plan.s_date > plan.e_date ||
                plan.s_date < trn.s_date ||
                plan.s_date > trn.e_date)
            {
                Session["TACTION_RESULT"] = lang.dateError;
                return View(plan);
            }

            if (ModelState.IsValid)
            {
                db.training_patterns.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Plans", new { id = plan.training_id });
            }

            return RedirectToAction("Createplan",plan.training_id);
        }

        // GET: trainings/EditTraining/5
        public ActionResult EditPlan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plan = db.training_patterns.Where(a => a.ID == id).Include(a => a.training).Include(a => a.pattern).FirstOrDefault();

            if (plan == null)
            {
                Session["TACTION_RESULT"] = lang.dateError;
                return this.RedirectToAction("Index");
            }

            //Load all age level related patterns for this class
            ViewBag.pattern_id = new SelectList(db.drill_patterns.Where(a => a.level_id == plan.training.level_id), "ID", "title" , plan.pattern_id);

            return View(plan);
        }

        // POST: trainings/EditPlan/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("EditPlan")]
        public ActionResult EditPlan([Bind(Include = "ID,pattern_id,training_id,start_date,end_date,orders")] training_patterns plan)
        {
            //It must be check for various conditions:
            //1.start date must be bigger than the class start date
            //2.end date must be smaller than the class end date
            //3. start date must be smaller than end date
            var trn = db.training_terms.Find(plan.training_id);
            if (plan.e_date < trn.s_date ||
                plan.e_date > trn.e_date ||
                plan.s_date > plan.e_date ||
                plan.s_date < trn.s_date ||
                plan.s_date > trn.e_date)
            {
                Session["TACTION_RESULT"] = lang.dateError;
                return this.RedirectToAction("Plans", plan.ID);
            }

            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Plans", new { id = plan.training_id });
            }
            Session["TACTION_RESULT"] = lang.generalError;
            return this.RedirectToAction("Plans", plan.ID);
        }

        // GET: trainings/DeletePlan/5
        public ActionResult DeletePlan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plan = db.training_patterns.Where(a => a.ID == id).Include(a => a.pattern).Include(a => a.training).FirstOrDefault();
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: trainings/DeletePlan/5
        [HttpPost, ActionName("DeletePlan")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlanConfirmed(int id)
        {
            var plan = db.training_patterns.Find(id);
            id = plan.training_id;
            db.training_patterns.Remove(plan);
            db.SaveChanges();
            return RedirectToAction("Plans", new { id = id });
        }
    }
}
