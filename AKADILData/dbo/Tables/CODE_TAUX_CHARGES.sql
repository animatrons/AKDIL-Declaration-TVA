﻿CREATE TABLE [dbo].[CODE_TAUX_CHARGES]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Code] INT NOT NULL, 
    [Taux] INT NOT NULL, 
    [Designation] NVARCHAR(MAX) NOT NULL
)