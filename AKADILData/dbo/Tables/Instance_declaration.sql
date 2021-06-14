CREATE TABLE [dbo].[Instance_declaration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Mois] INT NOT NULL, 
    [Id_Identificateur_entreprise] INT NOT NULL, 
    CONSTRAINT [FK_Instance_declaration_To_Identificateur_entreprise] FOREIGN KEY ([Id_Identificateur_entreprise]) REFERENCES [Identificateur_entreprise]([Id])
)
