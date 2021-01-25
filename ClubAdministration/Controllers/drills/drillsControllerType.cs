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

        // GET: drills/types
        [HttpGet]
        public ActionResult types()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drill_types
                .Where(a => a.title.Contains(this.Setting.PageSetting.SearchItem)));
        }

        // GET: drills/typedrills
        [HttpGet]
        public ActionResult typedrills(int id)
        {
            ViewBag.type = db.drill_types.Find(id);

            if (ViewBag.type == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش نوع وجود دارد";
                return this.RedirectToAction("types");
            }

            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drills
                .Where(a => a.drill_typeid == id && a.drill_title.Contains(this.Setting.PageSetting.SearchItem)).ToList());
        }

        [HttpPost]
        [ActionName("typedrills")]
        [ValidateAntiForgeryToken]
        public ActionResult typesPostBack(int id)
        {
            return this.typedrills(id);
        }

        [HttpPost]
        [ActionName("types")]
        [ValidateAntiForgeryToken]
        public ActionResult typesPostBack()
        {
            return this.types();
        }

        // GET: drills/Detailstype/5
        public ActionResult Detailstype(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش نوع وجود دارد";
                return this.RedirectToAction("types");
            }
            var type = db.drill_types.Find(id);

            if (type == null)
            {
                Session["TACTION_RESULT"] = "نوع درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("types");
            }

            return View(type);
        }

        // GET: drills/Createtype
        public ActionResult Createtype()
        {
            return View();
        }

        // POST: drillsController/Createtype
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createtype([Bind(Include = "ID,title")] drill_types drillentry)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.drill_types.Add(drillentry);
                db.SaveChanges();
                return RedirectToAction("types");
            }

            return View(drillentry);
        }

        // GET: drills/Edittype/5
        public ActionResult Edittype(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill type entry
            var entry = db.drill_types.Find(id);
            return View(entry);
        }

        // POST: drills/Edittype/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edittype([Bind(Include = "ID,title")] drill_types type)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("types");
            }
            return View(type);
        }

        // GET: drills/Deletetype/5
        public ActionResult Deletetype(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill_types type = db.drill_types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: drills/Deletetype/5
        [HttpPost, ActionName("Deletetype")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletetypeConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var type = db.drill_types.Find(id);
            db.drill_types.Remove(type);
            db.SaveChanges();
            return RedirectToAction("types");
        }
    }
}