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
    public class scCategoriesController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scCategories
        public ActionResult Index()
        {
            return View(db.scCategories.ToList());
        }

        // GET: scCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scCategory scCategory = db.scCategories.Find(id);
            if (scCategory == null)
            {
                return HttpNotFound();
            }
            return View(scCategory);
        }

        // GET: scCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] scCategory scCategory)
        {
            if (ModelState.IsValid)
            {
                db.scCategories.Add(scCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scCategory);
        }

        // GET: scCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scCategory scCategory = db.scCategories.Find(id);
            if (scCategory == null)
            {
                return HttpNotFound();
            }
            return View(scCategory);
        }

        // POST: scCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] scCategory scCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scCategory);
        }

        // GET: scCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scCategory scCategory = db.scCategories.Find(id);
            if (scCategory == null)
            {
                return HttpNotFound();
            }
            return View(scCategory);
        }

        // POST: scCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scCategory scCategory = db.scCategories.Find(id);
            db.scCategories.Remove(scCategory);
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
