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
using ClubAdministration.Models.system;
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers.system
{
    public partial class templatesController : BaseController
    {
        private clubAdminProxy db = new clubAdminProxy();

        // GET: templates
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.templates
                .Where(a => a.title .Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: templates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش قالب وجود دارد";
                return this.RedirectToAction("Index");
            }
            var group = db.templates.Find(id);

            if (group == null)
            {
                Session["TACTION_RESULT"] = "قالب درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: templates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: templates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,isdefault,admin,address")] templates template)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.templates.Add(template);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(template);
        }

        // GET: templates/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = db.templates.Find(id);
            return View(entry);
        }

        // POST: templates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,isdefault,admin,address")] templates template)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(template).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(template);
        }

        // GET: templates/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            groups group = db.groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: templates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var template = db.templates.Find(id);
            db.templates.Remove(template);
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