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
        private clubAdminProxy db = new clubAdminProxy();

        // GET: metricsController
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.metrics
                .Where(a => a.name.Contains(this.Setting.PageSetting.SearchItem) || 
                a.tips.Contains(this.Setting.PageSetting.SearchItem)) ;
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
                // TODO: error text must be changed accordinglly
                Session["TACTION_RESULT"] = "مشكل در نمايش تمرينات وجود دارد";
                return this.RedirectToAction("Index");
            }
        
            var metric = db.metrics.Where(a => a.ID == id).;
                
            if (metric == null)
            {
                // TODO: error text must be changed accordinglly
                Session["TACTION_RESULT"] = "تمرين درخواستي در سيستم ثبت نشده است";
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,tips " metrics metricentry)
        {


            //1. Convert the entry to Db Model
            if (ModelState.IsValid == false)
            {
                db.metrics.Add(metricentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drillentry);
        }

        // GET: drills/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill drill = db.drills.Find(id);

            if (drill == null)
            {
                return HttpNotFound();
            }
            //TODO: This action need to be deeply reviewed
            //1. Load Age level
            this.ViewBag.age_levelid = new SelectList(db.agelevels.ToList(), "ID", "level",drill.agelevel_id);
            //2. Load Drill Type
            //this.ViewBag.drill_typeid = new SelectList(db.drill_types.ToList(), "ID", "title",drill.drill_typeid);
            //3. Load Drill Emphasis
            this.ViewBag.drill_emphasisid = new SelectList(db.drill_emphasises.ToList(), "ID", "emphasis",drill.drill_emphasisid);
            //4. Load Drill Positions
            this.ViewBag.participating_positionsid = new SelectList(db.positions.ToList(), "ID", "title", drill.participating_positionsid);
            //5. Load Drill Locations
            this.ViewBag.drill_locationid = new SelectList(db.drill_locations.ToList(), "ID", "title",drill.drill_location);
            //6. Load Drill required Materials
            //7. Load Drill target skills

            return View(drill);
        }

        // POST: drills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,drill_target,drill_title,goals,execution," +
            "variations,progression,coachingtips,organization,competition,drill_emphasisid,agelevel_id,level_play," +
            "drill_structure,drill_typeid,playernumbers,participating_positionsid,drill_locationid," +
            "drill_duration,fieldsize")] drill drill)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                //TODO: Update material lists
                //TODO: Update skills list
                db.Entry(drill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drill);
        }

        // GET: club/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill drill = db.drills.Find(id);
            if (drill == null)
            {
                return HttpNotFound();
            }
            return View(drill);
        }

        // POST: drills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            drill drill = db.drills.Find(id);
            db.drills.Remove(drill);
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