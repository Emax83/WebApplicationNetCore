CREATE TABLE [dbo].[tblShoppingCart]
(
	[ShoppingCartItemId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [PieId] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    [ShoppingcartId] VARCHAR(50) NOT NULL
)
