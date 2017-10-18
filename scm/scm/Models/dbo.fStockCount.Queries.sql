
-- helper queries --
select * from [dbo].scItems;
select * from [dbo].[scPrDtls];
select * from [dbo].[scPoDtls];
-- Purchase Request status --
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
;
-- end of request status --



-- PR/PO Status --
select 
	a.scItemId,
	d.Name as itemname, 
	a.Qty as prQty, 
	b.Qty as poQty, 
	c.Qty as rcQty,
	* 
	from [dbo].[scPrDtls] a
	LEFT OUTER JOIN [dbo].[scPoDtls] b on b.scPrDtlId = a.Id
	LEFT OUTER JOIN [dbo].[scRcvDtls] c on c.scPoDtlId = b.Id
	LEFT OUTER JOIN [dbo].scItems d on d.Id = a.scItemId

	where a.Qty <> b.Qty OR b.Qty is null
	OR b.Qty <> c.Qty OR c.Qty is null
;
-- end of PR/PO Status



 -- helper sqls --
select * from [dbo].[scPoDtls];
select * from [dbo].[scRcvDtls];
-- Purchase Order status --
select 
	a.scItemId,
	c.Name, 
	a.Qty prQty, 
	b.Qty poQty, 
	*
	from [dbo].[scPoDtls] a
	LEFT OUTER JOIN [dbo].[scRcvDtls] b on B.scPoDtlId = a.Id
	LEFT OUTER JOIN [dbo].scItems c on c.Id = a.scItemId
;
-- end of Order status --

-- bin queries --
select 
a.Id,
d.Name store,
a.Code bincode,
isnull(e.Name,'') itemname,
isnull(b.Qty,0) ItemIn,
isnull(c.Qty,0) ItemOut,
a.ExpiryDate,
* 
from [dbo].[scStoreBins] a
left outer join [dbo].[scRcvDtls] b on b.scStoreBinId = a.Id
left outer join [dbo].[scInvOutDtls] c on c.scStoreBinId = a.Id
left outer join [dbo].[scStorages] d on d.Id = a.scStorageId
left outer join [dbo].[scItems] e on e.Id = b.scItemId
where a.BinStatus = 'ACT'


-- end of bin queries --


-- Item Query --

                SELECT
                a.Id,
                max(isnull(a.Name, '')) itemname,
                sum(isnull(b.Qty, 0)) ItemIn,
                sum(isnull(c.Qty, 0)) ItemOut
                
                from [dbo].[scItems] a
                left outer join[dbo].[scRcvDtls]
                        b on b.scItemId = a.Id
                left outer join[dbo].[scInvOutDtls]
                        c on c.scItemId = a.Id

				Group by a.Id;
                ;


-- end of item query