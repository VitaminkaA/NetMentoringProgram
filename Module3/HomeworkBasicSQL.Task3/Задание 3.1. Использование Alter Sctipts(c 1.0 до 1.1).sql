IF NOT EXISTS (SELECT * FROM sys.objects
	WHERE object_id = object_id(N'[Northwind].[dbo].[Credit Cards]') AND type in(N'U'))
BEGIN
CREATE TABLE [Northwind].[dbo].[Credit Cards](
	[CardNumber] [int] IDENTITY(1,1) not null,
	[ExpirationDate] [date] not null,
	[CardHolderName] [nvarchar](150) not null,
	[EmployeeID] [int] not null,
	CONSTRAINT [PK_CardNumber] PRIMARY KEY (CardNumber),
	CONSTRAINT [FK_EmployeeID] FOREIGN KEY (EmployeeID) REFERENCES [dbo].[Employees] (EmployeeID) ON DELETE CASCADE
)
END