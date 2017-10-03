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
    public class scUomsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scUoms
        public ActionResult Index()
        {
            return View(db.scUoms.ToList());
        }

        // GET: scUoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scUom scUom = db.scUoms.Find(id);
            if (scUom == null)
            {
                return HttpNotFound();
            }
            return View(scUom);
        }

        // GET: scUoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scUoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Unit,Desc")] scUom scUom)
        {
            if (ModelState.IsValid)
            {
                db.scUoms.Add(scUom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scUom);
        }

        // GET: scUoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scUom scUom = db.scUoms.Find(id);
            if (scUom == null)
            {
                return HttpNotFound();
            }
            return View(scUom);
        }

        // POST: scUoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Unit,Desc")] scUom scUom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scUom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scUom);
        }

        // GET: scUoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scUom scUom = db.scUoms.Find(id);
            if (scUom == null)
            {
                return HttpNotFound();
            }
            return View(scUom);
        }

        // POST: scUoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scUom scUom = db.scUoms.Find(id);
            db.scUoms.Remove(scUom);
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
