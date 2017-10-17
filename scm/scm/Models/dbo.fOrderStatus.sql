

CREATE FUNCTION [dbo].[fOrderStatus]()
RETURNS @returntable TABLE
(
	Id int,
	Name char(80),
	Uom char(10),
	prQty int,
	poQty int,
	rcQty int
)
AS
BEGIN
	INSERT @returntable
	select 
		a.scItemId,
		MAX(d.Name) as itemname, 
		MAX(e.Unit) as itemunit,
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
	RETURN
END
