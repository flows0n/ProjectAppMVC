using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    public class ProductReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductReports
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var productReports = db.ProductReports.Include(p => p.product);
            return View(productReports.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: ProductReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReport productReport = db.ProductReports.Find(id);
            if (productReport == null)
            {
                return HttpNotFound();
            }
            return View(productReport);
        }

        // GET: ProductReports/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = product.ID;
            return View();
        }

        // POST: ProductReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,description,productID")] ProductReport productReport)
        {
            if (ModelState.IsValid)
            {
                db.ProductReports.Add(productReport);
                db.SaveChanges();
                return RedirectToAction("Details", "Products", new { id = productReport.productID });
            }

            ViewBag.productID = new SelectList(db.Products, "ID", "Name", productReport.productID);
            return View(productReport);
        }

        // GET: ProductReports/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReport productReport = db.ProductReports.Find(id);
            if (productReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = new SelectList(db.Products, "ID", "Name", productReport.productID);
            return View(productReport);
        }

        // POST: ProductReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,description,productID")] ProductReport productReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productID = new SelectList(db.Products, "ID", "Name", productReport.productID);
            return View(productReport);
        }

        // GET: ProductReports/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReport productReport = db.ProductReports.Find(id);
            if (productReport == null)
            {
                return HttpNotFound();
            }
            return View(productReport);
        }

        // POST: ProductReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductReport productReport = db.ProductReports.Find(id);
            db.ProductReports.Remove(productReport);
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
