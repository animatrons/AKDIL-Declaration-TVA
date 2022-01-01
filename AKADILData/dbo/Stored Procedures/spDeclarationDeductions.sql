CREATE PROCEDURE [dbo].[spDeclarationDeductions]
	@month_Id int
AS
BEGIN
	SELECT [Code], Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance
	FROM dbo.Ventilation_deduction
	WHERE Id_instance = @month_Id;
END
