using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubAdministration.Library.Core.Pages;
using ClubAdministration.Models;

namespace ClubAdministration.Controllers
{
    public partial class financeController : BaseController
    {
        //GET finance/Categories
        public ActionResult Categories()
        {
            var acc = db.payment_categories.ToList()
                .Where(ac => ac.category_title.Contains(this.Setting.PageSetting.SearchItem)).ToList();
            return View(acc);
        }

        [HttpPost,ValidateAntiForgeryToken(),ActionName("Categories")]
        public ActionResult CategoriesPostBack()
        {
            return this.Categories();
        }
        public ActionResult CreateCategory()
        {
            var cats = db.payment_categories.ToList();
            cats.Add(new payment_category() { category_title = "ندارد", ID = 0 });

            ViewBag.parent_id = new SelectList(cats, "ID", "category_title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "ID,category_title,parent_id")] payment_category category)
        {
            if (ModelState.IsValid)
            {
                db.payment_categories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Categories");
        }

        public ActionResult EditCategory(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var cat = db.payment_categories.Find(id);

            var cats = db.payment_categories.Where(a => a.ID != cat.ID).ToList();
            cats.Add(new payment_category() { category_title = "ندارد", ID = 0 });

            var selec = new SelectList(cats, "ID", "category_title", cat.parent_id);
            ViewBag.parent_id = new SelectList(cats, "ID", "category_title",cat.parent_id);

            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "ID,category_title,parent_id")] payment_category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry<payment_category>(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(category);
        }

        public ActionResult DetailsCategory(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var cat = db.payment_categories.Find(id);
            var parent = (cat.parent_id > 0)? db.payment_categories.Find(cat.parent_id).category_title : "";
            ViewBag.parent = parent;

            return View(cat);
        }

        public ActionResult DeleteCategory(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var cat = db.payment_categories.Find(id);

            return View(cat);
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var cat = db.payment_categories.Find(id);
            db.payment_categories.Remove(cat);
            db.SaveChanges();

            return RedirectToAction("Categories");
        }

        public ActionResult CategoryTransactions(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var account = db.payment_categories.Find(id);
            var acc = account.payments.Where(ac => ac.payment_date.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.payment_item.Contains(this.Setting.PageSetting.SearchItem)).ToList();

            ViewBag.account = account;

            return View(acc);
        }
        [HttpPost, ActionName("CategoryTransactions"), ValidateAntiForgeryToken]
        public ActionResult CategoryTransactionPostBack(int? id)
        {
            return this.CategoryTransactions(id);
        }
    }
}