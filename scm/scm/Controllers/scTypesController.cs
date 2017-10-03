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
    public class scTypesController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scTypes
        public ActionResult Index()
        {
            return View(db.scTypes.ToList());
        }

        // GET: scTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scType scType = db.scTypes.Find(id);
            if (scType == null)
            {
                return HttpNotFound();
            }
            return View(scType);
        }

        // GET: scTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] scType scType)
        {
            if (ModelState.IsValid)
            {
                db.scTypes.Add(scType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scType);
        }

        // GET: scTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scType scType = db.scTypes.Find(id);
            if (scType == null)
            {
                return HttpNotFound();
            }
            return View(scType);
        }

        // POST: scTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] scType scType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scType);
        }

        // GET: scTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scType scType = db.scTypes.Find(id);
            if (scType == null)
            {
                return HttpNotFound();
            }
            return View(scType);
        }

        // POST: scTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scType scType = db.scTypes.Find(id);
            db.scTypes.Remove(scType);
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
