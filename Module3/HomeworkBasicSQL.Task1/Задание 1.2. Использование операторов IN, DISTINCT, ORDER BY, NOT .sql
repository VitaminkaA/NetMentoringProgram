--������� 1.2. ������������� ���������� IN, DISTINCT, ORDER BY, NOT

--1. ������� �� ������� Customers ���� ����������, ����������� � USA � Canada. ������ ������� � 
--������ ������� ��������� IN. ���������� ������� � ������ ������������ � ��������� ������ � 
--����������� �������. ����������� ���������� ������� �� ����� ���������� � �� ����� ����������.

select cust.ContactName, cust.Country
from [Northwind].dbo.Customers cust
where cust.Country in('USA', 'Canada')
order by cust.ContactName, cust.Country

--2. ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. ������ ������� 
--� ������� ��������� IN. ���������� ������� � ������ ������������ � ��������� ������ � 
--����������� �������. ����������� ���������� ������� �� ����� ����������.

select cust.ContactName, cust.Country
from [Northwind].dbo.Customers cust
where cust.Country not in('USA', 'Canada')
order by cust.ContactName

--3. ������� �� ������� Customers ��� ������, � ������� ��������� ���������. ������ ������ ���� 
--��������� ������ ���� ��� � ������ ������������ �� ��������. �� ������������ ����������� GROUP 
--BY. ���������� ������ ���� ������� � ����������� �������.

select distinct(cust.Country) 
from [Northwind].dbo.Customers cust
order by cust.Country desc