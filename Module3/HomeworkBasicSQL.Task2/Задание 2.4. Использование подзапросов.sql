--������� 2.4. ������������� �����������

--1. ������ ���� ����������� (������� CompanyName � ������� Suppliers), � ������� 
--��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). 
--������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN.

select suppl.SupplierID, suppl.CompanyName
from [Northwind].[dbo].Suppliers as suppl
where suppl.SupplierID in (select pr.SupplierID
					       from [Northwind].[dbo].Products as pr
					       where pr.UnitsInStock=0)

--2. ������ ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� 
--SELECT.

select emp.*
from [Northwind].[dbo].[Employees] as emp
where emp.EmployeeID in (select emp.EmployeeID 
						from [Northwind].[dbo].[Orders] as ord 
						group by ord.EmployeeID 
						having count(1)>150)

--3. ������ ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ 
--(��������� �� ������� Orders). ������������ �������� EXISTS.

select cust.*
from [Northwind].[dbo].Customers as cust
where not exists (select ord.CustomerID 
			      from [Northwind].[dbo].[Orders] as ord 
				  where cust.CustomerID=ord.CustomerID)