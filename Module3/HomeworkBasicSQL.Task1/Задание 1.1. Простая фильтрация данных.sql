--������� 1.1. ������� ���������� ������

--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) 
--������������ � ������� ���������� � ShipVia >= 2. 
--������ ������ ���������� ������ ������� OrderID, ShippedDate � ShipVia.

select ord.OrderID, ord.ShippedDate, ord.ShipVia
from [Northwind].dbo.Orders ord
where ord.ShippedDate>='1998-5-6' and ord.ShipVia>=2

--�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders. 
--� ����������� ������� ���������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� 
--(������������ ��������� ������� CAS�). ������ ������ ���������� ������ ������� OrderID � ShippedDate.

select ord.OrderID, ShippedDate = 'Not Shipped'
from [Northwind].dbo.Orders ord
where ord.ShippedDate is null

select ord.OrderID, case when ord.ShippedDate is null then 'Not Shipped' end ShippedDate
from [Northwind].dbo.Orders ord
where ord.ShippedDate is null

--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� 
--��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������ ������ ������� OrderID 
--(������������� � Order Number) � ShippedDate (������������� � Shipped Date). � ����������� ������� 
--���������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� 
--���������� ���� � ������� �� ���������.

select 'Order Number'=ord.OrderID, 
	case 
		when ord.ShippedDate is null then 'Not Shipped'
		else cast(cast(ord.ShippedDate as date) as char(15))
	end ShippedDate
from [Northwind].dbo.Orders ord
where ord.ShippedDate>'1998-5-6' or ord.ShippedDate is null
