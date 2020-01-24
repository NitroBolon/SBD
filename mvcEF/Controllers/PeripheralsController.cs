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
    public class PeripheralsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Peripherals
        public ActionResult Index()
        {
            return View(db.Peripherals.ToList());
        }

        // GET: Peripherals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peripheral peripheral = db.Peripherals.Find(id);
            if (peripheral == null)
            {
                return HttpNotFound();
            }
            return View(peripheral);
        }

        // GET: Peripherals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peripherals/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPeripheral,Name,Description,Price")] Peripheral peripheral)
        {
            if (ModelState.IsValid)
            {
                db.Peripherals.Add(peripheral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peripheral);
        }

        // GET: Peripherals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peripheral peripheral = db.Peripherals.Find(id);
            if (peripheral == null)
            {
                return HttpNotFound();
            }
            return View(peripheral);
        }

        // POST: Peripherals/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPeripheral,Name,Description,Price")] Peripheral peripheral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peripheral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peripheral);
        }

        // GET: Peripherals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peripheral peripheral = db.Peripherals.Find(id);
            if (peripheral == null)
            {
                return HttpNotFound();
            }
            return View(peripheral);
        }

        // POST: Peripherals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peripheral peripheral = db.Peripherals.Find(id);
            db.Peripherals.Remove(peripheral);
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
