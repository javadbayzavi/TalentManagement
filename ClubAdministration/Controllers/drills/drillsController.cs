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
using ClubAdministration.Models.ViewModels;

namespace ClubAdministration.Controllers
{
    public partial class drillsController : BaseController
    {
        private clubAdminProxy db = new clubAdminProxy();

        // GET: drillsController
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: This action needs to be optimized, because it fetchs all records from the db and then try to filter the result in app
            return View(db.drills
                .Where(a => a.drill_title.Contains(this.Setting.PageSetting.SearchItem) ||
                a.agelevel.level.Contains(this.Setting.PageSetting.SearchItem)).Include(b => b.agelevel)
                );
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPostBack()
        {
            return this.Index();
        }

        // GET: drills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["TACTION_RESULT"] = "مشكل در نمايش تمرينات وجود دارد";
                return this.RedirectToAction("Index");
            }
            //drill drill = db.drills.Find(id);
            var drill = db.drills.Where(a => a.ID == id).Include(a => a.participating_positions).Include(a => a.agelevel)
                .Include(a => a.drill_emphasis).Include(a => a.drill_location).Include(a => a.drill_type).Include(a => a.drillmaterials).Include(a => a.drillskills)
                .First();
                
            if (drill == null)
            {
                Session["TACTION_RESULT"] = "تمرين درخواستي در سيستم ثبت نشده است";
                return this.RedirectToAction("Index");
            }

            return View(drill);
        }

        // GET: club/Create
        public ActionResult Create()
        {
            //TODO: This action need to be deeply reviewed
            drillinputmodel entry = new drillinputmodel();
            //1. Load Age level
            entry.agelevel = new SelectList(db.agelevels.ToList(), "ID", "level");
            //this.ViewBag.age_levelid = new SelectList(db.agelevels.ToList(), "ID", "level");
            //2. Load Drill Type
            //this.ViewBag.drill_typeid = new SelectList(db.drill_types.ToList(), "ID", "title");
            entry.drill_type = new SelectList(db.drill_types.ToList(), "ID", "title");
            //3. Load Drill Emphasis
            //this.ViewBag.drill_emphasisid = new SelectList(db.drill_emphasises.ToList(), "ID", "emphasis");
            entry.drill_emphasis = new SelectList(db.drill_emphasises.ToList(), "ID", "emphasis");
            //4. Load Drill Positions
            //this.ViewBag.participating_positionsid = new SelectList(db.positions.ToList(), "ID", "title");
            entry.participating_positions = new SelectList(db.positions.ToList(), "ID", "title");
            //5. Load Drill Locations
            //this.ViewBag.drill_locationid = new SelectList(db.drill_locations.ToList(), "ID", "title");
            entry.drill_location = new SelectList(db.drill_locations.ToList(), "ID", "location");
            //6. Load Drill required Materials
            entry.drillmaterials = new SelectList(db.materials.ToList(), "ID", "name");
            //7. Load Drill target skills
            entry.drillskills = new SelectList(db.skills.ToList(), "ID", "name");
            return View(entry);
        }

        // POST: drillsController/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,drill_target,drill_title,drill_goals,drill_execution," +
            "drill_variations,drill_progression,drill_coachingtips,drill_organization,drill_competition,drill_emphasisid,agelevel_id,drill_levelplay," +
            "drill_structure,drill_typeid,drill_playernumbers,participating_positionsid,drill_locationid," +
            "drill_duration,drill_fieldsize")] drillinputmodel drillentry)
        {
            string[] skillids = this.Request["drillskillsid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(a => a != "false").ToArray();
            string[] materialids = this.Request["drillmaterialsid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(a => a != "false").ToArray();
            string[] materialnum = this.Request["drillmaterialsnum"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(a => a != "false").ToArray();

            //1. Convert the entry to Db Model
            if (ModelState.IsValid == false)
            {
                drill dbdrill = new drill 
                {
                    drill_competition = drillentry.drill_competition,
                    agelevel_id = drillentry.agelevel_id,
                    drill_coachingtips = drillentry.drill_coachingtips,
                    drill_duration = drillentry.drill_duration,
                    drill_emphasisid = drillentry.drill_emphasisid,
                    drill_execution = drillentry.drill_execution,
                    drill_fieldsize = drillentry.drill_fieldsize,
                    drill_goals = drillentry.drill_goals,
                    drill_levelplay = drillentry.drill_levelplay,
                    drill_locationid = drillentry.drill_locationid,
                    drill_organization = drillentry.drill_organization,
                    drill_playernumbers = drillentry.drill_playernumbers,
                    drill_progression = drillentry.drill_progression,
                    drill_structure = drillentry.drill_structure,
                    drill_target = drillentry.drill_target,
                    drill_title = drillentry.drill_title,
                    drill_typeid = drillentry.drill_typeid,
                    drill_variations = drillentry.drill_variations,
                    participating_positionsid = drillentry.participating_positionsid
                };
                //2. Check for validity of all entries
                //3. Save the drill
                //4. Save drill related objects
                using (TransactionScope trans = new TransactionScope())
                {
                    //TODO: This action need to be deeply reviewed
                    db.drills.Add(dbdrill);
                    //db.SaveChanges();
                    //TODO: insert materials list
                    for (int index = 0; index < materialids.Length; index++)
                    {
                        drill_materials mat = new drill_materials()
                        {
                            drill_id = dbdrill.ID,
                            material_id = System.Convert.ToInt32(materialids[index]),
                            number = System.Convert.ToInt32(materialnum[index])
                        };
                        db.drill_materials.Add(mat);

                    }
                    //TODO: inser skills list
                    for (int index = 0; index < skillids.Length; index++)
                    {
                        drill_skills skl = new drill_skills()
                        {
                            drill_id = dbdrill.ID,
                            skill_id = System.Convert.ToInt32(skillids[index])
                        };
                        db.drillskills.Add(skl);
                    }
                    db.SaveChanges();
                    trans.Complete();
                }   
                return RedirectToAction("Index");
            }

            return View(drillentry);
        }

        // GET: drills/Edit/5
        public ActionResult Edit(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Load the drill entry
            drillinputmodel entry = db.drills.Where(a => a.ID == id).Select(a => new drillinputmodel 
            { 
                ID = a.ID,
                agelevel = new SelectList(db.agelevels.ToList(), "ID", "level" , a.agelevel_id),
                agelevel_id = a.agelevel_id,
                drill_coachingtips = a.drill_coachingtips,
                drill_competition = a.drill_competition,
                drill_duration = a.drill_duration,
                drill_emphasis = new SelectList(db.agelevels.ToList(), "ID", "level", a.drill_emphasisid),
                drill_emphasisid = a.drill_emphasisid,
                drill_execution = a.drill_execution,
                drill_fieldsize = a.drill_fieldsize,
                drill_goals = a.drill_goals,
                drill_levelplay = a.drill_levelplay,
                drill_location = new SelectList(db.agelevels.ToList(), "ID", "level", a.drill_locationid),
                drill_locationid = a.drill_locationid,
                drill_organization = a.drill_organization,
                drill_playernumbers = a.drill_playernumbers,
                drill_progression = a.drill_progression,
                drill_structure = a.drill_structure,
                drill_target = a.drill_target,
                drill_title = a.drill_title,
                drill_type = new SelectList(db.agelevels.ToList(), "ID", "level", a.drill_typeid),
                drill_typeid = a.drill_typeid,
                drill_variations = a.drill_variations,
                participating_positions = new SelectList(db.agelevels.ToList(), "ID", "level", a.participating_positionsid),
                participating_positionsid = a.participating_positionsid
            }).FirstOrDefault();

            //In case of not matching the reuquested drill
            if (entry == null)
            {
                return HttpNotFound();
            }

            //6. Load Drill required Materials
            entry.drillmaterials = new SelectList(db.materials.ToList(), "ID", "name");
            entry.drillmaterials.Where(a => )
            //7. Load Drill target skills
            entry.drillskills = new SelectList(db.skills.ToList(), "ID", "name");

            return View(entry);
        }

        // POST: drills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,drill_target,drill_title,goals,execution," +
            "variations,progression,coachingtips,organization,competition,drill_emphasisid,agelevel_id,level_play," +
            "drill_structure,drill_typeid,playernumbers,participating_positionsid,drill_locationid," +
            "drill_duration,fieldsize")] drill drill)
        {
            //TODO: This action need to be deeply reviewed
            if (ModelState.IsValid)
            {
                //TODO: Update material lists
                //TODO: Update skills list
                db.Entry(drill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drill);
        }

        // GET: club/Delete/5
        public ActionResult Delete(int? id)
        {
            //TODO: This action need to be deeply reviewed
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drill drill = db.drills.Find(id);
            if (drill == null)
            {
                return HttpNotFound();
            }
            return View(drill);
        }

        // POST: drills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TODO: This action need to be deeply reviewed
            drill drill = db.drills.Find(id);
            db.drills.Remove(drill);
            db.SaveChanges();
            return RedirectToAction("Index");
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