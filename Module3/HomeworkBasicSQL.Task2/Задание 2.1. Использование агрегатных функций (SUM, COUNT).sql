--������� 2.1. ������������� ���������� ������� (SUM, COUNT)

--1. ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� 
--������� � ������ �� ���. ����������� ������� ������ ���� ���� ������ � ����� �������� � 
--��������� ������� 'Totals'.

select 'Totals'=sum((oD.UnitPrice-od.Discount)*od.Quantity)
from [Northwind].dbo.[Order Details] as oD

--2. �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � 
--������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� ������ 
--�������� COUNT. �� ������������ ����������� WHERE � GROUP.

select count(case when ord.ShippedDate is null then 1
		     end)
from [Northwind].dbo.Orders as ord

--3. �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. 
--������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.

select count(distinct(ord.CustomerID))
from [Northwind].dbo.Orders as ord


