--«адание 1.3. »спользование оператора BETWEEN, DISTINCT

--1. ¬ыбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повтор€тьс€), 
--где встречаютс€ продукты с количеством от 3 до 10 включительно Ц это колонка Quantity в 
--таблице Order Details. »спользовать оператор BETWEEN. «апрос должен возвращать только 
--колонку OrderID.

select distinct(od.OrderID)
from [Northwind].dbo.[Order Details] oD
where oD.Quantity between 3 and 10

--2. ¬ыбрать всех заказчиков из таблицы Customers, у которых название страны начинаетс€ на 
--буквы из диапазона b и g. »спользовать оператор BETWEEN. ѕроверить, что в результаты 
--запроса попадает Germany. «апрос должен возвращать только колонки CustomerID и Country и 
--отсортирован по Country.

select cust.CustomerID, cust.Country
from [Northwind].dbo.Customers cust
where cust.Country between 'b' and 'h'
order by cust.Country

--3. ¬ыбрать всех заказчиков из таблицы Customers, у которых название страны начинаетс€ на 
--буквы из диапазона b и g, не использу€ оператор BETWEEN.

select cust.*
from [Northwind].dbo.Customers cust
where cust.Country like '[b-g]%'