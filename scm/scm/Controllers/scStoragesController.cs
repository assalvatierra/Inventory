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
    public class scStoragesController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scStorages
        public ActionResult Index()
        {
            var scStorages = db.scStorages.Include(s => s.scStoreType);
            return View(scStorages.ToList());
        }

        // GET: scStorages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStorage scStorage = db.scStorages.Find(id);
            if (scStorage == null)
            {
                return HttpNotFound();
            }
            return View(scStorage);
        }

        // GET: scStorages/Create
        public ActionResult Create()
        {
            ViewBag.scStoreTypeId = new SelectList(db.scStoreTypes, "Id", "Type");
            return View();
        }

        // POST: scStorages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,scStoreTypeId")] scStorage scStorage)
        {
            if (ModelState.IsValid)
            {
                db.scStorages.Add(scStorage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scStoreTypeId = new SelectList(db.scStoreTypes, "Id", "Type", scStorage.scStoreTypeId);
            return View(scStorage);
        }

        // GET: scStorages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStorage scStorage = db.scStorages.Find(id);
            if (scStorage == null)
            {
                return HttpNotFound();
            }
            ViewBag.scStoreTypeId = new SelectList(db.scStoreTypes, "Id", "Type", scStorage.scStoreTypeId);

            // added by joy  - for modal object
            IEnumerable<scStoreType> myscStoreTypes = db.scStoreTypes.ToList();
            ViewBag.scStoreTypes = myscStoreTypes;

            return View(scStorage);
        }

        // POST: scStorages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,scStoreTypeId")] scStorage scStorage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scStorage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scStoreTypeId = new SelectList(db.scStoreTypes, "Id", "Type", scStorage.scStoreTypeId);
            return View(scStorage);
        }

        // GET: scStorages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStorage scStorage = db.scStorages.Find(id);
            if (scStorage == null)
            {
                return HttpNotFound();
            }
            return View(scStorage);
        }

        // POST: scStorages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scStorage scStorage = db.scStorages.Find(id);
            db.scStorages.Remove(scStorage);
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
