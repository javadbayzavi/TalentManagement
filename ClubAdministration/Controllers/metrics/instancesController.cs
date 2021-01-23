using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Models;
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers
{
    public partial class metricsController : BaseController
    {

        // GET: metrics/instances/
        [HttpGet]
        public ActionResult instances()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.metric_instances
                .Where(a => a.alias.Contains(this.Setting.PageSetting.SearchItem) || 
                a.metric.name.Contains(this.Setting.PageSetting.SearchItem))) ;
        }

        [HttpPost]
        [ActionName("instance")]
        [ValidateAntiForgeryToken]
        public ActionResult instancePostBack()
        {
            return this.instances();
        }

        // GET: metrics/instances/Detailsinstance/5
        public ActionResult Detailsinstance(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش معيار وجود دارد";
                return this.RedirectToAction("instances");
            }
        
            var metric = db.metric_instances.Find(id);
                
            if (metric == null)
            {
                Session["TACTION_RESULT"] = "معيار درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("instances");
            }

            return View(metric);
        }

        // GET: metrics/instances/Createinstance
        public ActionResult Createinstance()
        {
            return View();
        }

        // POST: metrics/instances/Createinstance
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createinstance([Bind(Include = "ID,alias,baseline, target, frequency, metric_id")] metric_instances metricentry)
        {


            //1. Convert the entry to Db Model
            if (ModelState.IsValid == false)
            {
                db.metric_instances.Add(metricentry);
                db.SaveChanges();
                return RedirectToAction("instances");
            }

            return View(metricentry);
        }

        // GET: metrics/instances/Editinstance/5
        public ActionResult Editinstance(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metric_instances metric = db.metric_instances.Find(id);

            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/instances/Editinstance/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editinstance([Bind(Include = "ID,alias,baseline, target, frequency, metric_id")] metric_instances metricentry)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(metricentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("instances");
            }
            return View(metricentry);
        }

        // GET: metrics/instances/Deleteinstance/5
        public ActionResult Deleteinstance(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metric_instances metric = db.metric_instances.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/instances/Deleteinstance/5
        [HttpPost, ActionName("Deleteinstance")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteinstanceConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            metric_instances metric = db.metric_instances.Find(id);
            db.metric_instances.Remove(metric);
            db.SaveChanges();
            return RedirectToAction("instances");
        }

    }
}