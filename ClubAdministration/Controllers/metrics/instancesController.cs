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
    public partial class instancesController : BaseController
    {
        private clubAdminProxy db = new clubAdminProxy();

        // GET: metricsController
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.metric_instances
                .Where(a => a.alias.Contains(this.Setting.PageSetting.SearchItem) || 
                a.metric.name.Contains(this.Setting.PageSetting.SearchItem))) ;
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: metrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش معيار وجود دارد";
                return this.RedirectToAction("Index");
            }
        
            var metric = db.metric_instances.Find(id);
                
            if (metric == null)
            {
                Session["TACTION_RESULT"] = "معيار درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(metric);
        }

        // GET: metrics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: metrics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,alias,tips, direction, upperBound, lowerBound ")] metric_instances metricentry)
        {


            //1. Convert the entry to Db Model
            if (ModelState.IsValid == false)
            {
                db.metric_instances.Add(metricentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metricentry);
        }

        // GET: metrics/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metrics metric = db.metrics.Find(id);

            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,tips, direction, upperBound, lowerBound ")] metrics metricentry)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(metricentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metricentry);
        }

        // GET: metrics/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metrics metric = db.metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: metrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            metrics metric = db.metrics.Find(id);
            db.metrics.Remove(metric);
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