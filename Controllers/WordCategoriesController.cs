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
    public class WordCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WordCategories
        public ActionResult Index()
        {
            var wordCategories = db.WordCategories.Include(w => w.Category).Include(w => w.Word);
            return View(wordCategories.ToList());
        }

        // GET: WordCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordCategory wordCategory = db.WordCategories.Find(id);
            if (wordCategory == null)
            {
                return HttpNotFound();
            }
            return View(wordCategory);
        }

        // GET: WordCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.WordID = new SelectList(db.Words, "ID", "Name");
            return View();
        }

        // POST: WordCategories/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WordID,CategoryID")] WordCategory wordCategory)
        {
            if (ModelState.IsValid)
            {
                db.WordCategories.Add(wordCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", wordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Words, "ID", "Name", wordCategory.WordID);
            return View(wordCategory);
        }

        // GET: WordCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordCategory wordCategory = db.WordCategories.Find(id);
            if (wordCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", wordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Words, "ID", "Name", wordCategory.WordID);
            return View(wordCategory);
        }

        // POST: WordCategories/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WordID,CategoryID")] WordCategory wordCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", wordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Words, "ID", "Name", wordCategory.WordID);
            return View(wordCategory);
        }

        // GET: WordCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordCategory wordCategory = db.WordCategories.Find(id);
            if (wordCategory == null)
            {
                return HttpNotFound();
            }
            return View(wordCategory);
        }

        // POST: WordCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WordCategory wordCategory = db.WordCategories.Find(id);
            db.WordCategories.Remove(wordCategory);
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
