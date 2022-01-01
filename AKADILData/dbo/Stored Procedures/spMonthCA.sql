CREATE PROCEDURE [dbo].[spMonthCA]
	@month_Id int
AS
BEGIN
	SELECT [Code], [Num_facture], [Date_facture], [Client], [Objet], [Montant_HT], [Taux], [Montant_TVA], [Montant_TTC], [Mode_reglement], [Date_reglement], [Id_instance]  
	FROM dbo.Chiffre_affaires
	WHERE Id_instance = @month_Id;
END
