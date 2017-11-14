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
        public int LowLevel { get; set; }
    }

    public class EntStorageBin
    {
        public int Id { get; set; }
        public string Store { get; set; }
        public string BinCode { get; set; }
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemIn { get; set; }
        public decimal ItemOut { get; set; }
        public DateTime Expirydate { get; set; }
    }

    public class EntItems2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal p0 { get; set; }
        public decimal s0 { get; set; }
        public decimal p1 { get; set; }
        public decimal s1 { get; set; }
        public decimal p2 { get; set; }
        public decimal s2 { get; set; }
        public decimal p3 { get; set; }
        public decimal s3 { get; set; }
        public decimal p4 { get; set; }
        public decimal s4 { get; set; }
        public decimal p5 { get; set; }
        public decimal s5 { get; set; }
        public decimal p6 { get; set; }
        public decimal s6 { get; set; }
        public decimal p7 { get; set; }
        public decimal s7 { get; set; }
    }
    //public class EntItemSupplier
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Suppliers { get; set; }
    //}

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
		        LEFT OUTER JOIN [dbo].[scPoDtls] b on b.scPrDtlId = a.Id  and b.scItemId = a.scItemId
		        LEFT OUTER JOIN [dbo].[scRcvDtls] c on c.scPoDtlId = b.Id and c.scItemId = a.scItemId
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
                sum(isnull(c.Qty, 0)) + sum(isnull(e.Qty, 0)) ItemOut,
                Max(isnull(a.LowLevel,0)) LowLevel
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

        public List<EntItems> getLowLevelItems()
        {
            var scItems = this.getItemInventory();
            return scItems.Where(d => (d.ItemIn - d.ItemOut) <= d.LowLevel).ToList();
        }

        public List<EntStorageBin> getStorageBinInventory(int? id)
        {
            string sSQL = @"
                select
                a.Id,
                d.Name store,
                a.Code bincode,
                e.Id ItemId,
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

            if (id != null && id > 0)
                return list.Where(d => d.ItemId == (int)id).ToList();

            return list.ToList();
        }

        public List<EntItems2> getItemInventory2()
        {
            #region Sql Statement
            string sSQL = @"
select max(x.id) Id,
	max(x.Name) Name,
	CAST(SUM(x.p0) as DECIMAL) P0, CAST(SUM(x.s0) as DECIMAL) s0,
	CAST(SUM(x.p1) as DECIMAL) P1, CAST(SUM(x.s1) as DECIMAL) s1,
	CAST(SUM(x.p2) as DECIMAL) P2, CAST(SUM(x.s2) as DECIMAL) s2,
	CAST(SUM(x.p3) as DECIMAL) P3, CAST(SUM(x.s3) as DECIMAL) s3,
	CAST(SUM(x.p4) as DECIMAL) P4, CAST(SUM(x.s4) as DECIMAL) s4,
	CAST(SUM(x.p5) as DECIMAL) P5, CAST(SUM(x.s5) as DECIMAL) s5,
	CAST(SUM(x.p6) as DECIMAL) P6, CAST(SUM(x.s6) as DECIMAL) s6,
	CAST(SUM(x.p7) as DECIMAL) P7, CAST(SUM(x.s7) as DECIMAL) s7
 from 
(

    SELECT 'CUR' as tType, a.Id, max(isnull(a.Name, '')) Name,
    sum(isnull(b.Qty, 0)) 
		+ sum(isnull(d.itemQty, 0)) 
		- sum(isnull(c.Qty, 0)) 
		+ sum(isnull(e.Qty, 0)) as p0, '0' as s0,
	'0' as p1, '0' as s1,
	'0' as p2, '0' as s2,
	'0' as p3, '0' as s3,
	'0' as p4, '0' as s4,
	'0' as p5, '0' as s5,
	'0' as p6, '0' as s6,
	'0' as p7, '0' as s7
    from [dbo].[scItems] a
    left outer join [dbo].[scRcvDtls]
            b on b.scItemId = a.Id
    left outer join [dbo].[scInvOutDtls]
            c on c.scItemId = a.Id
	left outer join [dbo].[resPreparations]
			d on d.scItemId = a.Id
	left outer join [dbo].[resPrepMaterials]
			e on e.scItemId = a.Id
	Group by a.Id

	union

	select 'PO' as tType, a.Id, a.Name, 
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 0, b.Qty, 0 ) as p0, '0' as s0,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 1, b.Qty, 0 ) as p1, '0' as s1,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 2, b.Qty, 0 ) as p2, '0' as s2,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 3, b.Qty, 0 ) as p3, '0' as s3,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 4, b.Qty, 0 ) as p4, '0' as s4,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 5, b.Qty, 0 ) as p5, '0' as s5,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 6, b.Qty, 0 ) as p6, '0' as s6,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 7, b.Qty, 0 ) as p7, '0' as s7
	from scItems a
		left outer join scPoDtls b on b.scItemId = a.Id
		left outer join scPoHdrs c on c.Id = b.scPoHdrId
	
	union

	select 'SO' as tType, a.Id, a.Name, 
	'0' as p0, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 0, b.Qty, 0 ) as s0,
	'0' as p1, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 1, b.Qty, 0 ) as s1,
	'0' as p2, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 2, b.Qty, 0 ) as s2,
	'0' as p3, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 3, b.Qty, 0 ) as s3,
	'0' as p4, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 4, b.Qty, 0 ) as s4,
	'0' as p5, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 5, b.Qty, 0 ) as s5,
	'0' as p6, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 6, b.Qty, 0 ) as s6,
	'0' as p7, IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 7, b.Qty, 0 ) as s7
	from scItems a
		left outer join resItems ax on ax.scItemId = a.Id
		left outer join resOrderDtls b on b.resItemId = ax.Id
		left outer join resOrderHdrs c on c.Id = b.resOrderHdrId

) x
group by x.Id

";
            #endregion

            var list = db.Database.SqlQuery<EntItems2>(sSQL);
            return list.ToList();

        }

        public void executeSQL(string sql)
        {
            db.Database.ExecuteSqlCommand(sql);
            return;
        }

    }

    

}