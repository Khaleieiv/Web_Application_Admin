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
    public class delivery_orderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: delivery_order
        public ActionResult Index()
        {
            var delivery_order = db.delivery_order.Include(d => d.promo).Include(d => d.us);
            return View(delivery_order.ToList());
        }

        // GET: delivery_order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            delivery_order delivery_order = db.delivery_order.Find(id);
            if (delivery_order == null)
            {
                return HttpNotFound();
            }
            return View(delivery_order);
        }

        // GET: delivery_order/Create
        public ActionResult Create()
        {
            ViewBag.promocode_id = new SelectList(db.promocodes, "promocode_id", "value");
            ViewBag.user_id = new SelectList(db.user, "user_id", "username");
            return View();
        }

        // POST: delivery_order/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,user_id,date,street,house,apartment_number,need_payment,completed,completion_datetime,stars,review,promocode_id")] delivery_order delivery_order)
        {
            if (ModelState.IsValid)
            {
                db.delivery_order.Add(delivery_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.promocode_id = new SelectList(db.promocodes, "promocode_id", "value", delivery_order.promocode_id);
            ViewBag.user_id = new SelectList(db.user, "user_id", "username", delivery_order.user_id);
            return View(delivery_order);
        }

        // GET: delivery_order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            delivery_order delivery_order = db.delivery_order.Find(id);
            if (delivery_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.promocode_id = new SelectList(db.promocodes, "promocode_id", "value", delivery_order.promocode_id);
            ViewBag.user_id = new SelectList(db.user.Where(p => p.role == "courier"), "user_id", "username", delivery_order.user_id);
            return View(delivery_order);
        }

        // POST: delivery_order/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,user_id,date,street,house,apartment_number,need_payment,completed,completion_datetime,stars,review,promocode_id")] delivery_order delivery_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.promocode_id = new SelectList(db.promocodes, "promocode_id", "value", delivery_order.promocode_id);
            ViewBag.user_id = new SelectList(db.user, "user_id", "username", delivery_order.user_id);
            return View(delivery_order);
        }

        // GET: delivery_order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            delivery_order delivery_order = db.delivery_order.Find(id);
            if (delivery_order == null)
            {
                return HttpNotFound();
            }
            return View(delivery_order);
        }

        // POST: delivery_order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            delivery_order delivery_order = db.delivery_order.Find(id);
            db.delivery_order.Remove(delivery_order);
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
