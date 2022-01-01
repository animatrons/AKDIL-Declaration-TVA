CREATE TABLE [dbo].[Chiffre_affaires]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Code] INT NOT NULL, 
    [Num_facture] NVARCHAR(50) NULL, 
    [Date_facture] DATETIME2 NULL, 
    [Client] NVARCHAR(50) NULL,
    [Objet] NVARCHAR(50) NULL, 
    [Montant_HT] MONEY NOT NULL, 
    [Taux] INT NOT NULL, 
    [Montant_TVA] MONEY NOT NULL, 
    [Montant_TTC] MONEY NOT NULL, 
    [Mode_reglement] NVARCHAR(50) NULL, 
    [Date_reglement] DATETIME2 NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Chiffre_affaire_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id]),
)

GO

CREATE TRIGGER [dbo].[Trigger_Chiffre_affaires]
    ON [dbo].[Chiffre_affaires]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
        DECLARE 
            @Montant_HT money 
            SET @Montant_HT = (SELECT Montant_HT FROM inserted);
        DECLARE 
            @Taxe money
            SET @Taxe = (SELECT Montant_TVA FROM inserted);
        DECLARE 
            @Code int
            SET @Code = (SELECT Code FROM inserted);
        DECLARE 
            @Mois int
            SET @Mois = (SELECT Id_instance FROM inserted)

        UPDATE dbo.Ventilation_CA_totale
        SET Montant += @Montant_HT
        WHERE Code = 10 and Id_instance = @Mois;

        UPDATE dbo.Ventilation_CA_totale
        SET Montant += @Montant_HT
        WHERE Code = 60 and Id_instance = @Mois;

        IF @Code = 20 or @Code = 30 or @Code = 40 or @Code = 50
        BEGIN
            UPDATE dbo.Ventilation_CA_totale
            SET Montant += @Montant_HT
            WHERE Code = @Code and Id_instance = @Mois;
            UPDATE dbo.Ventilation_CA_totale
            SET Montant -= @Montant_HT
            WHERE Code = 60 and Id_instance = @Mois;
        END

        UPDATE dbo.Ventilation_CA_imposable
        SET Base_imposable += @Montant_HT
        WHERE Code = @Code and Id_instance = @Mois;

        UPDATE dbo.Ventilation_CA_imposable
        SET Taxe_exigible += @Taxe
        WHERE Code = @Code and Id_instance = @Mois;

        UPDATE dbo.Ventilation_CA_imposable
        SET Taxe_exigible += @Taxe
        WHERE Code = 130 and Id_instance = @Mois;

        UPDATE dbo.Declaration_totaux
        SET Totale_TVA_exigible += @Montant_HT,
            Credit_N1 = Totale_TVA_exigible - Totale_TVA_deductible
        WHERE Id_instance = @Mois;

    END
