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
        private clubAdminProxy db = new clubAdminProxy();

        // GET: financeController
        public ActionResult Index()
        {
            ViewBag.sumincome = db.club_deposite.Where(a => a.payment_type == 1).Sum(a => a.payment_fee);
            ViewBag.sumoutpay = db.club_deposite.Where(a => a.payment_type == 2).Sum(a => a.payment_fee);

            return View(db.club_deposite.OrderByDescending(a => a.pa_date).ToList()
                .Where(aa => aa.payment_date.Contains(this.Setting.PageSetting.SearchItem) && 
                aa.payment_item.Contains(this.Setting.PageSetting.SearchItem)).Take(10).ToList());
        }

        [HttpPost, ActionName("Index"),ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: financeController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club_deposite club_deposite = db.club_deposite.Find(id);
            if (club_deposite == null)
            {
                return HttpNotFound();
            }
            return View(club_deposite);
        }

        // GET: financeController/Create
        public ActionResult Create()
        {
            ViewBag.categories = db.payment_categories.Select(a => new SelectListItem()
            {
                Text = a.category_title,
                Value = a.ID.ToString()
            }).ToList();

            ViewBag.bankaccount_id = db.club_bankaccounts.Select(a => new SelectListItem()
            {
                Text = a.account_name,
                Value = a.ID.ToString()
            }).ToList();

            return View();
        }

        // POST: financeController/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,payment_item,payment_fee,payment_type,payment_method,payment_date,category_id,bankaccount_id")] club_deposite club_deposite)
        {
            if (ModelState.IsValid)
            {
                db.club_deposite.Add(club_deposite);
                db.SaveChanges();
                return RedirectToAction("AccountTransactions", new { id = club_deposite.bankaccount_id });
            }

            return View(club_deposite);
        }

        // GET: financeController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club_deposite club_deposite = db.club_deposite.Find(id);
            ViewBag.categories = db.payment_categories.Select(a => new SelectListItem()
            {
                Text = a.category_title,
                Value = a.ID.ToString()
            }).ToList();

            ViewBag.bankaccount_id = db.club_bankaccounts.Select(a => new SelectListItem()
            {
                Text = a.account_name,
                Value = a.ID.ToString(),
                Selected = (a.ID == club_deposite.bankaccount_id) ? true : false
            }).ToList();

            if (club_deposite == null)
            {
                return HttpNotFound();
            }
            return View(club_deposite);
        }

        // POST: financeController/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,payment_item,payment_fee,payment_method,payment_type,payment_date,category_id,bankaccount_id")] club_deposite club_deposite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club_deposite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AccountTransactions", new { id = club_deposite.bankaccount_id });
            }
            return View(club_deposite);
        }

        // GET: financeController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club_deposite club_deposite = db.club_deposite.Find(id);
            if (club_deposite == null)
            {
                return HttpNotFound();
            }
            return View(club_deposite);
        }

        // POST: financeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            club_deposite club_deposite = db.club_deposite.Find(id);
            var bid = club_deposite.bankaccount_id;

            db.club_deposite.Remove(club_deposite);
            db.SaveChanges();
            return RedirectToAction("AccountTransactions", new { id = bid });
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
