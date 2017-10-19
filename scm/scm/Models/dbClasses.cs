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
        public decimal prQty { get; set; }
        public decimal poQty { get; set; }
        public decimal rcQty { get; set; }
    }

    public class EntItems
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemIn { get; set; }
        public decimal ItemOut { get; set; }
    }

    public class EntStorageBin
    {
        public int Id { get; set; }
        public string Store { get; set; }
        public string BinCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemIn { get; set; }
        public decimal ItemOut { get; set; }
        public DateTime Expirydate { get; set; }
    }

    public class dbClasses
    {
        Models.ScmDBContainer db = new ScmDBContainer();
        public List<EntOrderStatus> getOrderStatus()
        {
            string sSQL = @"
	        SELECT
		        a.scItemId Id,
		        MAX(d.Name) as Name, 
		        MAX(e.Unit) as Uom,
		        SUM( isnull(a.Qty,0) ) as prQty, 
		        SUM( IsNULL(b.Qty,0) ) as poQty, 
		        SUM( IsNULL(c.Qty,0) ) as rcQty
		        from [dbo].[scPrDtls] a
		        LEFT OUTER JOIN [dbo].[scPoDtls] b on b.scPrDtlId = a.Id
		        LEFT OUTER JOIN [dbo].[scRcvDtls] c on c.scPoDtlId = b.Id
		        LEFT OUTER JOIN [dbo].[scItems] d on d.Id = a.scItemId
		        LEFT OUTER JOIN [dbo].[scUoms] e on e.Id = d.scUomId
		        where a.Qty <> b.Qty OR b.Qty is null
		        OR b.Qty <> c.Qty OR c.Qty is null
		        Group by a.scItemId
            ";


            var list = db.Database.SqlQuery<EntOrderStatus>(sSQL);
            return list.ToList();
        }

        public List<EntItems> getItemInventory()
        {
            string sSQL = @"
                SELECT
                a.Id,
                max(isnull(a.Name, '')) itemname,
                sum(isnull(b.Qty, 0)) + sum(isnull(d.itemQty, 0)) ItemIn,
                sum(isnull(c.Qty, 0)) + sum(isnull(e.Qty, 0)) ItemOut
                
                from [dbo].[scItems] a
                left outer join [dbo].[scRcvDtls]
                        b on b.scItemId = a.Id
                left outer join [dbo].[scInvOutDtls]
                        c on c.scItemId = a.Id
				left outer join [dbo].[resPreparations]
						d on d.scItemId = a.Id
				left outer join [dbo].[resPrepMaterials]
						e on e.scItemId = a.Id

				Group by a.Id;
                ";

            var list = db.Database.SqlQuery<EntItems>(sSQL);
            return list.ToList();
        }

        public List<EntStorageBin> getStorageBinInventory()
        {
            string sSQL = @"
                select
                a.Id,
                d.Name store,
                a.Code bincode,
                isnull(e.Name, '') itemname,
                isnull(b.Qty, 0) ItemIn,
                isnull(c.Qty, 0) ItemOut,
                a.ExpiryDate
                from[dbo].[scStoreBins] a
                left outer join[dbo].[scRcvDtls]
                        b on b.scStoreBinId = a.Id
                left outer join[dbo].[scInvOutDtls]
                        c on c.scStoreBinId = a.Id
                left outer join[dbo].[scStorages]
                        d on d.Id = a.scStorageId
                left outer join[dbo].[scItems]
                        e on e.Id = b.scItemId
                where a.BinStatus = 'ACT'
                ";

            var list = db.Database.SqlQuery<EntStorageBin>(sSQL);
            return list.ToList();
        }

        public void executeSQL(string sql)
        {
            db.Database.ExecuteSqlCommand(sql);
            return;
        }

    }

    

}