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
    public class poForm
    {
        public scPoHdr master { get; set; }
        public List<scPoDtl> details { get; set; }
    }
    public class scPoFormController : Controller
    {
        // GET: scPoForm
        private ScmDBContainer db = new ScmDBContainer();


        #region listing
        public ActionResult Index()
        {
           
            var scPoHdrs = db.scPoHdrs.Include(s => s.scSupplier);

            Models.dbClasses db1 = new dbClasses();
            ViewBag.ItemStatus = db1.getOrderStatus();

            return View(scPoHdrs.ToList());
        }
        #endregion
        #region Hdr CRUD
        // GET: scPoHdrs/Create
        public ActionResult Create()
        {
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name");
            return View();
        }

        // POST: scPoHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPo,scSupplierId,dtDelivery,Remarks")] scPoHdr scPoHdr)
        {
            if (ModelState.IsValid)
            {
                db.scPoHdrs.Add(scPoHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        // GET: scPoHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            if (scPoHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        // POST: scPoHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPo,scSupplierId,dtDelivery,Remarks")] scPoHdr scPoHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        #endregion

        #region Details CRUD
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["POHDRID"];
            Session["POHDRID"] = id;

            var data = new poForm
            {
                master = db.scPoHdrs.Find(id),
                details = db.scPoDtls.Where(d => d.scPoHdrId == id).ToList()
            };

            return View(data);

        }

        public ActionResult AddItem()
        {
            int hdrid = (int)Session["POHDRID"];
            var newitem = new scPoDtl();
            newitem.scPoHdrId = hdrid;

            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", hdrid);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            ViewBag.scPrDtlId = new SelectList(
                db.scPrDtls.Select(s => new { Id = s.Id, Text = s.Id + "-" + s.scItem.Name + " [Requested:" + s.Qty + "]"}
                ), "Id", "Text", null);

            Models.dbClasses db1 = new dbClasses();
            ViewBag.requestedItems = db1.getOrderStatus();

            return View(newitem);
        }

        // POST: scPoDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId,scPrDtlId")] scPoDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.scPoDtls.Add(scPoDtl);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(
                db.scPrDtls.Select(s => new { Id = s.Id, Text = s.Id + "-" + s.scItem.Name + " [Requested:" + s.Qty + "]" }
                ), "Id", "Text", null);

            Models.dbClasses db1 = new dbClasses();
            ViewBag.requestedItems = db1.getOrderStatus();

            return View(scPoDtl);
        }

        // GET: scPoDtls/Edit/5
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(
                db.scPrDtls.Select(s => new { Id = s.Id, Text = s.Id + "-" + s.scItem.Name + " [Requested:" + s.Qty + "]" }
                ), "Id", "Text", null);

            Models.dbClasses db1 = new dbClasses();
            ViewBag.requestedItems = db1.getOrderStatus();
            return View(scPoDtl);
        }

        // POST: scPoDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId,scPrDtlId")] scPoDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(
                db.scPrDtls.Select(s => new { Id = s.Id, Text = s.Id + "-" + s.scItem.Name + " [Requested:" + s.Qty + "]" }
                ), "Id", "Text", null);

            Models.dbClasses db1 = new dbClasses();
            ViewBag.requestedItems = db1.getOrderStatus();
            return View(scPoDtl);
        }

        // GET: scPoDtls/Delete/5
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPoDtl);
        }

        // POST: scPoDtls/Delete/5
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            db.scPoDtls.Remove(scPoDtl);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        #endregion

        #region UNUSED
        public ActionResult Index1()
        {
            int poId = (int)Session["POID"];
            return RedirectToAction("poForm", new { id = poId });
        }

        public ActionResult poForm(int? id)
        {
            var data = new poForm
            {
                master = db.scPoHdrs.Find(id),
                details = db.scPoDtls.Where(d => d.scPoHdrId == id).ToList()
            };

            Session["POID"] = id;
            return View(data);
        }

        // GET: scPoHdrs/Edit/5
        public ActionResult EditHdr(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            if (scPoHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            ViewBag.scSuppliers = db.scSuppliers.ToList();

            return View(scPoHdr);
        }

        // POST: scPoHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHdr([Bind(Include = "Id,dtPo,scSupplierId,Remarks")] scPoHdr scPoHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            ViewBag.scSuppliers = db.scSuppliers.ToList();

            return View(scPoHdr);
        }

        // GET: scPoDtls/Create

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