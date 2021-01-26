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

namespace ClubAdministration.Controllers.coaches
{
    public partial class coachesController : BaseController
    {
        //GET finance/Categories
        public ActionResult Issuers()
        {
            var acc = db.certificates_issuers.ToList()
                .Where(ac => ac.title.Contains(this.Setting.PageSetting.SearchItem)).ToList();
            return View(acc);
        }

        [HttpPost,ValidateAntiForgeryToken(),ActionName("Issuers")]
        public ActionResult IssuersPostBack()
        {
            return this.Issuers();
        }
        public ActionResult CreateIssuer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIssuer([Bind(Include = "ID,title")] certificates_issuer issuer)
        {
            if (ModelState.IsValid)
            {
                db.certificates_issuers.Add(issuer);
                db.SaveChanges();
            }
            return RedirectToAction("Issuers");
        }

        public ActionResult EditIssuer(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var issu = db.certificates_issuers.Find(id);


            return View(issu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditIssuer([Bind(Include = "ID,title")] certificates_issuer issuer)
        {
            if (ModelState.IsValid)
            {
                db.Entry<certificates_issuer>(issuer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Issuers");
            }
            return View(issuer);
        }

        public ActionResult DetailsIssuer(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var issuer = db.certificates_issuers.Find(id);

            return View(issuer);
        }

        public ActionResult DeleteIssuer(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var issuer = db.certificates_issuers.Find(id);

            return View(issuer);
        }

        [HttpPost, ActionName("DeleteIssuer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIssuerConfirmed(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var issuer = db.certificates_issuers.Find(id);
            db.certificates_issuers.Remove(issuer);
            db.SaveChanges();

            return RedirectToAction("Issuers");
        }

        public ActionResult IssuerCertificates(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var issuer = db.certificates_issuers.Find(id);
            var acc = issuer.certificates.Where(ac => ac.certificate_title.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.certificate_expiredate.Contains(this.Setting.PageSetting.SearchItem)||
                ac.certificate_date.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.coach.FullName.Contains(this.Setting.PageSetting.SearchItem)
                ).ToList();

            ViewBag.account = issuer;

            return View(acc);
        }
        [HttpPost, ActionName("IssuerCertificates"), ValidateAntiForgeryToken]
        public ActionResult IssuerCertificatesPostBack(int? id)
        {
            return this.IssuerCertificates(id);
        }
    }
}