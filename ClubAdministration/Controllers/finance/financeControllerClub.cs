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
        public ActionResult ClubCosts(int? active)
        {
            var trainings = (active != null) ?
                db.training_terms.ToList().Where(a => a.active == active).ToList() : db.training_terms.ToList();
            return View(trainings.Where(a =>
            a.end_date.Contains(this.Setting.PageSetting.SearchItem) ||
            a.start_date.Contains(this.Setting.PageSetting.SearchItem) ||
            a.term_title.Contains(this.Setting.PageSetting.SearchItem)
            ));
        }

        [ActionName("ClubCosts")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClubCostPostBAck(int? active)
        {
            return this.ClubCosts(active);
        }
    }
}
