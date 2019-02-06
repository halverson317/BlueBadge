using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueBadge.Data;

namespace BlueBadge.WebMVC.Controllers
{
    public class TastingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tasting
        public ActionResult Index()
        {
            var tastings = db.Tastings.Include(t => t.Beer).Include(t => t.Brewery).Include(t => t.Drinker);
            return View(tastings.ToList());
        }

        // GET: Tasting/Details/5
        public ActionResult Details(Guid? id)
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

        // GET: Tasting/Create
        public ActionResult Create()
        {
            ViewBag.BeerID = new SelectList(db.Beers, "BeerID", "BeerName");
            ViewBag.BreweryID = new SelectList(db.Breweries, "BreweryID", "BreweryName");
            ViewBag.DrinkerID = new SelectList(db.Drinkers, "DrinkerID", "FName");
            return View();
        }

        // POST: Tasting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TastingID,DrinkerID,BeerID,BreweryID,DateOfTasting,DateAdded,Rating,Comment")] Tasting tasting)
        {
            if (ModelState.IsValid)
            {
                tasting.TastingID = Guid.NewGuid();
                db.Tastings.Add(tasting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BeerID = new SelectList(db.Beers, "BeerID", "BeerName", tasting.BeerID);
            ViewBag.BreweryID = new SelectList(db.Breweries, "BreweryID", "BreweryName", tasting.BreweryID);
            ViewBag.DrinkerID = new SelectList(db.Drinkers, "DrinkerID", "FName", tasting.DrinkerID);
            return View(tasting);
        }

        // GET: Tasting/Edit/5
        public ActionResult Edit(Guid? id)
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
            ViewBag.DrinkerID = new SelectList(db.Drinkers, "DrinkerID", "FName", tasting.DrinkerID);
            return View(tasting);
        }

        // POST: Tasting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TastingID,DrinkerID,BeerID,BreweryID,DateOfTasting,DateAdded,Rating,Comment")] Tasting tasting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeerID = new SelectList(db.Beers, "BeerID", "BeerName", tasting.BeerID);
            ViewBag.BreweryID = new SelectList(db.Breweries, "BreweryID", "BreweryName", tasting.BreweryID);
            ViewBag.DrinkerID = new SelectList(db.Drinkers, "DrinkerID", "FName", tasting.DrinkerID);
            return View(tasting);
        }

        // GET: Tasting/Delete/5
        public ActionResult Delete(Guid? id)
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

        // POST: Tasting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
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
