using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectApp.Models
{
    public class UploadedFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UploadedFiles
        public ActionResult Index()
        {
            return View(db.UploadedFiles.ToList());
        }

        // GET: UploadedFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadedFile uploadedFile = db.UploadedFiles.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            return View(uploadedFile);
        }

        // GET: UploadedFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UploadedFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FileName,Description")] UploadedFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                db.UploadedFiles.Add(uploadedFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uploadedFile);
        }

        // GET: UploadedFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadedFile uploadedFile = db.UploadedFiles.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            return View(uploadedFile);
        }

        // POST: UploadedFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FileName,Description")] UploadedFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uploadedFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uploadedFile);
        }

        // GET: UploadedFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UploadedFile uploadedFile = db.UploadedFiles.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            return View(uploadedFile);
        }

        // POST: UploadedFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UploadedFile uploadedFile = db.UploadedFiles.Find(id);
            db.UploadedFiles.Remove(uploadedFile);
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
