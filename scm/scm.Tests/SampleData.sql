-- insert purchase request (hdr) --
insert [dbo].[scPrHdrs]([dtPr],[Remarks],[Status]) values
('10/19/2017','UnitTest.101','NEW');

delete from [dbo].[scPrHdrs] where  [Remarks] = 'UnitTest.101';

-- insert purchase request (dtl) --
insert into [dbo].[scPrDtls]([scPrHdrId],[scItemId],[scUomId],[Qty]) values
('1','1','1','133');

delete from [dbo].[scPrDtls] where [scPrHdrId] = '2';

-- re-init seed -- 
DBCC CHECKIDENT ('scPrHdrs', RESEED, 0);