-- Purchase Request status --
 SELECT
	a.scItemId Id,
	MAX(d.Name) as Name, 
	MAX(e.Unit) as Uom,
	SUM( isnull(a.Qty,0) ) as prQty, 
	SUM( IsNULL(b.Qty,0) ) as poQty, 
	SUM( IsNULL(c.Qty,0) ) as rcQty, 
    sum(isnull(c.Qty, 0)) + sum(isnull(g.itemQty, 0)) ItemIn,
    sum(isnull(f.Qty, 0)) + sum(isnull(h.Qty, 0)) ItemOut
	from [dbo].[scPrDtls] a
	LEFT OUTER JOIN [dbo].[scPoDtls] b on b.scPrDtlId = a.Id
	LEFT OUTER JOIN [dbo].[scRcvDtls] c on c.scPoDtlId = b.Id
	LEFT OUTER JOIN [dbo].[scItems] d on d.Id = a.scItemId
	LEFT OUTER JOIN [dbo].[scUoms] e on e.Id = d.scUomId
    left outer join [dbo].[scInvOutDtls]
            f on f.scItemId = d.Id
	left outer join [dbo].[resPreparations]
			g on g.scItemId = d.Id
	left outer join [dbo].[resPrepMaterials]
			h on h.scItemId = d.Id
	where a.Qty <> b.Qty OR b.Qty is null
	OR b.Qty <> c.Qty OR c.Qty is null
	Group by a.scItemId

	;

    SELECT
    a.Id,
    max(isnull(a.Name, '')) itemname,
	'  ' as Uom,
	0 as prQty, 
	0 as poQty, 
	0 as rcQty, 
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
    ;


-- end of item query