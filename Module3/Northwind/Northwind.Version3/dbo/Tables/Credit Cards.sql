CREATE TABLE [dbo].[Credit Cards] (
    [CardNumber]     INT            IDENTITY (1, 1) NOT NULL,
    [ExpirationDate] DATE           NOT NULL,
    [CardHolderName] NVARCHAR (150) NOT NULL,
    [EmployeeID]     INT            NOT NULL,
    CONSTRAINT [PK_CardNumber] PRIMARY KEY CLUSTERED ([CardNumber] ASC),
    CONSTRAINT [FK_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]) ON DELETE CASCADE
);

