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
    public partial class permissionsController : BaseController
    {
        //private clubAdminProxy db = new clubAdminProxy();

        // GET: permissions
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.permissions
                .Where(a => a.title.Contains(this.Setting.PageSetting.SearchItem) ||
                a.command.Contains(this.Setting.PageSetting.SearchItem)).Include(a => a.component).Include(a => a.zone));
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش دسترسي وجود دارد";
                return this.RedirectToAction("Index");
            }

            var permission = db.permissions.Where(a => a.ID == id).Include(a => a.component).Include(a => a.zone).FirstOrDefault();

            if (permission == null)
            {
                Session["TACTION_RESULT"] = "دسترسي درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(permission);
        }

        // GET: permissions/Create
        public ActionResult Create()
        {
            ViewBag.parent = new SelectList(db.permissions.ToList(), "ID", "title");
            ViewBag.zones = new SelectList(db.zones.ToList(), "ID", "title");
            ViewBag.components = new SelectList(db.components.ToList(), "ID", "title");
            return View();
        }

        // POST: permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,parent,command,zone_id,component_id")] permissions permission)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.permissions.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permission);
        }


        // GET: permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = db.permissions.Find(id);

            ViewBag.parent = new SelectList(db.permissions.ToList(), "ID", "title", entry.parent);
            ViewBag.zones = new SelectList(db.zones.ToList(), "ID", "title", entry.zone_id);
            ViewBag.components = new SelectList(db.components.ToList(), "ID", "title", entry.component_id);

            return View(entry);
        }

        // POST: permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,parent,command,zone_id,component_id")] permissions permission)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        // GET: permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissions permission = db.permissions.Where(a => a.ID == id).Include(a => a.component).Include(a => a.zone).FirstOrDefault();
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var permission = db.permissions.Find(id);
            db.permissions.Remove(permission);
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