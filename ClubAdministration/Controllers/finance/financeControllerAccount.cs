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
        //GET finance/Accounts
        public ActionResult Accounts()
        {
            var acc = db.club_bankaccounts.ToList()
                .Where(ac => ac.account_name.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.account_issuer.Contains(this.Setting.PageSetting.SearchItem)).ToList();
            return View(acc);
        }

        [HttpPost,ValidateAntiForgeryToken(),ActionName("Accounts")]
        public ActionResult AccountsPostBack()
        {
            return this.Accounts();
        }
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount([Bind(Include = "ID,account_name,account_issuer,payment_method")] club_bankaccounts account)
        {
            if (ModelState.IsValid)
            {
                db.club_bankaccounts.Add(account);
                db.SaveChanges();
            }
            return RedirectToAction("Accounts");
        }

        public ActionResult EditAccount(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var acc = db.club_bankaccounts.Find(id);

            return View(acc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount([Bind(Include = "ID,account_name,account_issuer,payment_method")] club_bankaccounts account)
        {
            if (ModelState.IsValid)
            {
                db.Entry<club_bankaccounts>(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Accounts");
            }
            return View(account);
        }

        public ActionResult DetailsAccount(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var acc = db.club_bankaccounts.Find(id);

            return View(acc);
        }

        public ActionResult DeleteAccount(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var acc = db.club_bankaccounts.Find(id);

            return View(acc);
        }

        [HttpPost, ActionName("DeleteAccount")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccountConfirmed(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var acc = db.club_bankaccounts.Find(id);
            db.club_bankaccounts.Remove(acc);
            db.SaveChanges();

            return RedirectToAction("Accounts");
        }

        public ActionResult AccountTransactions(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var account = db.club_bankaccounts.Find(id);
            var acc = account.deposites.Where(ac => ac.payment_date.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.payment_item.Contains(this.Setting.PageSetting.SearchItem)).ToList();

            ViewBag.account = account;

            return View(acc);
        }
        [HttpPost, ActionName("AccountTransactions"), ValidateAntiForgeryToken]
        public ActionResult AccountTransactionPostBack(int? id)
        {
            return this.AccountTransactions(id);
        }
    }
}