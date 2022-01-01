CREATE TABLE [dbo].[Deduction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] INT NOT NULL, 
    [Num_facture] NVARCHAR(50) NULL, 
    [Date_facture] DATETIME2 NULL, 
    [Fournisseur] NVARCHAR(50) NULL,  
    [IF_fournisseur] INT NULL,
    [Biens_services] NVARCHAR(50) NULL, 
    [Montant_HT] MONEY NOT NULL, 
    [Taux] INT NOT NULL, 
    [Montant_TVA] MONEY NOT NULL, 
    [Montant_TTC] MONEY NOT NULL, 
    [Libelle_paiment] NVARCHAR(50) NULL, 
    [Date_paiment] DATETIME2 NULL, 
    [Mode_paiment] NVARCHAR(50) NULL, 
    [ICE] INT NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Deduction_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_Deduction]
    ON [dbo].[Deduction]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
        DECLARE 
            @TVA money
            SET @TVA = (SELECT Montant_TVA FROM inserted);
        DECLARE 
            @Code money
            SET @Code = (SELECT Code FROM inserted);
        DECLARE 
            @Mois int
            SET @Mois = (SELECT Id_instance FROM inserted);
        DECLARE 
            @TVA_exigible money
            SET @TVA_exigible = (SELECT Taxe_exigible FROM dbo.Ventilation_CA_imposable WHERE Code = 130 and Id_instance = @Mois);

        UPDATE dbo.Ventilation_deduction 
        SET TVA += @TVA,
            TVA_dedcutible += @TVA
        WHERE Code = @Code and Id_instance = @Mois;

        UPDATE dbo.Ventilation_deduction 
        SET TVA_dedcutible += @TVA
        WHERE Code = 190 and Id_instance = @Mois;

        UPDATE dbo.Ventilation_deduction 
        SET TVA_dedcutible = @TVA_exigible - @TVA
        WHERE Code = 201 and Id_instance = @Mois;
        
        UPDATE dbo.Declaration_totaux 
        SET Totale_TVA_deductible += @TVA,
            Credit_N1 = Totale_TVA_exigible - Totale_TVA_deductible
            WHERE Id_instance = @Mois;

    END