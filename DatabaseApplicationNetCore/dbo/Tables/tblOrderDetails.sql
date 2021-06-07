CREATE TABLE [dbo].[tblOrderDetails]
(
	[OrderDetailId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrderId] INT NOT NULL ,
    [PieId] INT NOT NULL,
    [Amount] INT NULL,
    [Price] DECIMAL(18,2),
    [SubTotal] DECIMAL(18,2), 

)
