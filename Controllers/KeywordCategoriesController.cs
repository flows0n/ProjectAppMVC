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
    public class KeywordCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WordCategories
        public ActionResult Index()
        {
            var keywordCategories = db.KeywordCategories.Include(w => w.Category).Include(w => w.Keyword);
            return View(keywordCategories.ToList());
        }

        // GET: WordCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordCategory keywordCategory = db.KeywordCategories.Find(id);
            if (keywordCategory == null)
            {
                return HttpNotFound();
            }
            return View(keywordCategory);
        }

        // GET: WordCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.WordID = new SelectList(db.Keywords, "ID", "Name");
            return View();
        }

        // POST: WordCategories/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WordID,CategoryID")] KeywordCategory keywordCategory)
        {
            if (ModelState.IsValid)
            {
                db.KeywordCategories.Add(keywordCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", keywordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Keywords, "ID", "Name", keywordCategory.WordID);
            return View(keywordCategory);
        }

        // GET: WordCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordCategory keywordCategory = db.KeywordCategories.Find(id);
            if (keywordCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", keywordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Keywords, "ID", "Name", keywordCategory.WordID);
            return View(keywordCategory);
        }

        // POST: WordCategories/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WordID,CategoryID")] KeywordCategory keywordCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keywordCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", keywordCategory.CategoryID);
            ViewBag.WordID = new SelectList(db.Keywords, "ID", "Name", keywordCategory.WordID);
            return View(keywordCategory);
        }

        // GET: WordCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordCategory keywordCategory = db.KeywordCategories.Find(id);
            if (keywordCategory == null)
            {
                return HttpNotFound();
            }
            return View(keywordCategory);
        }

        // POST: WordCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeywordCategory keywordCategory = db.KeywordCategories.Find(id);
            db.KeywordCategories.Remove(keywordCategory);
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
