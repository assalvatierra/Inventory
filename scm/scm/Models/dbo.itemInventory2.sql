
	select 'PO' as tType, a.Id, a.Name, 
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 0, b.Qty, 0 ) as d0,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 1, b.Qty, 0 ) as d1,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 2, b.Qty, 0 ) as d2,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 3, b.Qty, 0 ) as d3,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 4, b.Qty, 0 ) as d4,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 5, b.Qty, 0 ) as d5,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 6, b.Qty, 0 ) as d6,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 7, b.Qty, 0 ) as d7
	from scItems a
		left outer join scPoDtls b on b.scItemId = a.Id
		left outer join scPoHdrs c on c.Id = b.scPoHdrId
	
	union

	select 'SO' as tType, a.Id, a.Name, 
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 0, b.Qty, 0 ) as d0,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 1, b.Qty, 0 ) as d1,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 2, b.Qty, 0 ) as d2,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 3, b.Qty, 0 ) as d3,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 4, b.Qty, 0 ) as d4,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 5, b.Qty, 0 ) as d5,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 6, b.Qty, 0 ) as d6,
	IIF( DATEDIFF(day,GETDATE(),c.dtDelivery) = 7, b.Qty, 0 ) as d7
	from scItems a
		left outer join resItems ax on ax.scItemId = a.Id
		left outer join resOrderDtls b on b.resItemId = ax.Id
		left outer join resOrderHdrs c on c.Id = b.resOrderHdrId
	;





