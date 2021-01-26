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
    public partial class positionsController : BaseController
    {
        private clubAdminProxy db = new clubAdminProxy();

        // GET: skills
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.positions
                .Where(a => a.title .Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش پست وجود دارد";
                return this.RedirectToAction("Index");
            }
            var postion = db.positions.Find(id);

            if (postion == null)
            {
                Session["TACTION_RESULT"] = "پست درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(postion);
        }

        // GET: positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title")] position postion)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.positions.Add(postion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postion);
        }

        // GET: positions/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill type entry
            var entry = db.positions.Find(id);
            return View(entry);
        }

        // POST: positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title")] position position)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: positions/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            position position = db.positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var postion = db.positions.Find(id);
            db.positions.Remove(postion);
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