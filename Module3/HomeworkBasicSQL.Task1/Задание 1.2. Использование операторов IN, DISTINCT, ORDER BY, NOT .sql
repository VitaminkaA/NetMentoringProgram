--������� 1.2. ������������� ���������� IN, DISTINCT, ORDER BY, NOT

--1. ������� �� ������� Customers ���� ����������, ����������� � USA � Canada. ������ ������� � 
--������ ������� ��������� IN. ���������� ������� � ������ ������������ � ��������� ������ � 
--����������� �������. ����������� ���������� ������� �� ����� ���������� � �� ����� ����������.

select c.ContactName, c.Country
from [Northwind].dbo.Customers c
where c.Country in('USA', 'Canada')
order by c.ContactName, c.Country

--2. ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. ������ ������� 
--� ������� ��������� IN. ���������� ������� � ������ ������������ � ��������� ������ � 
--����������� �������. ����������� ���������� ������� �� ����� ����������.

select c.ContactName, c.Country
from [Northwind].dbo.Customers c
where c.Country not in('USA', 'Canada')
order by c.ContactName

--3. ������� �� ������� Customers ��� ������, � ������� ��������� ���������. ������ ������ ���� 
--��������� ������ ���� ��� � ������ ������������ �� ��������. �� ������������ ����������� GROUP 
--BY. ���������� ������ ���� ������� � ����������� �������.

select distinct(c.Country) 
from [Northwind].dbo.Customers c
order by c.Country desc