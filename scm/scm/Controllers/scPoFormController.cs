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

        public ActionResult Index()
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
            return View(scPoHdr);
        }

        // GET: scPoDtls/Create
        public ActionResult AddItem()
        {
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View();
        }

        // POST: scPoDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId")] scPoDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.scPoDtls.Add(scPoDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
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
            return View(scPoDtl);
        }

        // POST: scPoDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId")] scPoDtl scPoDtl)
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
            return View(scPoDtl);
        }


    }


}