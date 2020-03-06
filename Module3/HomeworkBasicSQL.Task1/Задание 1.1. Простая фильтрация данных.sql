--������� 1.1. ������� ���������� ������

--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) 
--������������ � ������� ���������� � ShipVia >= 2. 
--������ ������ ���������� ������ ������� OrderID, ShippedDate � ShipVia.

select o.OrderID, o.ShippedDate, o.ShipVia
from [Northwind].dbo.Orders as o
where o.ShippedDate>='1998-5-6' and o.ShipVia>=2

--�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders. 
--� ����������� ������� ���������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� 
--(������������ ��������� ������� CAS�). ������ ������ ���������� ������ ������� OrderID � ShippedDate.

select o.OrderID, ShippedDate = 'Not Shipped'
from [Northwind].dbo.Orders as o
where o.ShippedDate is null

select o.OrderID, case when o.ShippedDate is null then 'Not Shipped' end ShippedDate
from [Northwind].dbo.Orders as o
where o.ShippedDate is null

--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� 
--��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������ ������ ������� OrderID 
--(������������� � Order Number) � ShippedDate (������������� � Shipped Date). � ����������� ������� 
--���������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� 
--���������� ���� � ������� �� ���������.

select o.OrderID as 'Order Number', 
	case 
		when o.ShippedDate is null then 'Not Shipped'
		else cast(cast(o.ShippedDate as date) as char(15))
	end ShippedDate
from [Northwind].dbo.Orders as o
where o.ShippedDate>'1998-5-6' or o.ShippedDate is null
