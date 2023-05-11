CREATE TABLE dbo.[Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [Description] varchar(5000) NOT NULL,
    [ShortDescription] varchar(250) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
CREATE TABLE dbo.[Companies] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [DocId] varchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Description] varchar(5000) NOT NULL,
    [PhoneNumber] varchar(15) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);
CREATE TABLE dbo.[Customers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [DocId] varchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Description] varchar(5000) NOT NULL,
    [PhoneNumber] varchar(15) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
CREATE TABLE dbo.[Taxs] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [Description] varchar(5000) NOT NULL,
    [Percentage] DECIMAL NOT NULL,
    [IdCategory] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Taxs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Taxs_Categories_IdCategory] FOREIGN KEY ([IdCategory]) REFERENCES dbo.[Categories] ([Id])
);
CREATE TABLE dbo.[CategoriesAdresss] (
    [Id] uniqueidentifier NOT NULL,
    [IdCompany] uniqueidentifier NOT NULL,
    [CompanyId1] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    [Street] varchar(250) NOT NULL,
    [Number] varchar(5) NOT NULL,
    [Complement] varchar(250) NOT NULL,
    [Neighborhood] varchar(250) NOT NULL,
    [District] varchar(250) NOT NULL,
    [City] varchar(250) NOT NULL,
    [County] varchar(250) NOT NULL,
    [ZipCode] varchar(250) NOT NULL,
    [Latitude] varchar(250) NOT NULL,
    [Longitude] varchar(250) NOT NULL,
    CONSTRAINT [PK_CategoriesAdresss] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CategoriesAdresss_Companies_CompanyId1] FOREIGN KEY ([CompanyId1]) REFERENCES dbo.[Companies] ([Id]),
    CONSTRAINT [FK_CategoriesAdresss_Companies_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES dbo.[Companies] ([Id])
);
CREATE TABLE dbo.[Products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] varchar(5000) NOT NULL,
    [ShortDescription] varchar(250) NOT NULL,
    [Price] DECIMAL NOT NULL,
    [Weight] DECIMAL NOT NULL,
    [Height] DECIMAL NOT NULL,
    [Length] DECIMAL NOT NULL,
    [Quantity] INT NOT NULL,
    [Image] varchar(5000) NOT NULL,
    [IdCategory] uniqueidentifier NOT NULL,
    [IdCompany] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES dbo.[Categories] ([Id]),
    CONSTRAINT [FK_Products_Categories_IdCategory] FOREIGN KEY ([IdCategory]) REFERENCES dbo.[Categories] ([Id]),
    CONSTRAINT [FK_Products_Companies_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES dbo.[Companies] ([Id])
);
CREATE TABLE dbo.[CustomerAdress] (
    [Id] uniqueidentifier NOT NULL,
    [IdCustomer] uniqueidentifier NOT NULL,
    [CustomerId1] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    [Street] varchar(250) NOT NULL,
    [Number] varchar(5) NOT NULL,
    [Complement] varchar(250) NOT NULL,
    [Neighborhood] varchar(250) NOT NULL,
    [District] varchar(250) NOT NULL,
    [City] varchar(250) NOT NULL,
    [County] varchar(250) NOT NULL,
    [ZipCode] varchar(250) NOT NULL,
    [Latitude] varchar(250) NOT NULL,
    [Longitude] varchar(250) NOT NULL,
    CONSTRAINT [PK_CustomerAdress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CustomerAdress_Customers_CustomerId1] FOREIGN KEY ([CustomerId1]) REFERENCES dbo.[Customers] ([Id]),
    CONSTRAINT [FK_CustomerAdress_Customers_IdCustomer] FOREIGN KEY ([IdCustomer]) REFERENCES dbo.[Customers] ([Id])
);
CREATE TABLE dbo.[Sales] (
    [Id] uniqueidentifier NOT NULL,
    [Quantity] INT NOT NULL,
    [TotalPrice] DECIMAL NOT NULL,
    [TotalTax] DECIMAL NOT NULL,
    [SaleType] INT NOT NULL,
    [PaymentType] INT NOT NULL,
    [DeliveryDate] datetime2 NULL,
    [SaleDate] datetime2 NOT NULL,
    [PaymentDate] datetime2 NULL,
    [IdCustomer] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sales_Customers_IdCustomer] FOREIGN KEY ([IdCustomer]) REFERENCES dbo.[Customers] ([Id])
);
CREATE TABLE dbo.[inventories] (
    [Id] uniqueidentifier NOT NULL,
    [Quantity] INT NOT NULL,
    [DateOrder] datetime2 NOT NULL,
    [IdProduct] uniqueidentifier NOT NULL,
    [ProductId1] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_inventories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_inventories_Products_IdProduct] FOREIGN KEY ([IdProduct]) REFERENCES dbo.[Products] ([Id]),
    CONSTRAINT [FK_inventories_Products_ProductId1] FOREIGN KEY ([ProductId1]) REFERENCES dbo.[Products] ([Id])
);
CREATE TABLE dbo.[SaleProduct] (
    [Id] uniqueidentifier NOT NULL,
    [IdProduct] uniqueidentifier NOT NULL,
    [IdSale] uniqueidentifier NOT NULL,
    [SaleId1] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_SaleProduct] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SaleProduct_Products_IdProduct] FOREIGN KEY ([IdProduct]) REFERENCES dbo.[Products] ([Id]),
    CONSTRAINT [FK_SaleProduct_Sales_IdSale] FOREIGN KEY ([IdSale]) REFERENCES dbo.[Sales] ([Id]),
    CONSTRAINT [FK_SaleProduct_Sales_SaleId1] FOREIGN KEY ([SaleId1]) REFERENCES dbo.[Sales] ([Id])
);
CREATE INDEX [IX_CategoriesAdresss_CompanyId1] ON dbo.[CategoriesAdresss] ([CompanyId1]);
CREATE INDEX [IX_CategoriesAdresss_IdCompany] ON dbo.[CategoriesAdresss] ([IdCompany]);
CREATE INDEX [IX_CustomerAdress_CustomerId1] ON dbo.[CustomerAdress] ([CustomerId1]);
CREATE INDEX [IX_CustomerAdress_IdCustomer] ON dbo.[CustomerAdress] ([IdCustomer]);
CREATE INDEX [IX_inventories_IdProduct] ON dbo.[inventories] ([IdProduct]);
CREATE INDEX [IX_inventories_ProductId1] ON dbo.[inventories] ([ProductId1]);
CREATE INDEX [IX_Products_CategoryId] ON dbo.[Products] ([CategoryId]);
CREATE INDEX [IX_Products_IdCategory] ON dbo.[Products] ([IdCategory]);
CREATE INDEX [IX_Products_IdCompany] ON dbo.[Products] ([IdCompany]);
CREATE INDEX [IX_SaleProduct_IdProduct] ON dbo.[SaleProduct] ([IdProduct]);
CREATE INDEX [IX_SaleProduct_IdSale] ON dbo.[SaleProduct] ([IdSale]);
CREATE INDEX [IX_SaleProduct_SaleId1] ON dbo.[SaleProduct] ([SaleId1]);
CREATE INDEX [IX_Sales_IdCustomer] ON dbo.[Sales] ([IdCustomer]);
CREATE INDEX [IX_Taxs_IdCategory] ON dbo.[Taxs] ([IdCategory]);