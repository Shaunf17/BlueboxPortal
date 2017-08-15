using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueboxPortal.Models;

namespace BlueboxPortal.Controllers
{
    public class AirlinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Airlines
        public ActionResult Index()
        {
            return View(db.Airline.ToList());                   //RIP Benny Harvey
        }

        public ActionResult IndexNew()
        {
            return View(db.Airline.ToList());
        }

        // GET: Airlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airline airline = db.Airline.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        // GET: Airlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NameAlias,FriendlyName,DisplayName,DbName,SSRSFolder")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                db.Airline.Add(airline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airline);
        }

        // GET: Airlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airline airline = db.Airline.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NameAlias,FriendlyName,DisplayName,DbName,SSRSFolder")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airline airline = db.Airline.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Airline airline = db.Airline.Find(id);
            db.Airline.Remove(airline);
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
