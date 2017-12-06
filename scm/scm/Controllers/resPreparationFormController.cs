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
    public class resPreparationFormController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();
        private Models.dbClasses db1 = new dbClasses();
        #region preparation header
        // GET: resPreparations
        public ActionResult Index()
        {
            var resPreparations = db.resPreparations.Include(r => r.resRecipe).Include(r => r.scItem).Include(r => r.scStoreBin);
            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View(resPreparations.ToList());
        }

        // GET: resPreparations/Create
        public ActionResult Create()
        {
            ViewBag.resRecipeId = new SelectList(db.resRecipes, "Id", "Name");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");

            // added by joy  - for modal object
            var resPreparations = db.scItems.Include(s => s.Name);
            IEnumerable<scItem> myscItems = db.scItems.ToList();
            ViewBag.scItems = myscItems;
            IEnumerable<scStoreBin> myscStorages = db.scStoreBins.ToList();
            ViewBag.scStoreBins = myscStorages;
            return View();
        }

        // POST: resPreparations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPrepared,resRecipeId,resQty,itemQty,scItemId,scStoreBinId")] resPreparation resPreparation)
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

            // added by joy  - for modal object
            var resPreparations = db.scItems.Include(s => s.Name);
            IEnumerable<scItem> myscItems = db.scItems.ToList();
            ViewBag.scItems = myscItems;

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
            

            // added by joy  - for modal object
            var resPreparations = db.scItems.Include(s => s.Name);
            IEnumerable<scItem> myscItems = db.scItems.ToList();
            ViewBag.scItems = myscItems;

            return View(resPreparation);
        }

        // POST: resPreparations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPrepared,resRecipeId,resQty,itemQty,scItemId,scStoreBinId")] resPreparation resPreparation)
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

        #endregion

        #region Preparation Detail
        // GET: resPrepMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["RESPREPID"];
            Session["RESPREPID"] = id;
            ViewBag.LowLevelItems = db1.getLowLevelItems();
            return View(db.resPrepMaterials.Where(d => d.resPreparationId == id).ToList());
        }

        // GET: resPrepMaterials/Create
        public ActionResult CreateItem()
        {
            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");
            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View();
        }

        // POST: resPrepMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "Id,resPreparationId,scItemId,Qty,scStoreBinId")] resPrepMaterial resPrepMaterial)
        {
            if (ModelState.IsValid)
            {
                db.resPrepMaterials.Add(resPrepMaterial);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared", resPrepMaterial.resPreparationId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPrepMaterial.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPrepMaterial.scStoreBinId);
            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View(resPrepMaterial);
        }

        // GET: resPrepMaterials/Edit/5
        public ActionResult EditItem(int? id)
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
            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View(resPrepMaterial);
        }

        // POST: resPrepMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,resPreparationId,scItemId,Qty,scStoreBinId")] resPrepMaterial resPrepMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resPrepMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.resPreparationId = new SelectList(db.resPreparations, "Id", "dtPrepared", resPrepMaterial.resPreparationId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resPrepMaterial.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", resPrepMaterial.scStoreBinId);
            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View(resPrepMaterial);
        }

        // GET: resPrepMaterials/Delete/5
        public ActionResult DeleteItem(int? id)
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
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            resPrepMaterial resPrepMaterial = db.resPrepMaterials.Find(id);
            db.resPrepMaterials.Remove(resPrepMaterial);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        #endregion

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