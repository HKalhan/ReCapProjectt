use RentalCarDb;

CREATE TABLE [dbo].[Brands] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] VARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[CarImages] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [CarId]        INT           NULL,
    [ImagePath]    VARCHAR (MAX) NULL,
    [CarImageDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);


CREATE TABLE [dbo].[Cars] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
    [ModelYear]    INT           NULL,
    [DailyPrice]   DECIMAL (18)  NULL,
    [Descriptions] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id])
);


CREATE TABLE [dbo].[Colors] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Customers] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT           NULL,
    [CompanyName] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([Id])
);


CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Users] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (50) NOT NULL,
    [PasswordHash]  BINARY(500) NOT NULL,
    [PasswordSalt] BINARY(500) NOT NULL, 
    [Status] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);






