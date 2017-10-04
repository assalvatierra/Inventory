using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using scm.Models;

namespace scm.Controllers
{
    public class scSuppliersController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scSuppliers
        public ActionResult Index()
        {
            return View(db.scSuppliers.ToList());
        }

        // GET: scSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // GET: scSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] scSupplier scSupplier)
        {
            if (ModelState.IsValid)
            {
                db.scSuppliers.Add(scSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scSupplier);
        }

        // GET: scSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // POST: scSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] scSupplier scSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scSupplier);
        }

        // GET: scSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // POST: scSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scSupplier scSupplier = db.scSuppliers.Find(id);
            db.scSuppliers.Remove(scSupplier);
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
