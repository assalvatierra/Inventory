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
    public class scInvOutForm
    {
        public scInvOutHdr master { get; set; }
        public List<scInvOutDtl> details { get; set; }
    }

    public class scInvOutFormController : Controller
    {

        // GET: scInvOutForm
        private ScmDBContainer db = new ScmDBContainer();

        #region listing
        public ActionResult Index()
        {
            var scInvOutHdr = db.scInvOutHdrs.Include(s => s.scInvOutDtls);
            return View(scInvOutHdr.ToList());
        }
        #endregion
        #region Hdr CRUD
        // GET: scInvOutHdr/Create
        public ActionResult Create()
        {
            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name");
            return View();
        }

        // POST: scInvOutHdr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPo,scInvOutDtlId,Remarks")] scInvOutHdr scInvOutHdr)
        {
            if (ModelState.IsValid)
            {
                db.scInvOutHdrs.Add(scInvOutHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name", scInvOutHdr.scInvOutDtls);
            return View(scInvOutHdr);
        }

        // GET: scInvOutHdr/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            if (scInvOutHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name", scInvOutHdr.scInvOutDtls);
            return View(scInvOutHdr);
        }

        // POST: scInvOutHdr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPo,scInvOutDtlId,Remarks")] scInvOutHdr scInvOutHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scInvOutHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name", scInvOutHdr.scInvOutDtls);
            return View(scInvOutHdr);
        }

        #endregion

        #region Details CRUD
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["POHDRID"];
            Session["POHDRID"] = id;

            var data = new scInvOutForm
            {
                master = db.scInvOutHdrs.Find(id),
                details = db.scInvOutDtls.Where(d => d.scInvOutHdrId == id).ToList()
            };

            return View(data);

        }

        public ActionResult AddItem()
        {
            int hdrid = (int)Session["POHDRID"];
            var newitem = new scInvOutDtl();
            newitem.scInvOutHdrId = hdrid;

            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", hdrid);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id");

            return View(newitem);
        }

        // POST: scPoDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem([Bind(Include = "Id,scInvOutHdrId,scItemId,Qty,UnitPrice,scUomId")] scInvOutDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.scInvOutDtls.Add(scPoDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scPoDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scItemId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scItemId);

            return View(scPoDtl);
        }

        // GET: scPoDtls/Edit/5
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutDtl scPoDtl = db.scInvOutDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scPoDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scStoreBinId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scStoreBinId);

            return View(scPoDtl);
        }

        // POST: scPoDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scInvOutHdrId,scItemId,Qty,UnitPrice,scUomId")] scInvOutDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scPoDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scStoreBinId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scStoreBinId);

            return View(scPoDtl);
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
            var data = new scInvOutForm
            {
                master = db.scInvOutHdrs.Find(id),
                details = db.scInvOutDtls.Where(d => d.scInvOutHdrId == id).ToList()
            };

            Session["POID"] = id;
            return View(data);
        }

        // GET: scInvOutHdr/Edit/5
        public ActionResult EditHdr(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            if (scInvOutHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name", scInvOutHdr.scInvOutDtls);
            ViewBag.scInvOutDtls = db.scInvOutDtls.ToList();

            return View(scInvOutHdr);
        }

        // POST: scInvOutHdr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHdr([Bind(Include = "Id,dtPo,scInvOutDtlId,Remarks")] scInvOutHdr scInvOutHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scInvOutHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scInvOutDtlId = new SelectList(db.scInvOutDtls, "Id", "Name", scInvOutHdr.scInvOutDtls);
            ViewBag.scInvOutDtls = db.scInvOutDtls.ToList();

            return View(scInvOutHdr);
        }

        // GET: scPoDtls/Create

        #endregion
    }
}
