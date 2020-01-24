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
    public class ComputersController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Computers
        public ActionResult Index()
        {
            var computs = db.Computers.Include(c => c.Casing).Include(c => c.Cooler).Include(c => c.GraphicsCard).Include(c => c.Motherboard).Include(c => c.PowerSupply).Include(c => c.Processor).Include(c => c.RAM);
            ICollection<CompDrives> computdrives = db.CompDrives.ToList();
            ViewBag.computdrives = computdrives;
            ICollection<Drive> drives = db.Drives.ToList();
            ViewBag.drives = drives;
            //ICollection<Computer> computers = db.Computers.ToList();
            //ViewBag.computers = computers;

            return View(computs.ToList());
        }

        // GET: Computers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computers.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // GET: Computers/Create
        public ActionResult Create()
        {
            ViewBag.IDCasing = new SelectList(db.Casings, "IDCasing", "Name");
            ViewBag.IDCooler = new SelectList(db.Coolers, "IDCooler", "Name");
            ViewBag.IDGraphicsCard = new SelectList(db.GraphicsCards, "IDGraphicsCard", "Name");
            ViewBag.IDMotherboard = new SelectList(db.Motherboards, "IDMotherboard", "Name");
            ViewBag.IDPowerSupply = new SelectList(db.PowerSupplies, "IDPowerSupply", "Name");
            ViewBag.IDProcessor = new SelectList(db.Processors, "IDProcessor", "Name");
            ViewBag.IDRAM = new SelectList(db.RAMs, "IDRAM", "Name");
            return View();
        }

        // POST: Computers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDComputer,IDCasing,IDPowerSupply,IDMotherboard,IDProcessor,IDGraphicsCard,IDCooler,IDRAM")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCasing = new SelectList(db.Casings, "IDCasing", "Name", computer.IDCasing);
            ViewBag.IDCooler = new SelectList(db.Coolers, "IDCooler", "Name", computer.IDCooler);
            ViewBag.IDGraphicsCard = new SelectList(db.GraphicsCards, "IDGraphicsCard", "Name", computer.IDGraphicsCard);
            ViewBag.IDMotherboard = new SelectList(db.Motherboards, "IDMotherboard", "Name", computer.IDMotherboard);
            ViewBag.IDPowerSupply = new SelectList(db.PowerSupplies, "IDPowerSupply", "Name", computer.IDPowerSupply);
            ViewBag.IDProcessor = new SelectList(db.Processors, "IDProcessor", "Name", computer.IDProcessor);
            ViewBag.IDRAM = new SelectList(db.RAMs, "IDRAM", "Name", computer.IDRAM);
            return View(computer);
        }

        // GET: Computers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computers.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCasing = new SelectList(db.Casings, "IDCasing", "Name", computer.IDCasing);
            ViewBag.IDCooler = new SelectList(db.Coolers, "IDCooler", "Name", computer.IDCooler);
            ViewBag.IDGraphicsCard = new SelectList(db.GraphicsCards, "IDGraphicsCard", "Name", computer.IDGraphicsCard);
            ViewBag.IDMotherboard = new SelectList(db.Motherboards, "IDMotherboard", "Name", computer.IDMotherboard);
            ViewBag.IDPowerSupply = new SelectList(db.PowerSupplies, "IDPowerSupply", "Name", computer.IDPowerSupply);
            ViewBag.IDProcessor = new SelectList(db.Processors, "IDProcessor", "Name", computer.IDProcessor);
            ViewBag.IDRAM = new SelectList(db.RAMs, "IDRAM", "Name", computer.IDRAM);
            return View(computer);
        }

        // POST: Computers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDComputer,IDCasing,IDPowerSupply,IDMotherboard,IDProcessor,IDGraphicsCard,IDCooler,IDRAM")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCasing = new SelectList(db.Casings, "IDCasing", "Name", computer.IDCasing);
            ViewBag.IDCooler = new SelectList(db.Coolers, "IDCooler", "Name", computer.IDCooler);
            ViewBag.IDGraphicsCard = new SelectList(db.GraphicsCards, "IDGraphicsCard", "Name", computer.IDGraphicsCard);
            ViewBag.IDMotherboard = new SelectList(db.Motherboards, "IDMotherboard", "Name", computer.IDMotherboard);
            ViewBag.IDPowerSupply = new SelectList(db.PowerSupplies, "IDPowerSupply", "Name", computer.IDPowerSupply);
            ViewBag.IDProcessor = new SelectList(db.Processors, "IDProcessor", "Name", computer.IDProcessor);
            ViewBag.IDRAM = new SelectList(db.RAMs, "IDRAM", "Name", computer.IDRAM);
            return View(computer);
        }

        // GET: Computers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computers.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computer computer = db.Computers.Find(id);
            db.Computers.Remove(computer);
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
