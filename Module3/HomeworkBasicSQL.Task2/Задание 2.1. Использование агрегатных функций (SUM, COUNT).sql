--Задание 2.1. Использование агрегатных функций (SUM, COUNT)

--1. Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных 
--товаров и скидок по ним. Результатом запроса должна быть одна запись с одной колонкой с 
--названием колонки 'Totals'.

select 'Totals'=sum((oD.UnitPrice-od.Discount)*od.Quantity)
from [Northwind].dbo.[Order Details] as oD

--2. По таблице Orders найти количество заказов, которые еще не были доставлены (т.е. в 
--колонке ShippedDate нет значения даты доставки). Использовать при этом запросе только 
--оператор COUNT. Не использовать предложения WHERE и GROUP.

select count(case when ord.ShippedDate is null then 1
		     end)
from [Northwind].dbo.Orders as ord

--3. По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. 
--Использовать функцию COUNT и не использовать предложения WHERE и GROUP.

select count(distinct(ord.CustomerID))
from [Northwind].dbo.Orders as ord


