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
        private Models.dbClasses db1 = new dbClasses();
        SelectList slStatus = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "NEW", Value = "NEW", Selected=true },
                new SelectListItem { Text = "APPROVED", Value = "APP", Selected=false },
                new SelectListItem { Text = "CANCELLED", Value = "CAN", Selected=false }

            }, "Text", "Value" );
        
        // GET: scPrForm
        public ActionResult Index()
        {
            ViewBag.LowLevelItems = db1.getLowLevelItems();
            return View(db.scPrHdrs.ToList());
        }

        #region hdr functions
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["PRHDRID"];
            Session["PRHDRID"] = id;

            ViewBag.LowLevelItems = db1.getLowLevelItems();

            return View(db.scPrDtls.Where(d => d.scPrHdrId == id).ToList());
        }
        
        // GET: scPrHdrs/Create
        public ActionResult Create()
        {
            ViewBag.Status = this.slStatus;
            return View();
        }

        // POST: scPrHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPr,Remarks,Status")] scPrHdr scPrHdr)
        {
            if (ModelState.IsValid)
            {
                db.scPrHdrs.Add(scPrHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scPrHdr);
        }

        // GET: scPrHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrHdr scPrHdr = db.scPrHdrs.Find(id);
            if (scPrHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = this.slStatus;
            return View(scPrHdr);
        }

        // POST: scPrHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPr,Remarks,Status")] scPrHdr scPrHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPrHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status = this.slStatus;
            return View(scPrHdr);
        }

        #endregion

        #region Item Functions
        // GET: scPrDtls/Create
        public ActionResult CreateItem()
        {
            int hdrid = (int)Session["PRHDRID"];
            var newitem = new scPrDtl();
            newitem.scPrHdrId = hdrid;

            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks",hdrid);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");

            ViewBag.LowLevelItems = db1.getLowLevelItems();

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

            ViewBag.LowLevelItems = db1.getLowLevelItems();

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

            ViewBag.LowLevelItems = db1.getLowLevelItems();

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

            ViewBag.LowLevelItems = db1.getLowLevelItems();

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
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            db.scPrDtls.Remove(scPrDtl);
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