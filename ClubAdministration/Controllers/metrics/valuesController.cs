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

        // GET: metrics/values/5
        [HttpGet]
        public ActionResult values(int id)
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.metric_values
                .Where(a => a.value.Contains(this.Setting.PageSetting.SearchItem) ||
                a.instance.alias.Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("values")]
        [ValidateAntiForgeryToken]
        public ActionResult valuesPostBack(int id)
        {
            return this.values(id);
        }

        // GET: metrics/values/Detailsinstance/5
        public ActionResult Detailsvalues(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش مقادير وجود دارد";
                return this.RedirectToAction("values");
            }

            var value = db.metric_values.Find(id);

            if (value == null)
            {
                Session["TACTION_RESULT"] = "مقادير درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("values");
            }

            return View(value);
        }

        // GET: metrics/values/Createinstance
        public ActionResult Createvalue()
        {
            return View();
        }

        // POST: metrics/values/Createinstance
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createvalue([Bind(Include = "ID,value,modified_date, instance_id")] metric_values metricentry)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == false)
            {
                db.metric_values.Add(metricentry);
                db.SaveChanges();
                return RedirectToAction("values");
            }

            return View(metricentry);
        }

        // GET: metrics/values/Editinstance/5
        public ActionResult Editvalue(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metric_values metric = db.metric_values.Find(id);

            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/values/Editinstance/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editvalue([Bind(Include = "ID,alias,baseline, target, frequency, metric_id")] metric_values metricentry)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(metricentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("instance");
            }
            return View(metricentry);
        }

        // GET: metrics/values/Deleteinstance/5
        public ActionResult Deletevalue(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metric_values metric = db.metric_values.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/values/Deleteinstance/5
        [HttpPost, ActionName("Deletevalue")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletevalueConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            metric_values metric = db.metric_values.Find(id);
            db.metric_values.Remove(metric);
            db.SaveChanges();
            return RedirectToAction("value");
        }
    }
}