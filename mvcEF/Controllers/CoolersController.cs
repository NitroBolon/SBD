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
    public class CoolersController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Coolers
        public ActionResult Index()
        {
            return View(db.Coolers.ToList());
        }

        // GET: Coolers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // GET: Coolers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coolers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCooler,Name,hasFan,Description,Price")] Cooler cooler)
        {
            if (ModelState.IsValid)
            {
                db.Coolers.Add(cooler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cooler);
        }

        // GET: Coolers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // POST: Coolers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCooler,Name,hasFan,Description,Price")] Cooler cooler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cooler);
        }

        // GET: Coolers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // POST: Coolers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cooler cooler = db.Coolers.Find(id);
            db.Coolers.Remove(cooler);
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
