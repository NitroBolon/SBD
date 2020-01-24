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
    public class OrdersController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.cart).Include(o => o.client).Include(o => o.delivery);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.IDCart = new SelectList(db.Carts, "IDCart", "IDCart");
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Name");
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "IDDelivery", "Name");
            return View();
        }

        // POST: Orders/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOrder,IDCart,orderDate,IDDelivery,IDClient")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCart = new SelectList(db.Carts, "IDCart", "IDCart", order.IDCart);
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Name", order.IDClient);
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "IDDelivery", "Name", order.IDDelivery);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCart = new SelectList(db.Carts, "IDCart", "IDCart", order.IDCart);
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Name", order.IDClient);
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "IDDelivery", "Name", order.IDDelivery);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOrder,IDCart,orderDate,IDDelivery,IDClient")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCart = new SelectList(db.Carts, "IDCart", "IDCart", order.IDCart);
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Name", order.IDClient);
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "IDDelivery", "Name", order.IDDelivery);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
