CREATE TABLE [dbo].[Children] (
    [Id]        NVARCHAR (10)   NOT NULL,
    [FirstName] NVARCHAR (20)   NOT NULL,
    [LastName]  NVARCHAR (20)   NOT NULL,
    [Phone]     NVARCHAR (10)   NOT NULL,
    [Challenge]     NVARCHAR (100)   NOT NULL,
    [BirthDate] DATETIME        NOT NULL,
    [Image] IMAGE NULL,
    [AddressID] INT             NOT NULL,
    [Comments]  NVARCHAR (4000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT IDENTITY(1,1) PRIMARY KEY,
    [Email] NVARCHAR (255)   NOT NULL,
    [Password]  NVARCHAR (50)   NOT NULL,
    [Type]     NVARCHAR (500)   NOT NULL,
    [KeyID]  NVARCHAR (10) NULL
);

CREATE TABLE [dbo].[Tasks] (
    [Id]        INT IDENTITY(1,1) PRIMARY KEY,
    [Date] DATETIME        NOT NULL,
    [End] DATETIME NULL,
    [ChildID]  NVARCHAR (10) NULL,
    [Done] BIT NULL,
    [VolunteerID]  NVARCHAR (10) NULL,
    [Type]     NVARCHAR (500)   NOT NULL,
    [Comments]  NVARCHAR (4000) NULL
);