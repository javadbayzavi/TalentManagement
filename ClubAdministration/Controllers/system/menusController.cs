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
        private clubAdminProxy db = new clubAdminProxy();

        // GET: menus
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.menus
                .Where(a => a.parent == 0 && a.title.Contains(this.Setting.PageSetting.SearchItem)));
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
            var menu = db.menus.Find(id);

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
        public ActionResult Create([Bind(Include = "ID,title,target,palceholder,parent,menuClass,isDefault,url")] menus menu)
        {

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == true)
            {
                //Check to set only one default menu item for app
                if (menu.isDefault)
                {
                    var prevdefault = db.menus.Where(a => a.isDefault).FirstOrDefault();
                    if (prevdefault != null)
                    {
                        prevdefault.isDefault = false;
                        db.Entry(prevdefault).State = EntityState.Modified;
                    }
                }
                //TODO: This action need to be deeply reviewed
                db.menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: menus/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = db.menus.Find(id);

           //ViewBag.parent = new SelectList(db.menus, "ID", "title", entry.parent);

            return View(entry);
        }

        // POST: menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title,target,palceholder,parent,menuClass,isDefault,url")] menus menu)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                //Check to set only one default menu item for app
                if (menu.isDefault)
                {
                    var prevdefault = db.menus.Where(a => a.isDefault).FirstOrDefault();
                    if (prevdefault != null)
                    {
                        prevdefault.isDefault = false;
                        db.Entry(prevdefault).State = EntityState.Modified;
                    }
                }
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: menus/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menus menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            bool chiddefault = db.menus.Any(a => a.parent == menu.ID && a.isDefault);
            bool hasChild = db.menus.Any(a => a.parent == menu.ID);

            if (menu.isDefault || chiddefault)
            {
                Session["TACTION_RESULT"] = "امكان حذف منو پيش فرض وجود ندارد. يكي از آيتم هاي منو انتخابي براي پيش فرض نرم افزار انتخاب شده است.";
                return RedirectToAction("Index");
            }

            if(hasChild)
            {
                Session["TACTION_RESULT"] = "اين منو تعدادي گزينه  فعال دارد و امكان حذف آن وجود ندارد";
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var menu = db.menus.Find(id);
            db.menus.Remove(menu);
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