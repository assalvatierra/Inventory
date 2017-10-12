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

        public ActionResult poForm(int? id)
        {
            var data = new poForm
            {
                master = db.scPoHdrs.Find(id),
                details = db.scPoDtls.Where(d => d.scPoHdrId == id).ToList()
            };
                
            return View(data);
        }

        public ActionResult Index()
        {
            return View();
        }
    }


}