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
    public class UserProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserProducts
        public ActionResult Index()
        {
            var userProducts = db.UserProducts.Include(u => u.Product);
            return View(userProducts.ToList());
        }

        // GET: UserProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProduct userProduct = db.UserProducts.Find(id);
            if (userProduct == null)
            {
                return HttpNotFound();
            }
            return View(userProduct);
        }

        // GET: UserProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: UserProducts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ProductID,AddDate,EndDate,FavouriteCount,VisitCount")] UserProduct userProduct)
        {
            if (ModelState.IsValid)
            {
                db.UserProducts.Add(userProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", userProduct.ProductID);
            return View(userProduct);
        }

        // GET: UserProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProduct userProduct = db.UserProducts.Find(id);
            if (userProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", userProduct.ProductID);
            return View(userProduct);
        }

        // POST: UserProducts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,ProductID,AddDate,EndDate,FavouriteCount,VisitCount")] UserProduct userProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", userProduct.ProductID);
            return View(userProduct);
        }

        // GET: UserProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProduct userProduct = db.UserProducts.Find(id);
            if (userProduct == null)
            {
                return HttpNotFound();
            }
            return View(userProduct);
        }

        // POST: UserProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProduct userProduct = db.UserProducts.Find(id);
            db.UserProducts.Remove(userProduct);
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
