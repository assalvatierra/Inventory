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