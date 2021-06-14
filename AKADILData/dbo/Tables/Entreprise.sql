CREATE TABLE [dbo].[Entreprise]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AdminId] NVARCHAR(128) NOT NULL, 
    [Raison_sociale] NVARCHAR(256) NOT NULL, 
    [Forme_juridique] NVARCHAR(50) NULL, 
    [Objet] NVARCHAR(MAX) NOT NULL, 
    [IF] INT NOT NULL, 
    [ICE] INT NOT NULL, 
    [RC] INT NULL, 
    [TP] INT NULL, 
    [CIN] CHAR(10) NULL, 
    [Siege_sociale] NVARCHAR(MAX) NULL, 
    [Ville] NVARCHAR(50) NULL, 
    [Tel] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(256) NULL, 
    CONSTRAINT [FK_Entreprise_ToUser] FOREIGN KEY ([AdminId]) REFERENCES [User]([Id])
)
