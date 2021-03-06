﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcEF.Models;

namespace mvcEF.Controllers
{
    public class MotherboardsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Motherboards
        public ActionResult Index()
        {
            return View(db.Motherboards.ToList());
        }

        // GET: Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // GET: Motherboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motherboards/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMotherboard,Name,Socket,Standard,Description,Price")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Motherboards.Add(motherboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motherboard);
        }

        // GET: Motherboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // POST: Motherboards/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMotherboard,Name,Socket,Standard,Description,Price")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motherboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motherboard);
        }

        // GET: Motherboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // POST: Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motherboard motherboard = db.Motherboards.Find(id);
            db.Motherboards.Remove(motherboard);
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
