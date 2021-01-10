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
        public ActionResult Bodyshape(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var player = db.players.Find(id);
            var playershape = player.player_bodyshapes.ToList();

            ViewBag.player = player;

            return View();
        }

        public ActionResult Createshape(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var player = db.players.Find(id);
            ViewBag.player = player;
            
            return View();

        }

        [HttpPost, ActionName("Createshape"), ValidateAntiForgeryToken()]
        public ActionResult CreateshapePostBack([Bind(Include = "player_id,height,weight,datereg")] player_bodyshapes shape)
        {
            if (ModelState.IsValid)
            {
                db.player_bodyshapes.Add(shape);
                db.SaveChanges();
                return this.RedirectToAction("Bodyshape", new { id = shape.player_id });
            }
            else
            {
                Session["TACTION_RESULT"] = "ورودي‌ها را كنترل كنيد";
            }
            return View(shape);
        }

        public ActionResult Editshape(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var player = db.players.Find(id);
            ViewBag.player = player;

            return View();

        }

        [HttpPost, ActionName("Editshape"), ValidateAntiForgeryToken()]
        public ActionResult EditshapePostBack([Bind(Include = "player_id,height,wieght,datereg")] player_bodyshapes shape)
        {
            if (ModelState.IsValid)
            {
                db.player_bodyshapes.Add(shape);
                db.SaveChanges();
                return this.RedirectToAction("Bodyshape", new { id = shape.player_id });
            }
            else
            {
                Session["TACTION_RESULT"] = "ورودي‌ها را كنترل كنيد";
            }
            return View(shape);
        }

        public ActionResult Deleteshape(int player_id, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.shape = db.player_bodyshapes.Find(id);
            ViewBag.player = db.player_bodyshapes.Find(id).player;

            return View();

        }
        [HttpPost, ActionName("Deleteshape"), ValidateAntiForgeryToken()]
        public ActionResult DeleteshapeConfirmed(int? id)
        {
            var shape = db.player_bodyshapes.Find(id);
            var plid = shape.player_id;
            db.player_bodyshapes.Remove(shape);
            return this.RedirectToAction("Bodyshape", new { id = plid });
        }

    }
}
