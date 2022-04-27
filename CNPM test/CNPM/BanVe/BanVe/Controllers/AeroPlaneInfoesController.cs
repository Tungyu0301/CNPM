using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanVe.Models;

namespace BanVe.Controllers
{
    public class AeroPlaneInfoesController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: AeroPlaneInfoes
        public ActionResult Index()
        {
            return View(db.AeroPlaneInfos.ToList());
        }

        // GET: AeroPlaneInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.AeroPlaneInfos.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlaneInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AeroPlaneInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Planeid,APlaneName,SeatingCapacity,price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.AeroPlaneInfos.Add(aeroPlaneInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aeroPlaneInfo);
        }

        // GET: AeroPlaneInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.AeroPlaneInfos.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlaneInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Planeid,APlaneName,SeatingCapacity,price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aeroPlaneInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlaneInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.AeroPlaneInfos.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlaneInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AeroPlaneInfo aeroPlaneInfo = db.AeroPlaneInfos.Find(id);
            db.AeroPlaneInfos.Remove(aeroPlaneInfo);
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
