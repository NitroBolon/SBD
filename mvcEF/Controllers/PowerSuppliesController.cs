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
    public class PowerSuppliesController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: PowerSupplies
        public ActionResult Index()
        {
            return View(db.PowerSupplies.ToList());
        }

        // GET: PowerSupplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerSupply powerSupply = db.PowerSupplies.Find(id);
            if (powerSupply == null)
            {
                return HttpNotFound();
            }
            return View(powerSupply);
        }

        // GET: PowerSupplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PowerSupplies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPowerSupply,Name,Power,Standard,Certificate,Description,Price")] PowerSupply powerSupply)
        {
            if (ModelState.IsValid)
            {
                db.PowerSupplies.Add(powerSupply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(powerSupply);
        }

        // GET: PowerSupplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerSupply powerSupply = db.PowerSupplies.Find(id);
            if (powerSupply == null)
            {
                return HttpNotFound();
            }
            return View(powerSupply);
        }

        // POST: PowerSupplies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPowerSupply,Name,Power,Standard,Certificate,Description,Price")] PowerSupply powerSupply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(powerSupply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(powerSupply);
        }

        // GET: PowerSupplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerSupply powerSupply = db.PowerSupplies.Find(id);
            if (powerSupply == null)
            {
                return HttpNotFound();
            }
            return View(powerSupply);
        }

        // POST: PowerSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PowerSupply powerSupply = db.PowerSupplies.Find(id);
            db.PowerSupplies.Remove(powerSupply);
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
