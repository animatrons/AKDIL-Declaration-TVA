CREATE TABLE [dbo].[Identificateur_entreprise]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_entreprise] INT NOT NULL, 
    [Credit_N1] MONEY NULL, 
    [Annee] INT NOT NULL, 
    [Encaissement_debit] NVARCHAR(50) NOT NULL, 
    [Mois_trimestre] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [CK_Identificateur_entreprise_Encaissement_debit] CHECK (Encaissement_debit = 'Encaissement' or Encaissement_debit = 'Debit'), 
    CONSTRAINT [CK_Identificateur_entreprise_Mois_trimestre] CHECK (Mois_trimestre = 'Mois' or Mois_trimestre = 'Trimestre'), 
    CONSTRAINT [FK_Identificateur_entreprise_ToEntreprise] FOREIGN KEY ([Id_entreprise]) REFERENCES [Entreprise]([Id])
)
