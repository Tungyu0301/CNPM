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
    public class AdminLogicsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: AdminLogics
        public ActionResult Index()
        {
            return View(db.AdminLogics.ToList());
        }

        // GET: AdminLogics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogic adminLogic = db.AdminLogics.Find(id);
            if (adminLogic == null)
            {
                return HttpNotFound();
            }
            return View(adminLogic);
        }

        // GET: AdminLogics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLogics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdName,Password")] AdminLogic adminLogic)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogics.Add(adminLogic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLogic);
        }

        // GET: AdminLogics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogic adminLogic = db.AdminLogics.Find(id);
            if (adminLogic == null)
            {
                return HttpNotFound();
            }
            return View(adminLogic);
        }

        // POST: AdminLogics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,AdName,Password")] AdminLogic adminLogic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLogic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLogic);
        }

        // GET: AdminLogics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogic adminLogic = db.AdminLogics.Find(id);
            if (adminLogic == null)
            {
                return HttpNotFound();
            }
            return View(adminLogic);
        }

        // POST: AdminLogics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogic adminLogic = db.AdminLogics.Find(id);
            db.AdminLogics.Remove(adminLogic);
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
