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

        // GET: coaches/Certificates
        public ActionResult Certificates(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش مدارك مربيگري";
                return this.RedirectToAction("Index");
            }
            coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                Session["TACTION_RESULT"] = "كلاس آموزشي درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            ViewBag.coach = coach;

            var list = coach.coach_certificates
                .Where(a =>
                a.certificate_title.Contains(this.Setting.PageSetting.SearchItem) ||
                a.issuer.title.Contains(this.Setting.PageSetting.SearchItem)
                ).ToList();

            return View(list);
        }

        // POST: coaches/Certificates
        [HttpPost, ActionName("Certificates"),ValidateAntiForgeryToken]
        public ActionResult CertificatesPostBack(int? id)
        {
            return this.Certificates(id);
        }

        // GET: coaches/DetailsCertificate/5
        public ActionResult DetailsCertificate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var certificate = db.coach_certificates.Find(id);

            if (certificate == null)
            {
                return HttpNotFound();
            }

            certificate.issuer = db.certificates_issuers.Find(certificate.issuer_id);

            return View(certificate);
        }

        // GET: coaches/CreateCertificate
        public ActionResult CreateCertificate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coach = db.coaches.Find(id);

            if (coach == null)
            {
                return HttpNotFound();
            }

            var trtrm = db.certificates_issuers.ToList();

            ViewBag.issuer_id = new SelectList(trtrm, "ID", "title");

            ViewBag.coach = coach;
            return View();
        }

        // POST: coaches/CreateCertificate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("CreateCertificate")]
        public ActionResult CreateCertificate([Bind(Include = "coach_id,certificate_title,certificate_date,certificate_expiredate,issuer_id")] coach_certificates certificate)
        {
            //Expire date must be bigger than the issuing date
            if(certificate.cert_date > certificate.cert_expdate)
            {
                Session["TACTION_RESULT"] = "تاريخ هاي ورودي را كنترل كنيد";
                return this.RedirectToAction("Certificates", certificate);
            }
            if (ModelState.IsValid)
            {
                db.coach_certificates.Add(certificate);
                db.SaveChanges();
                return RedirectToAction("Certificates", new { id = certificate.coach_id });
            }

            return View(certificate);
        }

        // GET: coaches/EditCertificate/5
        public ActionResult EditCertificate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var certificate = db.coach_certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.issuer_id = new SelectList(db.certificates_issuers, "ID", "title", certificate.issuer_id);

            var coach = db.coaches.Find(certificate.coach_id);
            ViewBag.coach = coach;

            return View(certificate);
        }

        // POST: coaches/EditCertificate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCertificate([Bind(Include = "ID,coach_id,certificate_title,certificate_date,certificate_expiredate,issuer_id")] coach_certificates certificate)
        {
            //Expire date must be bigger than the issuing date
            if (certificate.cert_date > certificate.cert_expdate)
            {
                Session["TACTION_RESULT"] = "تاريخ هاي ورودي را كنترل كنيد";
                return this.RedirectToAction("Certificates", certificate);
            }

            if (ModelState.IsValid)
            {
                db.Entry(certificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Certificates", new { id = certificate.coach_id });
            }
            return View(certificate);
        }

        // GET: coaches/DeleteCertificate/5
        public ActionResult DeleteCertificate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coach_certificates certi = db.coach_certificates.Find(id);
            if (certi == null)
            {
                return HttpNotFound();
            }

            certi.issuer = db.certificates_issuers.Find(certi.issuer_id);

            return View(certi);
        }

        // POST: coaches/DeleteCertificate/5
        [HttpPost, ActionName("DeleteCertificate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCertificateConfirmed(int id)
        {
            var certificate = db.coach_certificates.Find(id);
            int coach_id = certificate.coach_id;
            db.coach_certificates.Remove(certificate);
            db.SaveChanges();
            return RedirectToAction("Certificates", new { id = coach_id });
        }
    }
}
