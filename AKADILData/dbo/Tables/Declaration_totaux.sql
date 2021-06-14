CREATE TABLE [dbo].[Declaration_totaux]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Totale_TVA_exigible] MONEY NULL, 
    [Totale_TVA_deductible] MONEY NULL, 
    [Credit_N1] MONEY NULL, 
    [Id_instance] INT NULL,
    CONSTRAINT [FK_Declaration_totaux_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)
