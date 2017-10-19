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
    public class resPrepMaterialsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resPrepMaterials
        public ActionResult Index()
        {
            var resPrepMaterials = db.resPrepMaterials.Include(r => r.resPreparation).Include(r => r.scItem).Include(r => r.scStoreBin);
            return View(resPrepMaterials.ToList());
        }

        // GET: resPrepMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPrepMaterial resPrepMaterial = db.resPrepMaterials.Find(id);
            if (resPrepMaterial == null)
            {
                return HttpNotFound();
            }
            return View(resPrepMaterial);
        }

        // GET: resPrepMaterials/Create
        public ActionResult Create()
        {
            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");
            return View();
        }

        // POST: resPrepMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,resPreparationId,scItemId,Qty,scStoreBinId")] resPrepMaterial resPrepMaterial)
        {
            if (ModelState.IsValid)
            {
                db.resPrepMaterials.Add(resPrepMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared", resPrepMaterial.resPreparationId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPrepMaterial.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPrepMaterial.scStoreBinId);
            return View(resPrepMaterial);
        }

        // GET: resPrepMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPrepMaterial resPrepMaterial = db.resPrepMaterials.Find(id);
            if (resPrepMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared", resPrepMaterial.resPreparationId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPrepMaterial.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPrepMaterial.scStoreBinId);
            return View(resPrepMaterial);
        }

        // POST: resPrepMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,resPreparationId,scItemId,Qty,scStoreBinId")] resPrepMaterial resPrepMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resPrepMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared", resPrepMaterial.resPreparationId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPrepMaterial.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPrepMaterial.scStoreBinId);
            return View(resPrepMaterial);
        }

        // GET: resPrepMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPrepMaterial resPrepMaterial = db.resPrepMaterials.Find(id);
            if (resPrepMaterial == null)
            {
                return HttpNotFound();
            }
            return View(resPrepMaterial);
        }

        // POST: resPrepMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resPrepMaterial resPrepMaterial = db.resPrepMaterials.Find(id);
            db.resPrepMaterials.Remove(resPrepMaterial);
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
