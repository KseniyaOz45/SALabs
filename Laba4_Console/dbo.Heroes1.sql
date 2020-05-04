CREATE TABLE [dbo].[Heroes] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NULL,
    [Price]   INT            NOT NULL,
    [OrderId] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Heroes] PRIMARY KEY CLUSTERED ([Id]), 
    CONSTRAINT [FK_Heroes_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
);

