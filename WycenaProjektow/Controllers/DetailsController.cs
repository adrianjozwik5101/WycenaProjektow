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
    public class DetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Details
        public ActionResult Index()
        {
            //string Owner_id = this.Request.QueryString["owner_id"];
            //int ow_id = int.Parse(Owner_id);
            //return View(db.Details.Where(e => e.ID == ow_id));
            return View(db.Details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PricePerHour,Hours,Price")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PricePerHour,Hours,Price")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
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
