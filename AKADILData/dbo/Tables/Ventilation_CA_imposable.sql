CREATE TABLE [dbo].[Ventilation_CA_imposable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Code] INT NOT NULL, 
    [Designation] NVARCHAR(MAX) NULL, 
    [Base_imposable] MONEY NULL, 
    [Taxe_exigible] MONEY NULL, 
    [Id_instance] INT NOT NULL, 
    CONSTRAINT [FK_Ventilation_CA_imposable_To_Instance_declaration] FOREIGN KEY ([Id_instance]) REFERENCES [Instance_declaration]([Id])
)
