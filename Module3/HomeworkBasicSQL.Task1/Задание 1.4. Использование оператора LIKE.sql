--������� 1.4. ������������� ��������� LIKE

--1. � ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 
--'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � 
--�������� - ����� ��� ��������, ������� ������������� ����� �������.

select p.ProductName
from [Northwind].dbo.Products as p
where p.ProductName like '%cho_olade%'