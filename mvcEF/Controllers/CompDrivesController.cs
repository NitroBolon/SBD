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
    public class CompDrivesController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: CompDrives
        public ActionResult Index()
        {
            var compDrives = db.CompDrives.Include(c => c.Computer).Include(c => c.Drive);
            return View(compDrives.ToList());
        }

        // GET: CompDrives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompDrives compDrives = db.CompDrives.Find(id);
            if (compDrives == null)
            {
                return HttpNotFound();
            }
            return View(compDrives);
        }

        // GET: CompDrives/Create
        public ActionResult Create()
        {
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer");
            ViewBag.IDDrive = new SelectList(db.Drives, "IDDrive", "Name");
            return View();
        }

        // POST: CompDrives/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDrive,IDComputer")] CompDrives compDrives)
        {
            if (ModelState.IsValid)
            {
                db.CompDrives.Add(compDrives);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", compDrives.IDComputer);
            ViewBag.IDDrive = new SelectList(db.Drives, "IDDrive", "Name", compDrives.IDDrive);
            return View(compDrives);
        }

        // GET: CompDrives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompDrives compDrives = db.CompDrives.Find(id);
            if (compDrives == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", compDrives.IDComputer);
            ViewBag.IDDrive = new SelectList(db.Drives, "IDDrive", "Name", compDrives.IDDrive);
            return View(compDrives);
        }

        // POST: CompDrives/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDrive,IDComputer")] CompDrives compDrives)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compDrives).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", compDrives.IDComputer);
            ViewBag.IDDrive = new SelectList(db.Drives, "IDDrive", "Name", compDrives.IDDrive);
            return View(compDrives);
        }

        // GET: CompDrives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompDrives compDrives = db.CompDrives.Find(id);
            if (compDrives == null)
            {
                return HttpNotFound();
            }
            return View(compDrives);
        }

        // POST: CompDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompDrives compDrives = db.CompDrives.Find(id);
            db.CompDrives.Remove(compDrives);
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
