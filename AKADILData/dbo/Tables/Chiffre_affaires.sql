CREATE TABLE [dbo].[Chiffre_affaires]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Code] INT NOT NULL, 
    [Num_facture] NVARCHAR(50) NOT NULL, 
    [Date_facture] DATETIME2 NOT NULL, 
    [Client] NVARCHAR(50) NOT NULL,
    [Objet] NVARCHAR(50) NOT NULL, 
    [Montant_HT] MONEY NOT NULL, 
    [Taux] INT NOT NULL, 
    [Montant_TVA] MONEY NOT NULL, 
    [Montant_TTC] MONEY NOT NULL, 
    [Mode_reglement] NVARCHAR(50) NOT NULL, 
    [Date_reglement] DATETIME2 NOT NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Chiffre_affaire_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id]),
)
