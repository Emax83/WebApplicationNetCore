CREATE TABLE [dbo].[tblCategories]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CategoryName] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(255) NULL
)
