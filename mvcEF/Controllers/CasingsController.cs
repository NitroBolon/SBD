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
    public class CasingsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Casings
        public ActionResult Index()
        {
            return View(db.Casings.ToList());
        }

        // GET: Casings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casing casing = db.Casings.Find(id);
            if (casing == null)
            {
                return HttpNotFound();
            }
            return View(casing);
        }

        // GET: Casings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCasing,Name,Fans,Standard,Description,Price")] Casing casing)
        {
            if (ModelState.IsValid)
            {
                db.Casings.Add(casing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casing);
        }

        // GET: Casings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casing casing = db.Casings.Find(id);
            if (casing == null)
            {
                return HttpNotFound();
            }
            return View(casing);
        }

        // POST: Casings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCasing,Name,Fans,Standard,Description,Price")] Casing casing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casing);
        }

        // GET: Casings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casing casing = db.Casings.Find(id);
            if (casing == null)
            {
                return HttpNotFound();
            }
            return View(casing);
        }

        // POST: Casings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casing casing = db.Casings.Find(id);
            db.Casings.Remove(casing);
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
