CREATE PROCEDURE [dbo].[spDeclarationChiffreAffairesImposable]
	@month_Id int
AS
BEGIN
	SELECT [Code], [Designation], Base_imposable, Taxe_exigible, [Id_instance]
	FROM dbo.Ventilation_CA_imposable
	WHERE Id_instance = @month_Id;
END
