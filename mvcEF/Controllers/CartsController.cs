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
    public class CartsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.Accessories).Include(c => c.computer).Include(c => c.Peripheral);
            return View(carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.IDAccessory = new SelectList(db.Accessories, "IDAccessory", "Name");
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer");
            ViewBag.IDPeripheral = new SelectList(db.Peripherals, "IDPeripheral", "Name");
            return View();
        }

        // POST: Carts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCart,IDComputer,IDAccessory,IDPeripheral")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAccessory = new SelectList(db.Accessories, "IDAccessory", "Name", cart.IDAccessory);
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", cart.IDComputer);
            ViewBag.IDPeripheral = new SelectList(db.Peripherals, "IDPeripheral", "Name", cart.IDPeripheral);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAccessory = new SelectList(db.Accessories, "IDAccessory", "Name", cart.IDAccessory);
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", cart.IDComputer);
            ViewBag.IDPeripheral = new SelectList(db.Peripherals, "IDPeripheral", "Name", cart.IDPeripheral);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCart,IDComputer,IDAccessory,IDPeripheral")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAccessory = new SelectList(db.Accessories, "IDAccessory", "Name", cart.IDAccessory);
            ViewBag.IDComputer = new SelectList(db.Computers, "IDComputer", "IDComputer", cart.IDComputer);
            ViewBag.IDPeripheral = new SelectList(db.Peripherals, "IDPeripheral", "Name", cart.IDPeripheral);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
