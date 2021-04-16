CREATE TABLE [dbo].[Menu] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [MenuName]     VARCHAR (255)  NOT NULL,
    [MenuLevel]    INT            DEFAULT ((0)) NOT NULL,
    [MenuOrder]    INT            DEFAULT ((0)) NOT NULL,
    [MenuParentId] INT            NULL,
    [MenuLink]     VARCHAR (1024) NULL,
    [MenuActive]   BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MenuParentId]) REFERENCES [dbo].[Menu] ([Id])
);

