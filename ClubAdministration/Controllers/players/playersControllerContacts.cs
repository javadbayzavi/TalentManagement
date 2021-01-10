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
    public partial class playersController : BaseController
    {
        public ActionResult Contacts(int? id)
        {
            ViewBag.training_id = new SelectList(db.training_terms, "ID", "term_title");
            var playerslst = db.players.Select(e => new
            {
                ID = e.ID,
                player_name = e.name + " " + e.familiy
            }).ToList();

            ViewBag.player_id = new SelectList(playerslst, "ID", "player_name");
            ViewBag.training = db.player_registerations.Where(e => e.player_id == id).ToList();
            return View();
        }
    }
}
