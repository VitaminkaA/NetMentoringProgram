--Задание 1.1. Простая фильтрация данных

--Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) 
--включительно и которые доставлены с ShipVia >= 2. 
--Запрос должен возвращать только колонки OrderID, ShippedDate и ShipVia.

select ord.OrderID, ord.ShippedDate, ord.ShipVia
from [Northwind].dbo.Orders ord
where ord.ShippedDate>='1998-5-6' and ord.ShipVia>=2

--Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
--В результатах запроса возвращать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ 
--(использовать системную функцию CASЕ). Запрос должен возвращать только колонки OrderID и ShippedDate.

select ord.OrderID, ShippedDate = 'Not Shipped'
from [Northwind].dbo.Orders ord
where ord.ShippedDate is null

select ord.OrderID, case when ord.ShippedDate is null then 'Not Shipped' end ShippedDate
from [Northwind].dbo.Orders ord
where ord.ShippedDate is null

--Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая 
--эту дату или которые еще не доставлены. В запросе должны возвращаться только колонки OrderID 
--(переименовать в Order Number) и ShippedDate (переименовать в Shipped Date). В результатах запроса 
--возвращать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, для остальных значений 
--возвращать дату в формате по умолчанию.

select 'Order Number'=ord.OrderID, 
	case 
		when ord.ShippedDate is null then 'Not Shipped'
		else cast(cast(ord.ShippedDate as date) as char(15))
	end ShippedDate
from [Northwind].dbo.Orders ord
where ord.ShippedDate>'1998-5-6' or ord.ShippedDate is null
