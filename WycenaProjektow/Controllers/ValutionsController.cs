﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WycenaProjektow.Models;

namespace WycenaProjektow.Controllers
{
    public class ValutionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Valutions
        public ActionResult Index()
        {
            return View(db.Valutions.ToList());
        }

        // GET: Valutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valution valution = db.Valutions.Find(id);
            if (valution == null)
            {
                return HttpNotFound();
            }
            return View(valution);
        }

        // GET: Valutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valutions/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Client,Risk")] Valution valution)
        {
            if (ModelState.IsValid)
            {
                db.Valutions.Add(valution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valution);
        }

        // GET: Valutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valution valution = db.Valutions.Find(id);
            if (valution == null)
            {
                return HttpNotFound();
            }
            return View(valution);
        }

        // POST: Valutions/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Client,Risk")] Valution valution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valution);
        }

        // GET: Valutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valution valution = db.Valutions.Find(id);
            if (valution == null)
            {
                return HttpNotFound();
            }
            return View(valution);
        }

        // POST: Valutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valution valution = db.Valutions.Find(id);
            db.Valutions.Remove(valution);
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
