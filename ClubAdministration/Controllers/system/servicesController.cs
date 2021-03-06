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
    public partial class servicesController : BaseController
    {

        // GET: services
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action(services) needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.services
                .Where(a => a.title.Contains(this.Setting.PageSetting.SearchItem) ||
                a.name.Contains(this.Setting.PageSetting.SearchItem))
                );
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش سرويس وجود دارد";
                return this.RedirectToAction("Index");
            }
            var service = db.services.Find(id);

            if (service == null)
            {
                Session["TACTION_RESULT"] = "سرويس درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: services/Create
        public ActionResult Create()
        {
            var parent = new SelectList(db.services.ToList(), "ID", "title");
            ViewBag.parent = parent;
            return View();
        }

        // POST: groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,name,parent")] services service)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: services/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = db.services.Find(id);
            var parent = new SelectList(db.services.ToList(), "ID", "title",entry.parent);
            ViewBag.parent = parent;
            return View(entry);
        }

        // POST: services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,name,parent")] services service)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: services/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            services service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var service = db.services.Find(id);
            db.services.Remove(service);
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