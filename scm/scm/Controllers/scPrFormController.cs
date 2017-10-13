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
    public class scPrFormController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scPrForm
        public ActionResult Index()
        {
            return View(db.scPrHdrs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["PRHDRID"];
            Session["PRHDRID"] = id;
            return View(db.scPrDtls.Where(d => d.scPrHdrId == id).ToList());
        }

        #region Item Functions
        // GET: scPrDtls/Create
        public ActionResult CreateItem()
        {
            int hdrid = (int)Session["PRHDRID"];
            var newitem = new scPrDtl();
            newitem.scPrHdrId = hdrid;

            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View(newitem);
        }

        // POST: scPrDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "Id,scPrHdrId,scItemId,Qty,scUomId")] scPrDtl scPrDtl)
        {
            if (ModelState.IsValid)
            {
                db.scPrDtls.Add(scPrDtl);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // GET: scPrDtls/Edit/5
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            if (scPrDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // POST: scPrDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scPrHdrId,scItemId,Qty,scUomId")] scPrDtl scPrDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPrDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // GET: scPrDtls/Delete/5
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            if (scPrDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPrDtl);
        }

        // POST: scPrDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            db.scPrDtls.Remove(scPrDtl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}