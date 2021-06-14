CREATE TABLE [dbo].[Ventilation_CA_totale]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] INT NOT NULL, 
    [Designation] NVARCHAR(50) NULL, 
    [Montant] MONEY NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Ventilation_CA_totale_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)
