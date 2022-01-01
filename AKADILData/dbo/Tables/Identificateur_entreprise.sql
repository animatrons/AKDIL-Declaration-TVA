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

GO

CREATE TRIGGER [dbo].[Trigger_new_Year_entreprise]
    ON [dbo].[Identificateur_entreprise]
    FOR INSERT, UPDATE
    AS
    BEGIN
		DECLARE 
			@MT nvarchar(50)
			SET @MT = (SELECT Mois_trimestre FROM inserted)
		DECLARE
			@Id_year int
			SET @Id_year = (SELECT Id FROM inserted);
		IF @MT = 'Mois'
		BEGIN
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 1, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 2, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 3, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 4, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 5, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 6, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 7, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 8, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 9, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 10, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 11, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 12, @Id_year);
		END
		ELSE 
		BEGIN
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 1, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 4, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 7, @Id_year);
			INSERT INTO dbo.Instance_declaration(Mois, Id_Identificateur_entreprise) VALUES( 10, @Id_year);
		END
        SET NoCount ON
    END