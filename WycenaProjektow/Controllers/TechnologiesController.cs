using System;
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
    public class TechnologiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Technologies
        public ActionResult Index()
        {
            return View(db.Technologies.ToList());
        }

        // GET: Technologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologie technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            return View(technologie);
        }

        // GET: Technologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technologies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Language,Framework,Type")] Technologie technologie)
        {
            if (ModelState.IsValid)
            {
                db.Technologies.Add(technologie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologie);
        }

        // GET: Technologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologie technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            return View(technologie);
        }

        // POST: Technologies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Language,Framework,Type")] Technologie technologie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologie);
        }

        // GET: Technologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologie technologie = db.Technologies.Find(id);
            if (technologie == null)
            {
                return HttpNotFound();
            }
            return View(technologie);
        }

        // POST: Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technologie technologie = db.Technologies.Find(id);
            db.Technologies.Remove(technologie);
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
