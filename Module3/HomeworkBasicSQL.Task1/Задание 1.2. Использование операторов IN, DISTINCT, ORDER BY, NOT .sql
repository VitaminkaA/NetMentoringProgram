--Задание 1.2. Использование операторов IN, DISTINCT, ORDER BY, NOT

--1. Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. Запрос сделать с 
--только помощью оператора IN. Возвращать колонки с именем пользователя и названием страны в 
--результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту проживания.

select c.ContactName, c.Country
from [Northwind].dbo.Customers c
where c.Country in('USA', 'Canada')
order by c.ContactName, c.Country

--2. Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. Запрос сделать 
--с помощью оператора IN. Возвращать колонки с именем пользователя и названием страны в 
--результатах запроса. Упорядочить результаты запроса по имени заказчиков.

select c.ContactName, c.Country
from [Northwind].dbo.Customers c
where c.Country not in('USA', 'Canada')
order by c.ContactName

--3. Выбрать из таблицы Customers все страны, в которых проживают заказчики. Страна должна быть 
--упомянута только один раз и список отсортирован по убыванию. Не использовать предложение GROUP 
--BY. Возвращать только одну колонку в результатах запроса.

select distinct(c.Country) 
from [Northwind].dbo.Customers c
order by c.Country desc