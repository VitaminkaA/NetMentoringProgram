--������� 1.3. ������������� ��������� BETWEEN, DISTINCT

--1. ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), 
--��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � 
--������� Order Details. ������������ �������� BETWEEN. ������ ������ ���������� ������ 
--������� OrderID.

select distinct(od.OrderID)
from [Northwind].dbo.[Order Details] oD
where oD.Quantity between 3 and 10

--2. ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
--����� �� ��������� b � g. ������������ �������� BETWEEN. ���������, ��� � ���������� 
--������� �������� Germany. ������ ������ ���������� ������ ������� CustomerID � Country � 
--������������ �� Country.

select cust.CustomerID, cust.Country
from [Northwind].dbo.Customers cust
where cust.Country between 'b' and 'h'
order by cust.Country

--3. ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
--����� �� ��������� b � g, �� ��������� �������� BETWEEN.

select cust.*
from [Northwind].dbo.Customers cust
where cust.Country like '[b-g]%'