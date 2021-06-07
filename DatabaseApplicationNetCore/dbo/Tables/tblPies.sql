CREATE TABLE [dbo].[tblPies]
(
	[PieId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [ShortDescription] VARCHAR(100) NOT NULL, 
    [LongDescription] VARCHAR(500) NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [ImageUrl] VARCHAR(500) NULL, 
    [ImageThumbnailUrl] VARCHAR(500) NULL, 
    [IsPieOfTheWeek] BIT NOT NULL, 
    [InStock] BIT NOT NULL, 
    [CategoryId] INT NOT NULL
)
