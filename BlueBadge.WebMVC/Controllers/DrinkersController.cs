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
    public class DrinkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drinkers
        public ActionResult Index()
        {
            return View(db.Drinkers.ToList());
        }

        // GET: Drinkers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drinker drinker = db.Drinkers.Find(id);
            if (drinker == null)
            {
                return HttpNotFound();
            }
            return View(drinker);
        }

        // GET: Drinkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrinkerID,FName,LName,UserName,LocationState,LocationCity,FavoriteBeer,FavoriteBrewery,Age,NoOfTastings,ProfileCreated")] Drinker drinker)
        {
            if (ModelState.IsValid)
            {
                drinker.DrinkerID = Guid.NewGuid();
                db.Drinkers.Add(drinker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drinker);
        }

        // GET: Drinkers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drinker drinker = db.Drinkers.Find(id);
            if (drinker == null)
            {
                return HttpNotFound();
            }
            return View(drinker);
        }

        // POST: Drinkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrinkerID,FName,LName,UserName,LocationState,LocationCity,FavoriteBeer,FavoriteBrewery,Age,NoOfTastings,ProfileCreated")] Drinker drinker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drinker);
        }

        // GET: Drinkers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drinker drinker = db.Drinkers.Find(id);
            if (drinker == null)
            {
                return HttpNotFound();
            }
            return View(drinker);
        }

        // POST: Drinkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Drinker drinker = db.Drinkers.Find(id);
            db.Drinkers.Remove(drinker);
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
