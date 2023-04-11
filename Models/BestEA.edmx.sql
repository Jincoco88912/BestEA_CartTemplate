
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/12/2023 02:21:13
-- Generated from EDMX file: D:\Driver\我的專案\BestEA 貝斯提亞\BestEA\Models\BestEA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BestEA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cart_Member_Email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_Member_Email];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_Order_OG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_Order_OG];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_Product_PID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_Product_PID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admin];
GO
IF OBJECT_ID(N'[dbo].[Cart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cart];
GO
IF OBJECT_ID(N'[dbo].[Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Member];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admin'
CREATE TABLE [dbo].[Admin] (
    [AdminID] nvarchar(100)  NOT NULL,
    [Pwd] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Cart'
CREATE TABLE [dbo].[Cart] (
    [cid] int IDENTITY(1,1) NOT NULL,
    [OrderGuid] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NOT NULL,
    [PID] nvarchar(50)  NOT NULL,
    [PPrice] decimal(20,0)  NOT NULL,
    [Amont] int  NOT NULL,
    [Sure] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Member'
CREATE TABLE [dbo].[Member] (
    [Email] nvarchar(100)  NOT NULL,
    [Pwd] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Enable] int  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [OrderGuid] nvarchar(100)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [Total] decimal(20,0)  NOT NULL,
    [OConfirm] int  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [PID] nvarchar(50)  NOT NULL,
    [PName] nvarchar(50)  NOT NULL,
    [PPrice] decimal(20,0)  NOT NULL,
    [Pair] nvarchar(50)  NULL,
    [DateRange] nvarchar(50)  NULL,
    [Lever] nvarchar(20)  NULL,
    [Position] nvarchar(30)  NULL,
    [IRR] decimal(20,2)  NULL,
    [ProductImg] nvarchar(80)  NOT NULL,
    [Categories] nvarchar(30)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdminID] in table 'Admin'
ALTER TABLE [dbo].[Admin]
ADD CONSTRAINT [PK_Admin]
    PRIMARY KEY CLUSTERED ([AdminID] ASC);
GO

-- Creating primary key on [cid] in table 'Cart'
ALTER TABLE [dbo].[Cart]
ADD CONSTRAINT [PK_Cart]
    PRIMARY KEY CLUSTERED ([cid] ASC);
GO

-- Creating primary key on [Email] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [PK_Member]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [OrderGuid] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([OrderGuid] ASC);
GO

-- Creating primary key on [PID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([PID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Email] in table 'Cart'
ALTER TABLE [dbo].[Cart]
ADD CONSTRAINT [FK_Cart_Member_Email]
    FOREIGN KEY ([Email])
    REFERENCES [dbo].[Member]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_Member_Email'
CREATE INDEX [IX_FK_Cart_Member_Email]
ON [dbo].[Cart]
    ([Email]);
GO

-- Creating foreign key on [OrderGuid] in table 'Cart'
ALTER TABLE [dbo].[Cart]
ADD CONSTRAINT [FK_Cart_Order_OG]
    FOREIGN KEY ([OrderGuid])
    REFERENCES [dbo].[Order]
        ([OrderGuid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_Order_OG'
CREATE INDEX [IX_FK_Cart_Order_OG]
ON [dbo].[Cart]
    ([OrderGuid]);
GO

-- Creating foreign key on [PID] in table 'Cart'
ALTER TABLE [dbo].[Cart]
ADD CONSTRAINT [FK_Cart_Product_PID]
    FOREIGN KEY ([PID])
    REFERENCES [dbo].[Product]
        ([PID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_Product_PID'
CREATE INDEX [IX_FK_Cart_Product_PID]
ON [dbo].[Cart]
    ([PID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------