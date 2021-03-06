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
    public partial class drillsController : BaseController
    {

        // GET: drills/emphasises
        [HttpGet]
        public ActionResult emphasises()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drill_emphasises
                .Where(a => a.emphasis.Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("emphasises")]
        [ValidateAntiForgeryToken]
        public ActionResult emphasisesPostBack()
        {
            return this.emphasises();
        }

        // GET: drills/emphasisdrills
        [HttpGet]
        public ActionResult emphasisdrills(int id)
        {
            ViewBag.emphasis = db.drill_emphasises.Find(id);

            if (ViewBag.emphasis == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش تاكيد تمرين وجود دارد";
                return this.RedirectToAction("emphasises");
            }

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drills
                .Where(a => a.drill_emphasisid == id && a.drill_title.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }

        [HttpPost]
        [ActionName("emphasisdrills")]
        [ValidateAntiForgeryToken]
        public ActionResult emphasisdrillsPostBack(int id)
        {
            return this.emphasisdrills(id);
        }

        // GET: drills/Detailsemphasis/5
        public ActionResult Detailsemphasis(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش آيتم وجود دارد";
                return this.RedirectToAction("emphasises");
            }
            var emphasis = db.drill_emphasises.Find(id);

            if (emphasis == null)
            {
                Session["TACTION_RESULT"] = "آيتم درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("emphasises");
            }

            return View(emphasis);
        }

        // GET: drills/Createemphasis
        public ActionResult Createemphasis()
        {
            return View();
        }

        // POST: drillsController/Createemphasis
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createemphasis([Bind(Include = "ID,emphasis")] drill_emphasises emphasis)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.drill_emphasises.Add(emphasis);
                db.SaveChanges();
                return RedirectToAction("emphasises");
            }

            return View(emphasis);
        }

        // GET: drills/Editemphasis/5
        public ActionResult Editemphasis(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill emphasis entry
            var entry = db.drill_emphasises.Find(id);
            return View(entry);
        }

        // POST: drills/Editemphasis/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editemphasis([Bind(Include = "ID,emphasis")] drill_emphasises emphasis)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(emphasis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("emphasises");
            }
            return View(emphasis);
        }

        // GET: drills/Deleteemphasis/5
        public ActionResult Deleteemphasis(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill_emphasises emphasis = db.drill_emphasises.Find(id);
            if (emphasis == null)
            {
                return HttpNotFound();
            }
            return View(emphasis);
        }

        // POST: drills/Deleteemphasis/5
        [HttpPost, ActionName("Deleteemphasis")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteemphasisConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var emphasis = db.drill_emphasises.Find(id);
            db.drill_emphasises.Remove(emphasis);
            db.SaveChanges();
            return RedirectToAction("emphasises");
        }
    }
}