CREATE PROCEDURE [dbo].[spEntreprise_GetAll]
	@admin_Id nvarchar(128)
AS
BEGIN
	SELECT Id, Raison_sociale, Forme_juridique, Objet, [IF], ICE, RC, TP, CIN, Siege_sociale, Ville, Tel, Email
	FROM dbo.Entreprise 
	WHERE AdminId = @admin_Id;
END
