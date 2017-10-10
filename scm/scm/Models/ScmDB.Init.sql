Insert Into scUoms([Unit], [Desc]) values
('PCS','Pieces'),('KLS','Kilos'),('BXS','Boxes'),('BDL','Bundle');

Insert into scCategories([Name]) values
('General Items'),('Dry'),('Frozen'),('Refrigerated'),('Perishable'),('Non-perishable'),('Organic');

Insert into scItems([Name],[scUomId],[Expirydays]) values
('Item101',1,5),('Item102',1,7),('Product AAA',1,10),('Product BBB',1,20);

Insert Into scItemCategories([scCategoryId],[scItemId]) values
(1,1),(1,2),(1,3),(1,4),(2,1),(2,2),(3,3),(4,4);


Insert Into scStoreTypes([Type]) values
('Store'),('Warehouse'),('StockRoom');

Insert Into scStorages([Name],[scStoreTypeId]) values
('Main',1),('Branch 01',1),('Warehouse 01',2);

Insert into scStoreBins([Code],[scStorageId],[scItemId],[ExpiryDate],[PostedDate],[PostedQty],[BinStatus]) values
('bin101',1,1,'10/15/2017','10/10/2017',0,'ACT'),
('bin201',1,2,'10/15/2017','10/10/2017',0,'ACT'),
('bin301',1,3,'11/15/2017','10/10/2017',0,'ACT'),
('bin401',1,4,'11/15/2017','10/10/2017',0,'ACT'),
('bin102',1,1,'10/20/2017','10/10/2017',0,'ACT'),
('bin202',1,2,'10/20/2017','10/10/2017',0,'ACT');

Insert into scSuppliers([Name],[Remarks]) values
('supplier 101','test supplier'),('supplier 202', 'test supplier');


--end--