CREATE TABLE [dbo].[Atractions] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Type]     NVARCHAR (MAX) NULL,
    [Capacity] INT            NOT NULL,
    [Price]    INT            NOT NULL,
    [ZoneId]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.Atractions] PRIMARY KEY CLUSTERED ([Id] ASC),
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[Atractions]([ZoneId] ASC);

