CREATE TABLE [dbo].[User]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL, 
    [loginStatus] BIT NOT NULL DEFAULT 0,
    [token] VARCHAR(128) NOT NULL, 
    [lastLoginDate] DATETIME2 NULL DEFAULT getutcdate()  
    
)
