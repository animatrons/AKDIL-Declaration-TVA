CREATE PROCEDURE [dbo].[spEnrepriseYear_GetAll_ById]
	@entreprise_Id int
AS
BEGIN
	SELECT Id, Id_entreprise, Credit_N1, Annee, Encaissement_debit, Mois_trimestre
	FROM [dbo].[Identificateur_entreprise] 
	WHERE Id_entreprise = @entreprise_Id;
END
