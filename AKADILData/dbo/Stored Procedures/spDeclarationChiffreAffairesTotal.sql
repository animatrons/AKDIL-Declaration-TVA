CREATE PROCEDURE [dbo].[spDeclarationChiffreAffairesTotal]
	@month_Id int
AS
BEGIN
	SELECT [Code], [Designation], [Montant], [Id_instance]
	FROM dbo.Ventilation_CA_totale
	WHERE Id_instance = @month_Id;
END
