using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScaffoldApp.Models;

namespace ScaffoldApp.Controllers
{
    public class WorkerBeesController : Controller
    {
        private WorkerBeeDBContext db = new WorkerBeeDBContext();

        // GET: WorkerBees
        public ActionResult Index()
        {
            return View(db.WorkerBees.ToList());
        }

        // GET: WorkerBees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerBee workerBee = db.WorkerBees.Find(id);
            if (workerBee == null)
            {
                return HttpNotFound();
            }
            return View(workerBee);
        }

        // GET: WorkerBees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkerBees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,JoinDate,Age,ZipCode")] WorkerBee workerBee)
        {
            if (ModelState.IsValid)
            {
                db.WorkerBees.Add(workerBee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workerBee);
        }

        // GET: WorkerBees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerBee workerBee = db.WorkerBees.Find(id);
            if (workerBee == null)
            {
                return HttpNotFound();
            }
            return View(workerBee);
        }

        // POST: WorkerBees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,JoinDate,Age,ZipCode")] WorkerBee workerBee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerBee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workerBee);
        }

        // GET: WorkerBees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerBee workerBee = db.WorkerBees.Find(id);
            if (workerBee == null)
            {
                return HttpNotFound();
            }
            return View(workerBee);
        }

        // POST: WorkerBees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerBee workerBee = db.WorkerBees.Find(id);
            db.WorkerBees.Remove(workerBee);
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
