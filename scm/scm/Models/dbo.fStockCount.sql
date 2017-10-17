

CREATE FUNCTION [dbo].[fStockCount]()
RETURNS @returntable TABLE
(
	c1 int,
	c2 char(5)
)
AS
BEGIN
	INSERT @returntable
	SELECT 1, 2


	RETURN
END
