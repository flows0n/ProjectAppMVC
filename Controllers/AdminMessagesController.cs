﻿using System;
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
    [Authorize(Roles = "Admin")]
    public class AdminMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMessages
        public ActionResult Index()
        {
            return View(db.AdminMessages.ToList());
        }

        [HttpPost]
        public ActionResult Display(int? id)
        {
            HttpContext.Application.Lock();
            HttpContext.Application["AdminMessage"] = id;
            HttpContext.Application.UnLock();
            //TempData["displayMessage"] = "Message Changed successfully";

            return new EmptyResult();
        }

        // GET: AdminMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            return View(adminMessage);
        }

        // GET: AdminMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,message")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.AdminMessages.Add(adminMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminMessage);
        }

        // GET: AdminMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            return View(adminMessage);
        }

        // POST: AdminMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,message")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminMessage);
        }

        // GET: AdminMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            return View(adminMessage);
        }

        // POST: AdminMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            db.AdminMessages.Remove(adminMessage);
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
