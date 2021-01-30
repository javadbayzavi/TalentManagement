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
using ClubAdministration.Resources.modules.drill.items;
namespace ClubAdministration.Controllers
{
    public partial class drillsController : BaseController
    {

        // GET: drills/Detailsitem/5
        public ActionResult Detailsitem(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = lang.itemShowError;
                return this.RedirectToAction("patterns");
            }
            var patternitem = db.pattern_items.Where(a => a.ID == id).Include(a => a.pattern).Include(a => a.drill).FirstOrDefault();

            if (patternitem == null)
            {
                Session["TACTION_RESULT"] = lang.itemNotFound;
                return this.RedirectToAction("patterns");
            }

            return View(patternitem);
        }

        // GET: drills/Createitem
        public ActionResult Createitem()
        {
            ////Load all patterns
            //ViewBag.pattern_id = new SelectList(db.drill_patterns.ToList(), "ID", "title");

            //Load alll drills
            ViewBag.drill_id = new SelectList(db.drills.ToList(), "ID", "drill_title");
            return View();
        }

        // POST: drillsController/Createitem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createitem([Bind(Include = "ID,pattern_id,drill_id,periodic,weekday,drill_hour")] pattern_items item)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.pattern_items.Add(item);
                db.SaveChanges();
                return RedirectToAction("patternitems" , new { id = item.pattern_id});
            }

            return View(item);
        }

        // GET: drills/Editpattern/5
        public ActionResult Edititem(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill pattern entry
            var entry = db.pattern_items.Find(id);
            ////Load all patterns
            //ViewBag.pattern_id = new SelectList(db.drill_patterns.ToList(), "ID", "title",entry.pattern_id);

            //Load alll drills
            ViewBag.drill_id = new SelectList(db.drills.ToList(), "ID", "drill_title",entry.drill_id);

            return View(entry);
        }

        // POST: drills/Editpattern/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edititem([Bind(Include = "ID,pattern_id,drill_id,periodic,weekday,drill_hour")] pattern_items item)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("patternitems" , new { item.pattern_id });
            }
            return View(item);
        }

        // GET: drills/Deletepattern/5
        public ActionResult Deleteitem(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patternitem = db.pattern_items.Where(a => a.ID == id).Include(a => a.pattern).Include(a => a.drill).FirstOrDefault();

            if (patternitem == null)
            {
                return HttpNotFound();
            }
            return View(patternitem);
        }

        // POST: drills/Deletepattern/5
        [HttpPost, ActionName("Deleteitem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteitemConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var item = db.pattern_items.Find(id);
            id = item.pattern_id;
            db.pattern_items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("patternitems" , new { id });
        }
    }
}