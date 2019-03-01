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
    public class DrinkerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drinker
        public ActionResult Index()
        {
            return View(db.Drinkers.ToList());
        }

        // GET: Drinker/Details/5
        public ActionResult Details(int? id)
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

        // GET: Drinker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrinkerID,FName,LName,UserName,LocationState,LocationCity,FavoriteBeer,FavoriteBrewery,Age,NoOfTastings,ProfileCreated")] Drinker drinker)
        {
            if (ModelState.IsValid)
            {
                db.Drinkers.Add(drinker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drinker);
        }

        // GET: Drinker/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Drinker/Edit/5
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

        // GET: Drinker/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Drinker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
