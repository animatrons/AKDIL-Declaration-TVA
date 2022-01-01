CREATE PROCEDURE [dbo].[spEntrepriseMonth_GetAll_ByYearId]
	@year_Id int
AS
BEGIN
	SELECT [Id], [Mois], [Id_Identificateur_entreprise] 
	FROM dbo.Instance_declaration 
	WHERE Id_Identificateur_entreprise = @year_Id;
END
