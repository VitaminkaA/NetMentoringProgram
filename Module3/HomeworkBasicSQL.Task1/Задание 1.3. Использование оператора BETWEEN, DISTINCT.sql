--������� 1.3. ������������� ��������� BETWEEN, DISTINCT

--1. ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), 
--��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � 
--������� Order Details. ������������ �������� BETWEEN. ������ ������ ���������� ������ 
--������� OrderID.

select distinct(od.OrderID)
from [Northwind].dbo.[Order Details] as oD
where oD.Quantity between 3 and 10

--2. ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
--����� �� ��������� b � g. ������������ �������� BETWEEN. ���������, ��� � ���������� 
--������� �������� Germany. ������ ������ ���������� ������ ������� CustomerID � Country � 
--������������ �� Country.

select c.CustomerID, c.Country
from [Northwind].dbo.Customers as c
where c.Country between 'b' and 'h'
order by c.Country

--3. ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
--����� �� ��������� b � g, �� ��������� �������� BETWEEN.

select c.*
from [Northwind].dbo.Customers as c
where c.Country like '[b-g]%'