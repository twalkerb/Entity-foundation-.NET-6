USE [ShoppingCartDev]
GO

/****** Object:  View [dbo].[CustomerGroupBorrowedBooks]    Script Date: 05/23/2022 10:51:29 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwCustomerGroupBorrowedBooks]'))
DROP VIEW [dbo].[vwCustomerGroupBorrowedBooks]
GO

USE [ShoppingCartDev]
GO

/****** Object:  View [dbo].[CustomerGroupBorrowedBooks]    Script Date: 05/23/2022 10:51:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwCustomerGroupBorrowedBooks]
AS
SELECT     TOP (100) PERCENT Shopping.CustomerBook.LoanDate, Shopping.CustomerBook.ReturnDate, Shopping.Customers.CustomerGroup, Shopping.LibaryBooks.PurchasePrice, 
                      Shopping.LibaryBooks.Name, Shopping.LibaryBooks.InternationStandardBookNumber
FROM         Shopping.Customers INNER JOIN
                      Shopping.CustomerBook ON Shopping.Customers.Id = Shopping.CustomerBook.CustomerId INNER JOIN
                      Shopping.LibaryBooks ON Shopping.CustomerBook.BookId = Shopping.LibaryBooks.Id
ORDER BY Shopping.Customers.CustomerGroup DESC

GO


