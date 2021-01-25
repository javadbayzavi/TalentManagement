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

        // GET: drills/locations
        [HttpGet]
        public ActionResult locations()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drill_locations
                .Where(a => a.location.Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("locations")]
        [ValidateAntiForgeryToken]
        public ActionResult locationsPostBack()
        {
            return this.locations();
        }

        // GET: drills/locationdrills
        [HttpGet]
        public ActionResult locationdrills(int id)
        {
            ViewBag.location = db.drill_locations.Find(id);

            if (ViewBag.location == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش مكان وجود دارد";
                return this.RedirectToAction("locations");
            }

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drills
                .Where(a => a.drill_locationid == id && a.drill_title.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }

        [HttpPost]
        [ActionName("locationdrills")]
        [ValidateAntiForgeryToken]
        public ActionResult locationdrillsPostBack(int id)
        {
            return this.locationdrills(id);
        }

        // GET: drills/Detailslocation/5
        public ActionResult Detailslocation(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش مكان‌ وجود دارد";
                return this.RedirectToAction("locations");
            }
            var location = db.drill_locations.Find(id);

            if (location == null)
            {
                Session["TACTION_RESULT"] = "مكان درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("locations");
            }

            return View(location);
        }

        // GET: drills/Createlocation
        public ActionResult Createlocation()
        {
            return View();
        }

        // POST: drillsController/Createlocation
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createlocation([Bind(Include = "ID,location")] drill_locations location)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.drill_locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("locations");
            }

            return View(location);
        }

        // GET: drills/Editlocation/5
        public ActionResult Editlocation(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill type entry
            var entry = db.drill_locations.Find(id);
            return View(entry);
        }

        // POST: drills/Editlocation/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editlocation([Bind(Include = "ID,location")] drill_locations location)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("locations");
            }
            return View(location);
        }

        // GET: drills/Deletelocations/5
        public ActionResult Deletelocations(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill_locations location = db.drill_locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: drills/Deletelocation/5
        [HttpPost, ActionName("Deletelocation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletelocationConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var location = db.drill_locations.Find(id);
            db.drill_locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("locations");
        }
    }
}