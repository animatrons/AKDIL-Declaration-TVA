CREATE TABLE [dbo].[Deduction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] INT NOT NULL, 
    [Num_facture] NVARCHAR(50) NOT NULL, 
    [Date_facture] DATETIME2 NOT NULL, 
    [Fournisseur] NVARCHAR(50) NOT NULL,  
    [IF_fournisseur] INT NOT NULL,
    [Biens_services] NVARCHAR(50) NOT NULL, 
    [Montant_HT] MONEY NOT NULL, 
    [Taux] INT NOT NULL, 
    [Montant_TVA] MONEY NOT NULL, 
    [Montant_TTC] MONEY NOT NULL, 
    [Libelle_paiment] NVARCHAR(50) NOT NULL, 
    [Date_paiment] DATETIME2 NOT NULL, 
    [Mode_paiment] NVARCHAR(50) NOT NULL, 
    [ICE] INT NOT NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Deduction_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)
