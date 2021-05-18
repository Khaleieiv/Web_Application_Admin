using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class order_courierController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: order_courier
        public ActionResult Index()
        {
            var order_courier = db.order_courier.Include(o => o.user);
            return View(order_courier.ToList());
        }

        // GET: order_courier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_courier order_courier = db.order_courier.Find(id);
            if (order_courier == null)
            {
                return HttpNotFound();
            }
            return View(order_courier);
        }

        // GET: order_courier/Create
        public ActionResult Create()
        {
            ViewBag.courier_id = new SelectList(db.user, "user_id", "username");
            return View();
        }

        // POST: order_courier/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,courier_id")] order_courier order_courier)
        {
            if (ModelState.IsValid)
            {
                db.order_courier.Add(order_courier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courier_id = new SelectList(db.user, "user_id", "username", order_courier.courier_id);
            return View(order_courier);
        }

        // GET: order_courier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_courier order_courier = db.order_courier.Find(id);
            if (order_courier == null)
            {
                return HttpNotFound();
            }
            ViewBag.courier_id = new SelectList(db.user.Where(p => p.role == "courier"), "user_id", "username", order_courier.courier_id);
            return View(order_courier);
        }

        // POST: order_courier/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,courier_id")] order_courier order_courier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_courier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courier_id = new SelectList(db.user, "user_id", "username", order_courier.courier_id);
            return View(order_courier);
        }

        // GET: order_courier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_courier order_courier = db.order_courier.Find(id);
            if (order_courier == null)
            {
                return HttpNotFound();
            }
            return View(order_courier);
        }

        // POST: order_courier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_courier order_courier = db.order_courier.Find(id);
            db.order_courier.Remove(order_courier);
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
