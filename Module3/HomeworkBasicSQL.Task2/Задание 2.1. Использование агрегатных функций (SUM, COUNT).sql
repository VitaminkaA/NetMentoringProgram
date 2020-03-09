--������� 2.1. ������������� ���������� ������� (SUM, COUNT)

--1. ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� 
--������� � ������ �� ���. ����������� ������� ������ ���� ���� ������ � ����� �������� � 
--��������� ������� 'Totals'.

select sum((oD.UnitPrice-od.Discount)*od.Quantity)as 'Totals'
from [Northwind].dbo.[Order Details] as oD

--2. �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � 
--������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� ������ 
--�������� COUNT. �� ������������ ����������� WHERE � GROUP.

select count(case when o.ShippedDate is null then 1
		     end)
from [Northwind].dbo.Orders as o

--3. �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. 
--������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.

select count(distinct(o.CustomerID))
from [Northwind].dbo.Orders as o


