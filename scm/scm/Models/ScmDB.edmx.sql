
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2017 08:56:20
-- Generated from EDMX file: D:\Data\Real\Apps\GitHub\Inventory\scm\scm\Models\ScmDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-scm-20170920070917];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_scUomscItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItems] DROP CONSTRAINT [FK_scUomscItem];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoragescStoreBin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scStoreBins] DROP CONSTRAINT [FK_scStoragescStoreBin];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscItemSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItemSuppliers] DROP CONSTRAINT [FK_scItemscItemSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_scSupplierscItemSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItemSuppliers] DROP CONSTRAINT [FK_scSupplierscItemSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_scRcvHdrscRcvDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scRcvDtls] DROP CONSTRAINT [FK_scRcvHdrscRcvDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscRcvDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scRcvDtls] DROP CONSTRAINT [FK_scItemscRcvDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scSupplierscRcvHdr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scRcvHdrs] DROP CONSTRAINT [FK_scSupplierscRcvHdr];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoreBinscRcvDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scRcvDtls] DROP CONSTRAINT [FK_scStoreBinscRcvDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scPoHdrscPoDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPoDtls] DROP CONSTRAINT [FK_scPoHdrscPoDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scSupplierscPoHdr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPoHdrs] DROP CONSTRAINT [FK_scSupplierscPoHdr];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscPoDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPoDtls] DROP CONSTRAINT [FK_scItemscPoDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scUomscPoDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPoDtls] DROP CONSTRAINT [FK_scUomscPoDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scUomscItemSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItemSuppliers] DROP CONSTRAINT [FK_scUomscItemSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_scPoDtlscRcvDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scRcvDtls] DROP CONSTRAINT [FK_scPoDtlscRcvDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_resReciperesIngredients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resIngredients1] DROP CONSTRAINT [FK_resReciperesIngredients];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemresIngredients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resIngredients1] DROP CONSTRAINT [FK_scItemresIngredients];
GO
IF OBJECT_ID(N'[dbo].[FK_resMenuresMenuItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resMenuItems1] DROP CONSTRAINT [FK_resMenuresMenuItems];
GO
IF OBJECT_ID(N'[dbo].[FK_resReciperesMenuItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resMenuItems1] DROP CONSTRAINT [FK_resReciperesMenuItem];
GO
IF OBJECT_ID(N'[dbo].[FK_resCustomerresOrderHdr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resOrderHdrs] DROP CONSTRAINT [FK_resCustomerresOrderHdr];
GO
IF OBJECT_ID(N'[dbo].[FK_resOrderHdrresOrderDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resOrderDtls] DROP CONSTRAINT [FK_resOrderHdrresOrderDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_resCategoryresMenuCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resMenuCategories] DROP CONSTRAINT [FK_resCategoryresMenuCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_resMenuresMenuCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resMenuCategories] DROP CONSTRAINT [FK_resMenuresMenuCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_resMenuresOrderDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resOrderDtls] DROP CONSTRAINT [FK_resMenuresOrderDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemresItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resItems] DROP CONSTRAINT [FK_scItemresItem];
GO
IF OBJECT_ID(N'[dbo].[FK_resItemresOrderDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resOrderDtls] DROP CONSTRAINT [FK_resItemresOrderDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scInvOutHdrscInvOutDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scInvOutDtls] DROP CONSTRAINT [FK_scInvOutHdrscInvOutDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscInvOutDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scInvOutDtls] DROP CONSTRAINT [FK_scItemscInvOutDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoreBinscInvOutDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scInvOutDtls] DROP CONSTRAINT [FK_scStoreBinscInvOutDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_resOrderDtlscInvOutDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scInvOutDtls] DROP CONSTRAINT [FK_resOrderDtlscInvOutDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_resPreparationresPreparationDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPrepMaterials] DROP CONSTRAINT [FK_resPreparationresPreparationDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_resReciperesPreparation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPreparations] DROP CONSTRAINT [FK_resReciperesPreparation];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemresPreparationDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPrepMaterials] DROP CONSTRAINT [FK_scItemresPreparationDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoreBinresPreparationDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPrepMaterials] DROP CONSTRAINT [FK_scStoreBinresPreparationDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemresPreparation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPreparations] DROP CONSTRAINT [FK_scItemresPreparation];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoreBinresPreparation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resPreparations] DROP CONSTRAINT [FK_scStoreBinresPreparation];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscStoreBin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scStoreBins] DROP CONSTRAINT [FK_scItemscStoreBin];
GO
IF OBJECT_ID(N'[dbo].[FK_scStoreTypescStorage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scStorages] DROP CONSTRAINT [FK_scStoreTypescStorage];
GO
IF OBJECT_ID(N'[dbo].[FK_scCategoryscItemCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItemCategories] DROP CONSTRAINT [FK_scCategoryscItemCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscItemCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scItemCategories] DROP CONSTRAINT [FK_scItemscItemCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_scPrHdrscPrDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPrDtls] DROP CONSTRAINT [FK_scPrHdrscPrDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scItemscPrDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPrDtls] DROP CONSTRAINT [FK_scItemscPrDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scUomscPrDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPrDtls] DROP CONSTRAINT [FK_scUomscPrDtl];
GO
IF OBJECT_ID(N'[dbo].[FK_scPrDtlscPoDtl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[scPoDtls] DROP CONSTRAINT [FK_scPrDtlscPoDtl];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[scSuppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scSuppliers];
GO
IF OBJECT_ID(N'[dbo].[scItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scItems];
GO
IF OBJECT_ID(N'[dbo].[scUoms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scUoms];
GO
IF OBJECT_ID(N'[dbo].[scStorages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scStorages];
GO
IF OBJECT_ID(N'[dbo].[scStoreBins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scStoreBins];
GO
IF OBJECT_ID(N'[dbo].[scItemSuppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scItemSuppliers];
GO
IF OBJECT_ID(N'[dbo].[scRcvHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scRcvHdrs];
GO
IF OBJECT_ID(N'[dbo].[scRcvDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scRcvDtls];
GO
IF OBJECT_ID(N'[dbo].[scPoHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scPoHdrs];
GO
IF OBJECT_ID(N'[dbo].[scPoDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scPoDtls];
GO
IF OBJECT_ID(N'[dbo].[resMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resMenus];
GO
IF OBJECT_ID(N'[dbo].[resRecipes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resRecipes];
GO
IF OBJECT_ID(N'[dbo].[resIngredients1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resIngredients1];
GO
IF OBJECT_ID(N'[dbo].[resMenuItems1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resMenuItems1];
GO
IF OBJECT_ID(N'[dbo].[resOrderHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resOrderHdrs];
GO
IF OBJECT_ID(N'[dbo].[resCustomers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resCustomers];
GO
IF OBJECT_ID(N'[dbo].[resOrderDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resOrderDtls];
GO
IF OBJECT_ID(N'[dbo].[resCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resCategories];
GO
IF OBJECT_ID(N'[dbo].[resMenuCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resMenuCategories];
GO
IF OBJECT_ID(N'[dbo].[resItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resItems];
GO
IF OBJECT_ID(N'[dbo].[scInvOutHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scInvOutHdrs];
GO
IF OBJECT_ID(N'[dbo].[scInvOutDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scInvOutDtls];
GO
IF OBJECT_ID(N'[dbo].[resPreparations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resPreparations];
GO
IF OBJECT_ID(N'[dbo].[resPrepMaterials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resPrepMaterials];
GO
IF OBJECT_ID(N'[dbo].[scStoreTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scStoreTypes];
GO
IF OBJECT_ID(N'[dbo].[scCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scCategories];
GO
IF OBJECT_ID(N'[dbo].[scItemCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scItemCategories];
GO
IF OBJECT_ID(N'[dbo].[scPrHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scPrHdrs];
GO
IF OBJECT_ID(N'[dbo].[scPrDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scPrDtls];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'scSuppliers'
CREATE TABLE [dbo].[scSuppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Remarks] nvarchar(250)  NULL
);
GO

-- Creating table 'scItems'
CREATE TABLE [dbo].[scItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [scUomId] int  NOT NULL,
    [Expirydays] int  NULL,
    [LowLevel] int  NULL
);
GO

-- Creating table 'scUoms'
CREATE TABLE [dbo].[scUoms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Unit] nvarchar(10)  NOT NULL,
    [Desc] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'scStorages'
CREATE TABLE [dbo].[scStorages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [scStoreTypeId] int  NOT NULL
);
GO

-- Creating table 'scStoreBins'
CREATE TABLE [dbo].[scStoreBins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scStorageId] int  NOT NULL,
    [Code] nvarchar(80)  NOT NULL,
    [PostedQty] decimal(18,0)  NOT NULL,
    [PostedDate] datetime  NOT NULL,
    [ExpiryDate] datetime  NOT NULL,
    [scItemId] int  NOT NULL,
    [BinStatus] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'scItemSuppliers'
CREATE TABLE [dbo].[scItemSuppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scItemId] int  NOT NULL,
    [scSupplierId] int  NOT NULL,
    [Leadtime] int  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [scUomId] int  NOT NULL
);
GO

-- Creating table 'scRcvHdrs'
CREATE TABLE [dbo].[scRcvHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtRcv] datetime  NOT NULL,
    [scSupplierId] int  NOT NULL,
    [Remarks] nvarchar(150)  NULL
);
GO

-- Creating table 'scRcvDtls'
CREATE TABLE [dbo].[scRcvDtls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scRcvHdrId] int  NOT NULL,
    [scItemId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [scStoreBinId] int  NOT NULL,
    [scPoDtlId] int  NULL
);
GO

-- Creating table 'scPoHdrs'
CREATE TABLE [dbo].[scPoHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtPo] datetime  NOT NULL,
    [scSupplierId] int  NOT NULL,
    [Remarks] nvarchar(150)  NULL
);
GO

-- Creating table 'scPoDtls'
CREATE TABLE [dbo].[scPoDtls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scPoHdrId] int  NOT NULL,
    [scItemId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [scUomId] int  NOT NULL,
    [scPrDtlId] int  NULL
);
GO

-- Creating table 'resMenus'
CREATE TABLE [dbo].[resMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [Price] decimal(18,0)  NOT NULL,
    [barcode] nvarchar(max)  NULL
);
GO

-- Creating table 'resRecipes'
CREATE TABLE [dbo].[resRecipes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Duration] int  NOT NULL,
    [NoOfServing] int  NOT NULL
);
GO

-- Creating table 'resIngredients1'
CREATE TABLE [dbo].[resIngredients1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resRecipeId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [scItemId] int  NOT NULL
);
GO

-- Creating table 'resMenuItems1'
CREATE TABLE [dbo].[resMenuItems1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resMenuId] int  NOT NULL,
    [resRecipeId] int  NOT NULL,
    [ServingRequired] int  NOT NULL
);
GO

-- Creating table 'resOrderHdrs'
CREATE TABLE [dbo].[resOrderHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resCustomerId] int  NOT NULL,
    [dtOrder] datetime  NOT NULL,
    [dtDelivery] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(250)  NULL
);
GO

-- Creating table 'resCustomers'
CREATE TABLE [dbo].[resCustomers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Remarks] nvarchar(150)  NULL,
    [TelNo] nvarchar(150)  NULL,
    [Address] nvarchar(150)  NULL
);
GO

-- Creating table 'resOrderDtls'
CREATE TABLE [dbo].[resOrderDtls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resOrderHdrId] int  NOT NULL,
    [resMenuId] int  NULL,
    [resItemId] int  NULL,
    [Qty] int  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'resCategories'
CREATE TABLE [dbo].[resCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CatName] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'resMenuCategories'
CREATE TABLE [dbo].[resMenuCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resCategoryId] int  NOT NULL,
    [resMenuId] int  NOT NULL
);
GO

-- Creating table 'resItems'
CREATE TABLE [dbo].[resItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scItemId] int  NOT NULL,
    [Description] nvarchar(250)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [barcode] nvarchar(80)  NULL,
    [resQty] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'scInvOutHdrs'
CREATE TABLE [dbo].[scInvOutHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtOut] datetime  NOT NULL,
    [Remarks] nvarchar(80)  NULL
);
GO

-- Creating table 'scInvOutDtls'
CREATE TABLE [dbo].[scInvOutDtls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scInvOutHdrId] int  NOT NULL,
    [scItemId] int  NOT NULL,
    [scStoreBinId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [resOrderDtlId] int  NULL
);
GO

-- Creating table 'resPreparations'
CREATE TABLE [dbo].[resPreparations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtPrepared] nvarchar(max)  NOT NULL,
    [resRecipeId] int  NULL,
    [resQty] decimal(18,0)  NOT NULL,
    [itemQty] decimal(18,0)  NOT NULL,
    [scItemId] int  NOT NULL,
    [scStoreBinId] int  NOT NULL
);
GO

-- Creating table 'resPrepMaterials'
CREATE TABLE [dbo].[resPrepMaterials] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [resPreparationId] int  NOT NULL,
    [scItemId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [scStoreBinId] int  NOT NULL
);
GO

-- Creating table 'scStoreTypes'
CREATE TABLE [dbo].[scStoreTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'scCategories'
CREATE TABLE [dbo].[scCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'scItemCategories'
CREATE TABLE [dbo].[scItemCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scCategoryId] int  NOT NULL,
    [scItemId] int  NOT NULL
);
GO

-- Creating table 'scPrHdrs'
CREATE TABLE [dbo].[scPrHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtPr] datetime  NOT NULL,
    [Remarks] nvarchar(250)  NULL,
    [Status] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'scPrDtls'
CREATE TABLE [dbo].[scPrDtls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [scPrHdrId] int  NOT NULL,
    [scItemId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [scUomId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'scSuppliers'
ALTER TABLE [dbo].[scSuppliers]
ADD CONSTRAINT [PK_scSuppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scItems'
ALTER TABLE [dbo].[scItems]
ADD CONSTRAINT [PK_scItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scUoms'
ALTER TABLE [dbo].[scUoms]
ADD CONSTRAINT [PK_scUoms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scStorages'
ALTER TABLE [dbo].[scStorages]
ADD CONSTRAINT [PK_scStorages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scStoreBins'
ALTER TABLE [dbo].[scStoreBins]
ADD CONSTRAINT [PK_scStoreBins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scItemSuppliers'
ALTER TABLE [dbo].[scItemSuppliers]
ADD CONSTRAINT [PK_scItemSuppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scRcvHdrs'
ALTER TABLE [dbo].[scRcvHdrs]
ADD CONSTRAINT [PK_scRcvHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scRcvDtls'
ALTER TABLE [dbo].[scRcvDtls]
ADD CONSTRAINT [PK_scRcvDtls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scPoHdrs'
ALTER TABLE [dbo].[scPoHdrs]
ADD CONSTRAINT [PK_scPoHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scPoDtls'
ALTER TABLE [dbo].[scPoDtls]
ADD CONSTRAINT [PK_scPoDtls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resMenus'
ALTER TABLE [dbo].[resMenus]
ADD CONSTRAINT [PK_resMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resRecipes'
ALTER TABLE [dbo].[resRecipes]
ADD CONSTRAINT [PK_resRecipes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resIngredients1'
ALTER TABLE [dbo].[resIngredients1]
ADD CONSTRAINT [PK_resIngredients1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resMenuItems1'
ALTER TABLE [dbo].[resMenuItems1]
ADD CONSTRAINT [PK_resMenuItems1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resOrderHdrs'
ALTER TABLE [dbo].[resOrderHdrs]
ADD CONSTRAINT [PK_resOrderHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resCustomers'
ALTER TABLE [dbo].[resCustomers]
ADD CONSTRAINT [PK_resCustomers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resOrderDtls'
ALTER TABLE [dbo].[resOrderDtls]
ADD CONSTRAINT [PK_resOrderDtls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resCategories'
ALTER TABLE [dbo].[resCategories]
ADD CONSTRAINT [PK_resCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resMenuCategories'
ALTER TABLE [dbo].[resMenuCategories]
ADD CONSTRAINT [PK_resMenuCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resItems'
ALTER TABLE [dbo].[resItems]
ADD CONSTRAINT [PK_resItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scInvOutHdrs'
ALTER TABLE [dbo].[scInvOutHdrs]
ADD CONSTRAINT [PK_scInvOutHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scInvOutDtls'
ALTER TABLE [dbo].[scInvOutDtls]
ADD CONSTRAINT [PK_scInvOutDtls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resPreparations'
ALTER TABLE [dbo].[resPreparations]
ADD CONSTRAINT [PK_resPreparations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resPrepMaterials'
ALTER TABLE [dbo].[resPrepMaterials]
ADD CONSTRAINT [PK_resPrepMaterials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scStoreTypes'
ALTER TABLE [dbo].[scStoreTypes]
ADD CONSTRAINT [PK_scStoreTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scCategories'
ALTER TABLE [dbo].[scCategories]
ADD CONSTRAINT [PK_scCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scItemCategories'
ALTER TABLE [dbo].[scItemCategories]
ADD CONSTRAINT [PK_scItemCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scPrHdrs'
ALTER TABLE [dbo].[scPrHdrs]
ADD CONSTRAINT [PK_scPrHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'scPrDtls'
ALTER TABLE [dbo].[scPrDtls]
ADD CONSTRAINT [PK_scPrDtls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [scUomId] in table 'scItems'
ALTER TABLE [dbo].[scItems]
ADD CONSTRAINT [FK_scUomscItem]
    FOREIGN KEY ([scUomId])
    REFERENCES [dbo].[scUoms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scUomscItem'
CREATE INDEX [IX_FK_scUomscItem]
ON [dbo].[scItems]
    ([scUomId]);
GO

-- Creating foreign key on [scStorageId] in table 'scStoreBins'
ALTER TABLE [dbo].[scStoreBins]
ADD CONSTRAINT [FK_scStoragescStoreBin]
    FOREIGN KEY ([scStorageId])
    REFERENCES [dbo].[scStorages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoragescStoreBin'
CREATE INDEX [IX_FK_scStoragescStoreBin]
ON [dbo].[scStoreBins]
    ([scStorageId]);
GO

-- Creating foreign key on [scItemId] in table 'scItemSuppliers'
ALTER TABLE [dbo].[scItemSuppliers]
ADD CONSTRAINT [FK_scItemscItemSupplier]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscItemSupplier'
CREATE INDEX [IX_FK_scItemscItemSupplier]
ON [dbo].[scItemSuppliers]
    ([scItemId]);
GO

-- Creating foreign key on [scSupplierId] in table 'scItemSuppliers'
ALTER TABLE [dbo].[scItemSuppliers]
ADD CONSTRAINT [FK_scSupplierscItemSupplier]
    FOREIGN KEY ([scSupplierId])
    REFERENCES [dbo].[scSuppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scSupplierscItemSupplier'
CREATE INDEX [IX_FK_scSupplierscItemSupplier]
ON [dbo].[scItemSuppliers]
    ([scSupplierId]);
GO

-- Creating foreign key on [scRcvHdrId] in table 'scRcvDtls'
ALTER TABLE [dbo].[scRcvDtls]
ADD CONSTRAINT [FK_scRcvHdrscRcvDtl]
    FOREIGN KEY ([scRcvHdrId])
    REFERENCES [dbo].[scRcvHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scRcvHdrscRcvDtl'
CREATE INDEX [IX_FK_scRcvHdrscRcvDtl]
ON [dbo].[scRcvDtls]
    ([scRcvHdrId]);
GO

-- Creating foreign key on [scItemId] in table 'scRcvDtls'
ALTER TABLE [dbo].[scRcvDtls]
ADD CONSTRAINT [FK_scItemscRcvDtl]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscRcvDtl'
CREATE INDEX [IX_FK_scItemscRcvDtl]
ON [dbo].[scRcvDtls]
    ([scItemId]);
GO

-- Creating foreign key on [scSupplierId] in table 'scRcvHdrs'
ALTER TABLE [dbo].[scRcvHdrs]
ADD CONSTRAINT [FK_scSupplierscRcvHdr]
    FOREIGN KEY ([scSupplierId])
    REFERENCES [dbo].[scSuppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scSupplierscRcvHdr'
CREATE INDEX [IX_FK_scSupplierscRcvHdr]
ON [dbo].[scRcvHdrs]
    ([scSupplierId]);
GO

-- Creating foreign key on [scStoreBinId] in table 'scRcvDtls'
ALTER TABLE [dbo].[scRcvDtls]
ADD CONSTRAINT [FK_scStoreBinscRcvDtl]
    FOREIGN KEY ([scStoreBinId])
    REFERENCES [dbo].[scStoreBins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoreBinscRcvDtl'
CREATE INDEX [IX_FK_scStoreBinscRcvDtl]
ON [dbo].[scRcvDtls]
    ([scStoreBinId]);
GO

-- Creating foreign key on [scPoHdrId] in table 'scPoDtls'
ALTER TABLE [dbo].[scPoDtls]
ADD CONSTRAINT [FK_scPoHdrscPoDtl]
    FOREIGN KEY ([scPoHdrId])
    REFERENCES [dbo].[scPoHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scPoHdrscPoDtl'
CREATE INDEX [IX_FK_scPoHdrscPoDtl]
ON [dbo].[scPoDtls]
    ([scPoHdrId]);
GO

-- Creating foreign key on [scSupplierId] in table 'scPoHdrs'
ALTER TABLE [dbo].[scPoHdrs]
ADD CONSTRAINT [FK_scSupplierscPoHdr]
    FOREIGN KEY ([scSupplierId])
    REFERENCES [dbo].[scSuppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scSupplierscPoHdr'
CREATE INDEX [IX_FK_scSupplierscPoHdr]
ON [dbo].[scPoHdrs]
    ([scSupplierId]);
GO

-- Creating foreign key on [scItemId] in table 'scPoDtls'
ALTER TABLE [dbo].[scPoDtls]
ADD CONSTRAINT [FK_scItemscPoDtl]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscPoDtl'
CREATE INDEX [IX_FK_scItemscPoDtl]
ON [dbo].[scPoDtls]
    ([scItemId]);
GO

-- Creating foreign key on [scUomId] in table 'scPoDtls'
ALTER TABLE [dbo].[scPoDtls]
ADD CONSTRAINT [FK_scUomscPoDtl]
    FOREIGN KEY ([scUomId])
    REFERENCES [dbo].[scUoms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scUomscPoDtl'
CREATE INDEX [IX_FK_scUomscPoDtl]
ON [dbo].[scPoDtls]
    ([scUomId]);
GO

-- Creating foreign key on [scUomId] in table 'scItemSuppliers'
ALTER TABLE [dbo].[scItemSuppliers]
ADD CONSTRAINT [FK_scUomscItemSupplier]
    FOREIGN KEY ([scUomId])
    REFERENCES [dbo].[scUoms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scUomscItemSupplier'
CREATE INDEX [IX_FK_scUomscItemSupplier]
ON [dbo].[scItemSuppliers]
    ([scUomId]);
GO

-- Creating foreign key on [scPoDtlId] in table 'scRcvDtls'
ALTER TABLE [dbo].[scRcvDtls]
ADD CONSTRAINT [FK_scPoDtlscRcvDtl]
    FOREIGN KEY ([scPoDtlId])
    REFERENCES [dbo].[scPoDtls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scPoDtlscRcvDtl'
CREATE INDEX [IX_FK_scPoDtlscRcvDtl]
ON [dbo].[scRcvDtls]
    ([scPoDtlId]);
GO

-- Creating foreign key on [resRecipeId] in table 'resIngredients1'
ALTER TABLE [dbo].[resIngredients1]
ADD CONSTRAINT [FK_resReciperesIngredients]
    FOREIGN KEY ([resRecipeId])
    REFERENCES [dbo].[resRecipes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resReciperesIngredients'
CREATE INDEX [IX_FK_resReciperesIngredients]
ON [dbo].[resIngredients1]
    ([resRecipeId]);
GO

-- Creating foreign key on [scItemId] in table 'resIngredients1'
ALTER TABLE [dbo].[resIngredients1]
ADD CONSTRAINT [FK_scItemresIngredients]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemresIngredients'
CREATE INDEX [IX_FK_scItemresIngredients]
ON [dbo].[resIngredients1]
    ([scItemId]);
GO

-- Creating foreign key on [resMenuId] in table 'resMenuItems1'
ALTER TABLE [dbo].[resMenuItems1]
ADD CONSTRAINT [FK_resMenuresMenuItems]
    FOREIGN KEY ([resMenuId])
    REFERENCES [dbo].[resMenus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resMenuresMenuItems'
CREATE INDEX [IX_FK_resMenuresMenuItems]
ON [dbo].[resMenuItems1]
    ([resMenuId]);
GO

-- Creating foreign key on [resRecipeId] in table 'resMenuItems1'
ALTER TABLE [dbo].[resMenuItems1]
ADD CONSTRAINT [FK_resReciperesMenuItem]
    FOREIGN KEY ([resRecipeId])
    REFERENCES [dbo].[resRecipes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resReciperesMenuItem'
CREATE INDEX [IX_FK_resReciperesMenuItem]
ON [dbo].[resMenuItems1]
    ([resRecipeId]);
GO

-- Creating foreign key on [resCustomerId] in table 'resOrderHdrs'
ALTER TABLE [dbo].[resOrderHdrs]
ADD CONSTRAINT [FK_resCustomerresOrderHdr]
    FOREIGN KEY ([resCustomerId])
    REFERENCES [dbo].[resCustomers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resCustomerresOrderHdr'
CREATE INDEX [IX_FK_resCustomerresOrderHdr]
ON [dbo].[resOrderHdrs]
    ([resCustomerId]);
GO

-- Creating foreign key on [resOrderHdrId] in table 'resOrderDtls'
ALTER TABLE [dbo].[resOrderDtls]
ADD CONSTRAINT [FK_resOrderHdrresOrderDtl]
    FOREIGN KEY ([resOrderHdrId])
    REFERENCES [dbo].[resOrderHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resOrderHdrresOrderDtl'
CREATE INDEX [IX_FK_resOrderHdrresOrderDtl]
ON [dbo].[resOrderDtls]
    ([resOrderHdrId]);
GO

-- Creating foreign key on [resCategoryId] in table 'resMenuCategories'
ALTER TABLE [dbo].[resMenuCategories]
ADD CONSTRAINT [FK_resCategoryresMenuCategory]
    FOREIGN KEY ([resCategoryId])
    REFERENCES [dbo].[resCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resCategoryresMenuCategory'
CREATE INDEX [IX_FK_resCategoryresMenuCategory]
ON [dbo].[resMenuCategories]
    ([resCategoryId]);
GO

-- Creating foreign key on [resMenuId] in table 'resMenuCategories'
ALTER TABLE [dbo].[resMenuCategories]
ADD CONSTRAINT [FK_resMenuresMenuCategory]
    FOREIGN KEY ([resMenuId])
    REFERENCES [dbo].[resMenus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resMenuresMenuCategory'
CREATE INDEX [IX_FK_resMenuresMenuCategory]
ON [dbo].[resMenuCategories]
    ([resMenuId]);
GO

-- Creating foreign key on [resMenuId] in table 'resOrderDtls'
ALTER TABLE [dbo].[resOrderDtls]
ADD CONSTRAINT [FK_resMenuresOrderDtl]
    FOREIGN KEY ([resMenuId])
    REFERENCES [dbo].[resMenus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resMenuresOrderDtl'
CREATE INDEX [IX_FK_resMenuresOrderDtl]
ON [dbo].[resOrderDtls]
    ([resMenuId]);
GO

-- Creating foreign key on [scItemId] in table 'resItems'
ALTER TABLE [dbo].[resItems]
ADD CONSTRAINT [FK_scItemresItem]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemresItem'
CREATE INDEX [IX_FK_scItemresItem]
ON [dbo].[resItems]
    ([scItemId]);
GO

-- Creating foreign key on [resItemId] in table 'resOrderDtls'
ALTER TABLE [dbo].[resOrderDtls]
ADD CONSTRAINT [FK_resItemresOrderDtl]
    FOREIGN KEY ([resItemId])
    REFERENCES [dbo].[resItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resItemresOrderDtl'
CREATE INDEX [IX_FK_resItemresOrderDtl]
ON [dbo].[resOrderDtls]
    ([resItemId]);
GO

-- Creating foreign key on [scInvOutHdrId] in table 'scInvOutDtls'
ALTER TABLE [dbo].[scInvOutDtls]
ADD CONSTRAINT [FK_scInvOutHdrscInvOutDtl]
    FOREIGN KEY ([scInvOutHdrId])
    REFERENCES [dbo].[scInvOutHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scInvOutHdrscInvOutDtl'
CREATE INDEX [IX_FK_scInvOutHdrscInvOutDtl]
ON [dbo].[scInvOutDtls]
    ([scInvOutHdrId]);
GO

-- Creating foreign key on [scItemId] in table 'scInvOutDtls'
ALTER TABLE [dbo].[scInvOutDtls]
ADD CONSTRAINT [FK_scItemscInvOutDtl]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscInvOutDtl'
CREATE INDEX [IX_FK_scItemscInvOutDtl]
ON [dbo].[scInvOutDtls]
    ([scItemId]);
GO

-- Creating foreign key on [scStoreBinId] in table 'scInvOutDtls'
ALTER TABLE [dbo].[scInvOutDtls]
ADD CONSTRAINT [FK_scStoreBinscInvOutDtl]
    FOREIGN KEY ([scStoreBinId])
    REFERENCES [dbo].[scStoreBins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoreBinscInvOutDtl'
CREATE INDEX [IX_FK_scStoreBinscInvOutDtl]
ON [dbo].[scInvOutDtls]
    ([scStoreBinId]);
GO

-- Creating foreign key on [resOrderDtlId] in table 'scInvOutDtls'
ALTER TABLE [dbo].[scInvOutDtls]
ADD CONSTRAINT [FK_resOrderDtlscInvOutDtl]
    FOREIGN KEY ([resOrderDtlId])
    REFERENCES [dbo].[resOrderDtls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resOrderDtlscInvOutDtl'
CREATE INDEX [IX_FK_resOrderDtlscInvOutDtl]
ON [dbo].[scInvOutDtls]
    ([resOrderDtlId]);
GO

-- Creating foreign key on [resPreparationId] in table 'resPrepMaterials'
ALTER TABLE [dbo].[resPrepMaterials]
ADD CONSTRAINT [FK_resPreparationresPreparationDtl]
    FOREIGN KEY ([resPreparationId])
    REFERENCES [dbo].[resPreparations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resPreparationresPreparationDtl'
CREATE INDEX [IX_FK_resPreparationresPreparationDtl]
ON [dbo].[resPrepMaterials]
    ([resPreparationId]);
GO

-- Creating foreign key on [resRecipeId] in table 'resPreparations'
ALTER TABLE [dbo].[resPreparations]
ADD CONSTRAINT [FK_resReciperesPreparation]
    FOREIGN KEY ([resRecipeId])
    REFERENCES [dbo].[resRecipes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resReciperesPreparation'
CREATE INDEX [IX_FK_resReciperesPreparation]
ON [dbo].[resPreparations]
    ([resRecipeId]);
GO

-- Creating foreign key on [scItemId] in table 'resPrepMaterials'
ALTER TABLE [dbo].[resPrepMaterials]
ADD CONSTRAINT [FK_scItemresPreparationDtl]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemresPreparationDtl'
CREATE INDEX [IX_FK_scItemresPreparationDtl]
ON [dbo].[resPrepMaterials]
    ([scItemId]);
GO

-- Creating foreign key on [scStoreBinId] in table 'resPrepMaterials'
ALTER TABLE [dbo].[resPrepMaterials]
ADD CONSTRAINT [FK_scStoreBinresPreparationDtl]
    FOREIGN KEY ([scStoreBinId])
    REFERENCES [dbo].[scStoreBins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoreBinresPreparationDtl'
CREATE INDEX [IX_FK_scStoreBinresPreparationDtl]
ON [dbo].[resPrepMaterials]
    ([scStoreBinId]);
GO

-- Creating foreign key on [scItemId] in table 'resPreparations'
ALTER TABLE [dbo].[resPreparations]
ADD CONSTRAINT [FK_scItemresPreparation]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemresPreparation'
CREATE INDEX [IX_FK_scItemresPreparation]
ON [dbo].[resPreparations]
    ([scItemId]);
GO

-- Creating foreign key on [scStoreBinId] in table 'resPreparations'
ALTER TABLE [dbo].[resPreparations]
ADD CONSTRAINT [FK_scStoreBinresPreparation]
    FOREIGN KEY ([scStoreBinId])
    REFERENCES [dbo].[scStoreBins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoreBinresPreparation'
CREATE INDEX [IX_FK_scStoreBinresPreparation]
ON [dbo].[resPreparations]
    ([scStoreBinId]);
GO

-- Creating foreign key on [scItemId] in table 'scStoreBins'
ALTER TABLE [dbo].[scStoreBins]
ADD CONSTRAINT [FK_scItemscStoreBin]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscStoreBin'
CREATE INDEX [IX_FK_scItemscStoreBin]
ON [dbo].[scStoreBins]
    ([scItemId]);
GO

-- Creating foreign key on [scStoreTypeId] in table 'scStorages'
ALTER TABLE [dbo].[scStorages]
ADD CONSTRAINT [FK_scStoreTypescStorage]
    FOREIGN KEY ([scStoreTypeId])
    REFERENCES [dbo].[scStoreTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scStoreTypescStorage'
CREATE INDEX [IX_FK_scStoreTypescStorage]
ON [dbo].[scStorages]
    ([scStoreTypeId]);
GO

-- Creating foreign key on [scCategoryId] in table 'scItemCategories'
ALTER TABLE [dbo].[scItemCategories]
ADD CONSTRAINT [FK_scCategoryscItemCategory]
    FOREIGN KEY ([scCategoryId])
    REFERENCES [dbo].[scCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scCategoryscItemCategory'
CREATE INDEX [IX_FK_scCategoryscItemCategory]
ON [dbo].[scItemCategories]
    ([scCategoryId]);
GO

-- Creating foreign key on [scItemId] in table 'scItemCategories'
ALTER TABLE [dbo].[scItemCategories]
ADD CONSTRAINT [FK_scItemscItemCategory]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscItemCategory'
CREATE INDEX [IX_FK_scItemscItemCategory]
ON [dbo].[scItemCategories]
    ([scItemId]);
GO

-- Creating foreign key on [scPrHdrId] in table 'scPrDtls'
ALTER TABLE [dbo].[scPrDtls]
ADD CONSTRAINT [FK_scPrHdrscPrDtl]
    FOREIGN KEY ([scPrHdrId])
    REFERENCES [dbo].[scPrHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scPrHdrscPrDtl'
CREATE INDEX [IX_FK_scPrHdrscPrDtl]
ON [dbo].[scPrDtls]
    ([scPrHdrId]);
GO

-- Creating foreign key on [scItemId] in table 'scPrDtls'
ALTER TABLE [dbo].[scPrDtls]
ADD CONSTRAINT [FK_scItemscPrDtl]
    FOREIGN KEY ([scItemId])
    REFERENCES [dbo].[scItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scItemscPrDtl'
CREATE INDEX [IX_FK_scItemscPrDtl]
ON [dbo].[scPrDtls]
    ([scItemId]);
GO

-- Creating foreign key on [scUomId] in table 'scPrDtls'
ALTER TABLE [dbo].[scPrDtls]
ADD CONSTRAINT [FK_scUomscPrDtl]
    FOREIGN KEY ([scUomId])
    REFERENCES [dbo].[scUoms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scUomscPrDtl'
CREATE INDEX [IX_FK_scUomscPrDtl]
ON [dbo].[scPrDtls]
    ([scUomId]);
GO

-- Creating foreign key on [scPrDtlId] in table 'scPoDtls'
ALTER TABLE [dbo].[scPoDtls]
ADD CONSTRAINT [FK_scPrDtlscPoDtl]
    FOREIGN KEY ([scPrDtlId])
    REFERENCES [dbo].[scPrDtls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_scPrDtlscPoDtl'
CREATE INDEX [IX_FK_scPrDtlscPoDtl]
ON [dbo].[scPoDtls]
    ([scPrDtlId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------