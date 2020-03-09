--Задание 2.4. Использование подзапросов

--1. Выдать всех поставщиков (колонка CompanyName в таблице Suppliers), у которых 
--нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0). 
--Использовать вложенный SELECT для этого запроса с использованием оператора IN.

select suppl.SupplierID, suppl.CompanyName
from [Northwind].[dbo].Suppliers as suppl
where suppl.SupplierID in (select pr.SupplierID
					       from [Northwind].[dbo].Products as pr
					       where pr.UnitsInStock=0)

--2. Выдать всех продавцов, которые имеют более 150 заказов. Использовать вложенный 
--SELECT.

select emp.*
from [Northwind].[dbo].[Employees] as emp
where emp.EmployeeID in (select emp.EmployeeID 
						from [Northwind].[dbo].[Orders] as ord 
						group by ord.EmployeeID 
						having count(1)>150)

--3. Выдать всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
--(подзапрос по таблице Orders). Использовать оператор EXISTS.

select cust.*
from [Northwind].[dbo].Customers as cust
where not exists (select ord.CustomerID 
			      from [Northwind].[dbo].[Orders] as ord 
				  where cust.CustomerID=ord.CustomerID)