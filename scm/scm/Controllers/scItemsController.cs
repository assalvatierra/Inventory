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
    public class scItemsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scItems
        public ActionResult Index()
        {
            dbClasses db1 = new dbClasses();
            var scItems = db1.getOrderStatus();
            return View(scItems);
        }

        // GET: scItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            return View(scItem);
        }

        // GET: scItems/Create
        public ActionResult Create()
        {
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View();
        }

        // POST: scItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,scUomId,Expirydays")] scItem scItem)
        {
            if (ModelState.IsValid)
            {
                db.scItems.Add(scItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // GET: scItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // POST: scItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,scUomId,Expirydays")] scItem scItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // GET: scItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            return View(scItem);
        }

        // POST: scItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scItem scItem = db.scItems.Find(id);
            db.scItems.Remove(scItem);
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
