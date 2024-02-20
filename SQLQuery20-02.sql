DROP TABLE [dbo].[Users];
CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Email]    NVARCHAR (255) NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Type]     NVARCHAR (500) NOT NULL,
    [ChildID]    NVARCHAR (10)  NULL,
	[VolunteerID]    NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

ALTER TABLE [dbo].[Users]
ADD CONSTRAINT FK_UsersChilds
FOREIGN KEY (ChildID) REFERENCES Children(Id);

ALTER TABLE [dbo].[Users]
ADD CONSTRAINT FK_UsersVolunteers
FOREIGN KEY (VolunteerID) REFERENCES Volunteers(Id);

ALTER TABLE [dbo].[Children]
ADD CONSTRAINT FK_ChildrenAddress
FOREIGN KEY (AddressID) REFERENCES [Address](Id);

ALTER TABLE [dbo].[Volunteers]
ADD CONSTRAINT FK_VolunteersAddress
FOREIGN KEY (AddressID) REFERENCES [Address](Id);

ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT FK_TasksVolunteers
FOREIGN KEY (VolunteerID) REFERENCES Volunteers(Id);

ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT FK_TasksChildren
FOREIGN KEY (ChildID) REFERENCES Children(Id);

