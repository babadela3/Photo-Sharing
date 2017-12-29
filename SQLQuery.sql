CREATE TABLE [dbo].[Users] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Email]    NCHAR (50) NOT NULL,
    [Password] NCHAR (50) NOT NULL,
    [Name]     NCHAR (50) NOT NULL,
    [City]     NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

