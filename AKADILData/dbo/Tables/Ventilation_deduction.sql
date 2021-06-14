CREATE TABLE [dbo].[Ventilation_deduction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Code] INT NOT NULL, 
    [Designation] NVARCHAR(50) NULL,
    [Taux] INT NULL, 
    [TVA] MONEY NULL, 
    [Prorata] INT NULL, 
    [TVA_dedcutible] MONEY NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Ventilation_deduction_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)
