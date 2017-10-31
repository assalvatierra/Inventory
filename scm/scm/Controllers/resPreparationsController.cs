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
    public class resPreparationsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resPreparations
        public ActionResult Index()
        {
            var resPreparations = db.resPreparations.Include(r => r.resRecipe).Include(r => r.scItem).Include(r => r.scStoreBin);
            return View(resPreparations.ToList());
        }

        // GET: resPreparations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPreparation resPreparation = db.resPreparations.Find(id);
            if (resPreparation == null)
            {
                return HttpNotFound();
            }
            return View(resPreparation);
        }

        // GET: resPreparations/Create
        public ActionResult Create()
        {
            ViewBag.resRecipeId = new SelectList(db.resRecipes, "Id", "Name");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");
            return View();
        }

        // POST: resPreparations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPrepared,resRecipeId,resQty,itemty,scItemId,scStoreBinId")] resPreparation resPreparation)
        {
            if (ModelState.IsValid)
            {
                db.resPreparations.Add(resPreparation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resRecipeId = new SelectList(db.resRecipes, "Id", "Name", resPreparation.resRecipeId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPreparation.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPreparation.scStoreBinId);
            return View(resPreparation);
        }

        // GET: resPreparations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPreparation resPreparation = db.resPreparations.Find(id);
            if (resPreparation == null)
            {
                return HttpNotFound();
            }
            ViewBag.resRecipeId = new SelectList(db.resRecipes, "Id", "Name", resPreparation.resRecipeId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPreparation.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPreparation.scStoreBinId);
            return View(resPreparation);
        }

        // POST: resPreparations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPrepared,resRecipeId,resQty,itemty,scItemId,scStoreBinId")] resPreparation resPreparation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resPreparation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resRecipeId = new SelectList(db.resRecipes, "Id", "Name", resPreparation.resRecipeId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPreparation.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPreparation.scStoreBinId);
            return View(resPreparation);
        }

        // GET: resPreparations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resPreparation resPreparation = db.resPreparations.Find(id);
            if (resPreparation == null)
            {
                return HttpNotFound();
            }
            return View(resPreparation);
        }

        // POST: resPreparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resPreparation resPreparation = db.resPreparations.Find(id);
            db.resPreparations.Remove(resPreparation);
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
