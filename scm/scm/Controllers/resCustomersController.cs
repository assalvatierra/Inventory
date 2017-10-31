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
    public class resCustomersController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resCustomers
        public ActionResult Index()
        {
            return View(db.resCustomers.ToList());
        }

        // GET: resCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resCustomer resCustomer = db.resCustomers.Find(id);
            if (resCustomer == null)
            {
                return HttpNotFound();
            }
            return View(resCustomer);
        }

        // GET: resCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks,TelNo,Address")] resCustomer resCustomer)
        {
            if (ModelState.IsValid)
            {
                db.resCustomers.Add(resCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resCustomer);
        }

        // GET: resCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resCustomer resCustomer = db.resCustomers.Find(id);
            if (resCustomer == null)
            {
                return HttpNotFound();
            }
            return View(resCustomer);
        }

        // POST: resCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks,TelNo,Address")] resCustomer resCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resCustomer);
        }

        // GET: resCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resCustomer resCustomer = db.resCustomers.Find(id);
            if (resCustomer == null)
            {
                return HttpNotFound();
            }
            return View(resCustomer);
        }

        // POST: resCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resCustomer resCustomer = db.resCustomers.Find(id);
            db.resCustomers.Remove(resCustomer);
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
