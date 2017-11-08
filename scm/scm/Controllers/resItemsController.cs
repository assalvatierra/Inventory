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
    public class resItemsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resItems
        public ActionResult Index()
        {
            var resItems = db.resItems.Include(r => r.scItem);
            return View(resItems.ToList());
        }

        // GET: resItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resItem resItem = db.resItems.Find(id);
            if (resItem == null)
            {
                return HttpNotFound();
            }
            return View(resItem);
        }

        // GET: resItems/Create
        public ActionResult Create()
        {
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            return View();
        }

        // POST: resItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scItemId,Description,Price,barcode,resQty")] resItem resItem)
        {
            if (ModelState.IsValid)
            {
                db.resItems.Add(resItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resItem.scItemId);
            return View(resItem);
        }

        // GET: resItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resItem resItem = db.resItems.Find(id);
            if (resItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resItem.scItemId);
            return View(resItem);
        }

        // POST: resItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scItemId,Description,Price,barcode,resQty")] resItem resItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resItem.scItemId);
            return View(resItem);
        }

        // GET: resItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resItem resItem = db.resItems.Find(id);
            if (resItem == null)
            {
                return HttpNotFound();
            }
            return View(resItem);
        }

        // POST: resItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resItem resItem = db.resItems.Find(id);
            db.resItems.Remove(resItem);
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
