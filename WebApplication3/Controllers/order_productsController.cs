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
    public class order_productsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: order_products
        public ActionResult Index()
        {
            var order_products = db.order_products.Include(o => o.product);
            return View(order_products.ToList());
        }

        // GET: order_products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_products order_products = db.order_products.Find(id);
            if (order_products == null)
            {
                return HttpNotFound();
            }
            return View(order_products);
        }

        // GET: order_products/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.product, "product_id", "name");
            return View();
        }

        // POST: order_products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,product_id,amount,price")] order_products order_products)
        {
            if (ModelState.IsValid)
            {
                db.order_products.Add(order_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.product, "product_id", "name", order_products.product_id);
            return View(order_products);
        }

        // GET: order_products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_products order_products = db.order_products.Find(id);
            if (order_products == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.product, "product_id", "name", order_products.product_id);
            return View(order_products);
        }

        // POST: order_products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,product_id,amount,price")] order_products order_products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.product, "product_id", "name", order_products.product_id);
            return View(order_products);
        }

        // GET: order_products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_products order_products = db.order_products.Find(id);
            if (order_products == null)
            {
                return HttpNotFound();
            }
            return View(order_products);
        }

        // POST: order_products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_products order_products = db.order_products.Find(id);
            db.order_products.Remove(order_products);
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
