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
using ClubAdministration.Resources.modules.drill.pattern;
namespace ClubAdministration.Controllers
{
    public partial class drillsController : BaseController
    {

        // GET: drills/patterns
        [HttpGet]
        public ActionResult patterns()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drill_patterns
                .Where(a => a.title.Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("patterns")]
        [ValidateAntiForgeryToken]
        public ActionResult patternsPostBack()
        {
            return this.patterns();
        }

        // GET: drills/patterndrills
        [HttpGet]
        public ActionResult patternitems(int id)
        {
            ViewBag.pattern = db.pattern_items.Find(id);

            if (ViewBag.items == null)
            {
                Session["TACTION_RESULT"] = lang.patternShowError ;
                return this.RedirectToAction("patterns");
            }

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drills
                .Where(a => a.drill_typeid == id && a.drill_title.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }

        [HttpPost]
        [ActionName("patternditems")]
        [ValidateAntiForgeryToken]
        public ActionResult patternitemsPostBack(int id)
        {
            return this.patternitems(id);
        }

        // GET: drills/Detailspattern/5
        public ActionResult Detailspattern(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = lang.patternShowError;
                return this.RedirectToAction("patterns");
            }
            var pattern = db.drill_patterns.Where(a => a.ID == id).Include(a => a.agelevel).FirstOrDefault();

            if (pattern == null)
            {
                Session["TACTION_RESULT"] = lang.patternNotFound;
                return this.RedirectToAction("patterns");
            }

            return View(pattern);
        }

        // GET: drills/Createpattern
        public ActionResult Createpattern()
        {
            ViewBag.level_id = new SelectList(db.agelevels.ToList(), "ID", "level");
            return View();
        }

        // POST: drillsController/Createpattern
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createpattern([Bind(Include = "ID,title,level_id")] drill_patterns pattern)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.drill_patterns.Add(pattern);
                db.SaveChanges();
                return RedirectToAction("patterns");
            }

            return View(pattern);
        }

        // GET: drills/Editpattern/5
        public ActionResult Editpattern(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill pattern entry
            var entry = db.drill_patterns.Find(id);
            ViewBag.level_id = new SelectList(db.agelevels.ToList(), "ID", "level", entry.level_id);

            return View(entry);
        }

        // POST: drills/Editpattern/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editpattern([Bind(Include = "ID,title,level_id")] drill_patterns pattern)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(pattern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("patterns");
            }
            return View(pattern);
        }

        // GET: drills/Deletepattern/5
        public ActionResult Deletepattern(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            drill_patterns pattern = db.drill_patterns.Where(a => a.ID == id).Include(a => a.agelevel).FirstOrDefault();

            if (pattern == null)
            {
                return HttpNotFound();
            }
            return View(pattern);
        }

        // POST: drills/Deletepattern/5
        [HttpPost, ActionName("Deletepattern")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletepatternConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var pattern = db.drill_patterns.Find(id);
            db.drill_patterns.Remove(pattern);
            db.SaveChanges();
            return RedirectToAction("patterns");
        }
    }
}