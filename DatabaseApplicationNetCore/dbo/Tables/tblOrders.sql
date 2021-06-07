CREATE TABLE [dbo].[tblOrders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrderPlaced] DateTime NOT NULL,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [AddressLine1] VARCHAR(100) NOT NULL,
    [AddressLine2] VARCHAR(100) NULL,
    [ZipCode] VARCHAR(5) NOT NULL,
    [City] VARCHAR(100) NOT NULL,
    [Country] VARCHAR(100) NOT NULL,
    [PhoneNumber] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [OrderTotal] DECIMAL NULL
)
