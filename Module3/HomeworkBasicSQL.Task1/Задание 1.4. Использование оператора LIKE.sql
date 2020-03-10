--Задание 1.4. Использование оператора LIKE

--1. В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 
--'chocolade'. Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в 
--середине - найти все продукты, которые удовлетворяют этому условию.

select prod.ProductName
from [Northwind].dbo.Products as prod
where prod.ProductName like '%cho_olade%'