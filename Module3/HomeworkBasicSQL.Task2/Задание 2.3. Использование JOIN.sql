--Задание 2.3. Использование JOIN

--1. Определить продавцов, которые обслуживают регион 'Western' (таблица Region).

select distinct 'Employee'=emp.FirstName+' '+emp.LastName, reg.RegionDescription
from [Northwind].dbo.[Employees] as emp
	 inner join [Northwind].dbo.EmployeeTerritories as empTer on emp.EmployeeID=empTer.EmployeeID
	 inner join [Northwind].dbo.Territories as ter on empTer.TerritoryID=ter.TerritoryID
	 inner join [Northwind].dbo.Region as reg on ter.RegionID=reg.RegionID 
where reg.RegionDescription = 'Western'

--2. Выдать в результатах запроса имена всех заказчиков из таблицы Customers и 
--суммарное количество их заказов из таблицы Orders. Принять во внимание, что у 
--некоторых заказчиков нет заказов, но они также должны быть выведены в результатах 
--запроса. Упорядочить результаты запроса по возрастанию количества заказов.

select cust.CompanyName, 'The number of orders'= count(ord.CustomerID)
from [Northwind].dbo.Customers as cust
	 left outer join [Northwind].dbo.Orders as ord on cust.CustomerID=ord.CustomerID 
group by cust.CustomerID, cust.CompanyName
order by 'The number of orders'
