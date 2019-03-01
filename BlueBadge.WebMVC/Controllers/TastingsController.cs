using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Services;

namespace BlueBadge.WebMVC.Controllers
{
    public class TastingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tastings
        public ActionResult Index()
        {
            var service = new TastingService();
            var model = service.GetTastings();
            return View(model);
        }

        // GET: Tastings/Details/5
        public ActionResult Details(int id)
        {
            var service = new TastingService();
            var model = service.GetTastingByID(id);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Tasting tasting = db.Tastings.Find(id);
            //if (tasting == null)
            //{
            //    return HttpNotFound();
            //}
            return View(model);
        }

        // GET: Tastings/Create
        // GET: ThemePark/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tastings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TastingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new TastingService();
            if (service.CreateTasting(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This review could not be added");
            return View(model);
        }

        // GET: Tastings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasting tasting = db.Tastings.Find(id);
            if (tasting == null)
            {
                return HttpNotFound();
            }
            ViewBag.BeerID = new SelectList(db.Beers, "BeerID", "BeerName", tasting.BeerID);
            ViewBag.BreweryID = new SelectList(db.Breweries, "BreweryID", "BreweryName", tasting.BreweryID);
           
            return View(tasting);
        }

        // POST: Tastings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TastingID,DrinkerID,BeerID,BreweryID,OwnerID,DateOfTasting,DateAdded,Rating,Comment")] Tasting tasting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeerID = new SelectList(db.Beers, "BeerID", "BeerName", tasting.BeerID);
            ViewBag.BreweryID = new SelectList(db.Breweries, "BreweryID", "BreweryName", tasting.BreweryID);
            return View(tasting);
        }

        // GET: Tastings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasting tasting = db.Tastings.Find(id);
            if (tasting == null)
            {
                return HttpNotFound();
            }
            return View(tasting);
        }

        // POST: Tastings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasting tasting = db.Tastings.Find(id);
            db.Tastings.Remove(tasting);
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
