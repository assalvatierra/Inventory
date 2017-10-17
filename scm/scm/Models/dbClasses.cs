using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scm.Models
{
    public class EntOrderStatus
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Uom { get; set; }
        public int prQty { get; set; }
        public int poQty { get; set; }
        public int rcQty { get; set; }
    }

    public class dbClasses
    {
        Models.ScmDBContainer db = new ScmDBContainer();
        public List<EntOrderStatus> getOrderStatus()
        {
            string sSQL = "SELECT * FROM [dbo].[fOrderStatus]()";
            var list = db.Database.SqlQuery<EntOrderStatus>(sSQL);
            return list.ToList();
        }
    }

}