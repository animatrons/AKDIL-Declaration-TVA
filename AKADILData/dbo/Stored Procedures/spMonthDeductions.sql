CREATE PROCEDURE [dbo].[spMonthDeductions]
	@month_Id int
AS
BEGIN
	SELECT [Code], [Num_facture], [Date_facture], [Fournisseur], [IF_fournisseur],[Biens_services], [Montant_HT], [Taux], [Montant_TVA], [Montant_TTC], [Libelle_paiment], [Date_paiment], [Mode_paiment], [ICE], [Id_instance]  
	FROM dbo.Deduction
	WHERE Id_instance = @month_Id;
END
