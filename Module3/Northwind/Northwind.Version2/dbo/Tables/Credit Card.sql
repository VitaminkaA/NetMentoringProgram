CREATE TABLE [Credit Cards](
	[CardNumber] [int] IDENTITY(1,1) not null,
	[ExpirationDate] [date] not null,
	[CardHolderName] [nvarchar](150) not null,
	[EmployeeID] [int] not null,
	CONSTRAINT [PK_CardNumber] PRIMARY KEY (CardNumber),
	CONSTRAINT [FK_EmployeeID] FOREIGN KEY (EmployeeID) REFERENCES [dbo].[Employees] (EmployeeID) ON DELETE CASCADE
)
