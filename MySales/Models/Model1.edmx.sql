
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2019 11:51:32
-- Generated from EDMX file: E:\Ahsan_rabby_mysale\02-03-2019_march\OOKK_19_2_19_26_feb_updated\OOKK_19_2_19_test\MySales\MySales\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OnlineShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Order__ActivityI__0697FACD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__ActivityI__0697FACD];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__ActivityI__7908F585]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__ActivityI__7908F585];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__StateID__79FD19BE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__StateID__79FD19BE];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__UserId__42ACE4D4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__UserId__42ACE4D4];
GO
IF OBJECT_ID(N'[dbo].[FK__Party__UserId__73852659]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Party] DROP CONSTRAINT [FK__Party__UserId__73852659];
GO
IF OBJECT_ID(N'[dbo].[FK__SubActivi__Activ__3FD07829]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubActivity] DROP CONSTRAINT [FK__SubActivi__Activ__3FD07829];
GO
IF OBJECT_ID(N'[dbo].[FK__UserRole__Userid__25DB9BFC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK__UserRole__Userid__25DB9BFC];
GO
IF OBJECT_ID(N'[dbo].[fk_Order_Criteria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [fk_Order_Criteria];
GO
IF OBJECT_ID(N'[dbo].[fk_Order_tblBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [fk_Order_tblBrand];
GO
IF OBJECT_ID(N'[dbo].[fk_Order_tblCustomers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [fk_Order_tblCustomers];
GO
IF OBJECT_ID(N'[dbo].[fk_OrderDetail_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [fk_OrderDetail_Order];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity];
GO
IF OBJECT_ID(N'[dbo].[Criteria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Criteria];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetail];
GO
IF OBJECT_ID(N'[dbo].[Party]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Party];
GO
IF OBJECT_ID(N'[dbo].[SubActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubActivity];
GO
IF OBJECT_ID(N'[dbo].[tblBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBrand];
GO
IF OBJECT_ID(N'[dbo].[tblCustomers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomers];
GO
IF OBJECT_ID(N'[dbo].[UserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfile];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [ActivityId] int  NOT NULL,
    [ActivityName] varchar(100)  NOT NULL
);
GO

-- Creating table 'Criteria1'
CREATE TABLE [dbo].[Criteria1] (
    [CriteriaID] int IDENTITY(1,1) NOT NULL,
    [CriteriaDescription] varchar(50)  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [OrderItemsId] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NOT NULL,
    [Description] varchar(150)  NOT NULL,
    [Unit] varchar(150)  NOT NULL,
    [Rate] decimal(18,2)  NULL,
    [Qty] decimal(18,2)  NULL,
    [Amt] decimal(18,2)  NULL,
    [vat] int  NULL,
    [SubTotal] decimal(33,6)  NULL,
    [Totals] decimal(34,6)  NULL
);
GO

-- Creating table 'Parties'
CREATE TABLE [dbo].[Parties] (
    [pid] int IDENTITY(1,1) NOT NULL,
    [pname] varchar(50)  NOT NULL,
    [paddress] varchar(max)  NOT NULL,
    [pphone] nvarchar(max)  NOT NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'SubActivities'
CREATE TABLE [dbo].[SubActivities] (
    [StateID] int  NOT NULL,
    [StateName] varchar(100)  NOT NULL,
    [ActivityId] int  NULL
);
GO

-- Creating table 'tblBrands'
CREATE TABLE [dbo].[tblBrands] (
    [BrandID] int IDENTITY(1,1) NOT NULL,
    [BrandDescription] varchar(50)  NULL
);
GO

-- Creating table 'tblCustomers'
CREATE TABLE [dbo].[tblCustomers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [CustomerName] varchar(200)  NULL,
    [Address] varchar(max)  NULL,
    [Phone] varchar(200)  NULL,
    [DirectPayment] varchar(200)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(150)  NOT NULL,
    [CustomerId] int  NOT NULL,
    [BrandID] int  NOT NULL,
    [workOrderNo] int  NOT NULL,
    [CriteriaID] int  NOT NULL,
    [OrderDate] datetime  NULL,
    [DeliveryDate] datetime  NULL,
    [Place] varchar(50)  NULL,
    [Heading] varchar(50)  NULL,
    [ActivityId] int  NULL,
    [StateID] int  NULL,
    [UserId] int  NULL,
    [Wotype] int  NULL,
    [advance] varchar(50)  NULL,
    [billsubmission] varchar(50)  NULL,
    [warrenty] varchar(50)  NULL,
    [cancel] varchar(50)  NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Userid] int  NOT NULL,
    [Role] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ActivityId] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([ActivityId] ASC);
GO

-- Creating primary key on [CriteriaID] in table 'Criteria1'
ALTER TABLE [dbo].[Criteria1]
ADD CONSTRAINT [PK_Criteria1]
    PRIMARY KEY CLUSTERED ([CriteriaID] ASC);
GO

-- Creating primary key on [OrderItemsId] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([OrderItemsId] ASC);
GO

-- Creating primary key on [pid] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [PK_Parties]
    PRIMARY KEY CLUSTERED ([pid] ASC);
GO

-- Creating primary key on [StateID] in table 'SubActivities'
ALTER TABLE [dbo].[SubActivities]
ADD CONSTRAINT [PK_SubActivities]
    PRIMARY KEY CLUSTERED ([StateID] ASC);
GO

-- Creating primary key on [BrandID] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [PK_tblBrands]
    PRIMARY KEY CLUSTERED ([BrandID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'tblCustomers'
ALTER TABLE [dbo].[tblCustomers]
ADD CONSTRAINT [PK_tblCustomers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityId] in table 'SubActivities'
ALTER TABLE [dbo].[SubActivities]
ADD CONSTRAINT [FK__SubActivi__Activ__3FD07829]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([ActivityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SubActivi__Activ__3FD07829'
CREATE INDEX [IX_FK__SubActivi__Activ__3FD07829]
ON [dbo].[SubActivities]
    ([ActivityId]);
GO

-- Creating foreign key on [ActivityId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__ActivityI__0697FACD]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([ActivityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__ActivityI__0697FACD'
CREATE INDEX [IX_FK__Order__ActivityI__0697FACD]
ON [dbo].[Orders]
    ([ActivityId]);
GO

-- Creating foreign key on [ActivityId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__ActivityI__7908F585]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([ActivityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__ActivityI__7908F585'
CREATE INDEX [IX_FK__Order__ActivityI__7908F585]
ON [dbo].[Orders]
    ([ActivityId]);
GO

-- Creating foreign key on [CriteriaID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [fk_Order_Criteria]
    FOREIGN KEY ([CriteriaID])
    REFERENCES [dbo].[Criteria1]
        ([CriteriaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Order_Criteria'
CREATE INDEX [IX_fk_Order_Criteria]
ON [dbo].[Orders]
    ([CriteriaID]);
GO

-- Creating foreign key on [StateID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__StateID__79FD19BE]
    FOREIGN KEY ([StateID])
    REFERENCES [dbo].[SubActivities]
        ([StateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__StateID__79FD19BE'
CREATE INDEX [IX_FK__Order__StateID__79FD19BE]
ON [dbo].[Orders]
    ([StateID]);
GO

-- Creating foreign key on [BrandID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [fk_Order_tblBrand]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[tblBrands]
        ([BrandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Order_tblBrand'
CREATE INDEX [IX_fk_Order_tblBrand]
ON [dbo].[Orders]
    ([BrandID]);
GO

-- Creating foreign key on [CustomerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [fk_Order_tblCustomers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[tblCustomers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Order_tblCustomers'
CREATE INDEX [IX_fk_Order_tblCustomers]
ON [dbo].[Orders]
    ([CustomerId]);
GO

-- Creating foreign key on [OrderID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [fk_OrderDetail_Order]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_OrderDetail_Order'
CREATE INDEX [IX_fk_OrderDetail_Order]
ON [dbo].[OrderDetails]
    ([OrderID]);
GO

-- Creating foreign key on [UserId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__UserId__42ACE4D4]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserProfiles]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__UserId__42ACE4D4'
CREATE INDEX [IX_FK__Order__UserId__42ACE4D4]
ON [dbo].[Orders]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [FK__Party__UserId__73852659]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserProfiles]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Party__UserId__73852659'
CREATE INDEX [IX_FK__Party__UserId__73852659]
ON [dbo].[Parties]
    ([UserId]);
GO

-- Creating foreign key on [Userid] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK__UserRole__Userid__25DB9BFC]
    FOREIGN KEY ([Userid])
    REFERENCES [dbo].[UserProfiles]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRole__Userid__25DB9BFC'
CREATE INDEX [IX_FK__UserRole__Userid__25DB9BFC]
ON [dbo].[UserRoles]
    ([Userid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------