--������� 1.4. ������������� ��������� LIKE

--1. � ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 
--'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � 
--�������� - ����� ��� ��������, ������� ������������� ����� �������.

select prod.ProductName
from [Northwind].dbo.Products as prod
where prod.ProductName like '%cho_olade%'