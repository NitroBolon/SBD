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
    public class GraphicsCardsController : Controller
    {
        private mvcEFContext db = new mvcEFContext();

        // GET: GraphicsCards
        public ActionResult Index()
        {
            return View(db.GraphicsCards.ToList());
        }

        // GET: GraphicsCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsCard graphicsCard = db.GraphicsCards.Find(id);
            if (graphicsCard == null)
            {
                return HttpNotFound();
            }
            return View(graphicsCard);
        }

        // GET: GraphicsCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GraphicsCards/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDGraphicsCard,Name,Memory,Description,Price")] GraphicsCard graphicsCard)
        {
            if (ModelState.IsValid)
            {
                db.GraphicsCards.Add(graphicsCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graphicsCard);
        }

        // GET: GraphicsCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsCard graphicsCard = db.GraphicsCards.Find(id);
            if (graphicsCard == null)
            {
                return HttpNotFound();
            }
            return View(graphicsCard);
        }

        // POST: GraphicsCards/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDGraphicsCard,Name,Memory,Description,Price")] GraphicsCard graphicsCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graphicsCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graphicsCard);
        }

        // GET: GraphicsCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphicsCard graphicsCard = db.GraphicsCards.Find(id);
            if (graphicsCard == null)
            {
                return HttpNotFound();
            }
            return View(graphicsCard);
        }

        // POST: GraphicsCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GraphicsCard graphicsCard = db.GraphicsCards.Find(id);
            db.GraphicsCards.Remove(graphicsCard);
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
