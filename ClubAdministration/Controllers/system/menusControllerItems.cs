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

        // GET: menus/items
        [HttpGet]
        public ActionResult items(int id)
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            ViewBag.menuid = id;
            return View(db.menus
                .Where(a => a.module_id == id && a.title.Contains(this.Setting.PageSetting.SearchItem)).Include(a => a.module));
        }

        // POST: menus/items
        [HttpPost]
        [ActionName("items")]
        [ValidateAntiForgeryToken]
        public ActionResult itemsPostBack(int id)
        {
            return this.Index();
        }

        // GET: menus/Detailsitem/5
        public ActionResult Detailsitem(int? id, int parent)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش آيتم منو وجود دارد";
                return this.RedirectToAction("items", new { id = parent });
            }
            var menu = db.menus.Find(id);

            if (menu == null)
            {
                Session["TACTION_RESULT"] = "آيتم منو درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index", new { id = parent });
            }

            return View(menu);
        }

        // GET: menus/Createitem
        public ActionResult Createitem(int id)
        {
            var ss = new SelectList(db.menus.Where(a => a.module_id == id), "ID", "title");
            ViewBag.parent = new SelectList(db.menus.Where(a => a.module_id == id), "ID", "title");
            ViewBag.module_id = id;
            return View();
        }

        // POST: menus/Createitem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createitem([Bind(Include = "ID,title,target,palceholder,parent,isDefault,url,module_id")] menus menu)
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
                return RedirectToAction("items" , new { id = menu.module_id });
            }

            return View(menu);
        }

        // GET: menus/Edititem/5
        public ActionResult Edititem(int? id, int parent)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش آيتم منو وجود دارد";
                return this.RedirectToAction("items", new { id = parent });
            }

            var entry = db.menus.Find(id);
            ViewBag.module_id = id;

            ViewBag.parent = new SelectList(db.menus.Where(a => a.parent == parent), "ID", "title", entry.parent);

            return View(entry);
        }

        // POST: menus/Edititem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edititem([Bind(Include = "ID,title,target,palceholder,parent,menuClass,isDefault,url")] menus menu)
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
                return RedirectToAction("items", new { id = menu.module_id });
            }
            return View(menu);
        }

        // GET: menus/Deleteitem/5
        public ActionResult Deleteitem(int? id)
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
            return View(menu);
        }

        // POST: menus/DeleteitemConfirmed/5
        [HttpPost, ActionName("Deleteitem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteitemConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            var menu = db.menus.Find(id);
            db.menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("items");
        }
    }
}