CREATE TABLE [dbo].[Orders] (
    [Id]    INT            NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Type]  NVARCHAR (MAX) NOT NULL,
    [Price] INT            NOT NULL,
    [Time]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Orders_dbo.Heroes_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Heroes] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].[Orders]([Id] ASC);

