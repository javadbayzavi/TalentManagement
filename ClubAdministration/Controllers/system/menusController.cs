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
    public partial class menusController : BaseController
    {
        //private clubAdminProxy db = new clubAdminProxy();

        // GET: menus
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.menu_modules
                .Where(a => a.title.Contains(this.Setting.PageSetting.SearchItem)));
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش منو وجود دارد";
                return this.RedirectToAction("Index");
            }
            var menu = db.menu_modules.Find(id);

            if (menu == null)
            {
                Session["TACTION_RESULT"] = "منو درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: menus/Create
        public ActionResult Create()
        {
            //ViewBag.parent = new SelectList(db.menus, "ID", "title");

            return View();
        }

        // POST: menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title,menuClass")] menu_modules module)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //TODO: This action need to be deeply reviewed
                db.menu_modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: menus/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = db.menu_modules.Find(id);

           //ViewBag.parent = new SelectList(db.menus, "ID", "title", entry.parent);

            return View(entry);
        }

        // POST: menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,menuClass")] menu_modules module)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: menus/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu_modules module = db.menu_modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            bool chiddefault = db.menus.Any(a => a.module_id == module.ID && a.isDefault);

            if (chiddefault)
            {
                Session["TACTION_RESULT"] = "امكان حذف منو پيش فرض وجود ندارد. يكي از آيتم هاي منو انتخابي براي پيش فرض نرم افزار انتخاب شده است.";
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var module = db.menu_modules.Find(id);
            db.menu_modules.Remove(module);
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