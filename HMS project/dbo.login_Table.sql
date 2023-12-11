CREATE TABLE [dbo].[login_Table] (
    [Id]       INT          NOT NULL,
    [username] VARCHAR (50) NULL,
    [password] VARCHAR (50) NULL,
    [role] VARCHAR(50) NULL, 
    CONSTRAINT [PK_login_Table] PRIMARY KEY CLUSTERED ([Id] ASC)
);

