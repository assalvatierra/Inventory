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
	;





