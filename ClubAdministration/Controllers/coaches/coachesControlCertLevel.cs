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
        public ActionResult Levels()
        {
            var acc = db.certificates_levels.ToList()
                .Where(ac => ac.title.Contains(this.Setting.PageSetting.SearchItem)).ToList();
            return View(acc);
        }

        [HttpPost,ValidateAntiForgeryToken(),ActionName("Levels")]
        public ActionResult LevelsPostBack()
        {
            return this.Levels();
        }
        public ActionResult CreateLevel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLevel([Bind(Include = "ID,title")] certificates_levels level)
        {
            if (ModelState.IsValid)
            {
                db.certificates_levels.Add(level);
                db.SaveChanges();
            }
            return RedirectToAction("Levels");
        }

        public ActionResult EditLevel(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var level = db.certificates_levels.Find(id);


            return View(level);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLevel([Bind(Include = "ID,title")] certificates_levels level)
        {
            if (ModelState.IsValid)
            {
                db.Entry<certificates_levels>(level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Levels");
            }
            return View(level);
        }

        public ActionResult DetailsLevel(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var level = db.certificates_levels.Find(id);

            return View(level);
        }

        public ActionResult DeleteLevel(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var level = db.certificates_levels.Find(id);

            return View(level);
        }

        [HttpPost, ActionName("DeleteLevel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLevelConfirmed(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var level = db.certificates_levels.Find(id);
            db.certificates_levels.Remove(level);
            db.SaveChanges();

            return RedirectToAction("Levels");
        }

        public ActionResult LevelCertificates(int? id)
        {
            if (id == null || id < 1)
                return HttpNotFound();

            var level = db.certificates_levels.Find(id);
            var acc = level.certificates.Where(ac => ac.certificate_title.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.certificate_expiredate.Contains(this.Setting.PageSetting.SearchItem)||
                ac.certificate_date.Contains(this.Setting.PageSetting.SearchItem) ||
                ac.coach.FullName.Contains(this.Setting.PageSetting.SearchItem)
                ).ToList();

            ViewBag.level = level;

            return View(acc);
        }
        [HttpPost, ActionName("LevelCertificates"), ValidateAntiForgeryToken]
        public ActionResult LevelCertificatesPostBack(int? id)
        {
            return this.IssuerCertificates(id);
        }
    }
}