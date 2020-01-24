using System;
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
    public class RAMsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: RAMs
        public ActionResult Index()
        {
            return View(db.RAMs.ToList());
        }

        // GET: RAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // GET: RAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAMs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRAM,Name,Memory,Description,Price")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.RAMs.Add(rAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rAM);
        }

        // GET: RAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // POST: RAMs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRAM,Name,Memory,Description,Price")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rAM);
        }

        // GET: RAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // POST: RAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAM rAM = db.RAMs.Find(id);
            db.RAMs.Remove(rAM);
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
