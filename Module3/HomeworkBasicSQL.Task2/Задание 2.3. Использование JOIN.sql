--������� 2.3. ������������� JOIN

--1. ���������� ���������, ������� ����������� ������ 'Western' (������� Region).

select distinct 'Employee'=emp.FirstName+' '+emp.LastName, reg.RegionDescription
from [Northwind].dbo.[Employees] as emp
	 inner join [Northwind].dbo.EmployeeTerritories as empTer on emp.EmployeeID=empTer.EmployeeID
	 inner join [Northwind].dbo.Territories as ter on empTer.TerritoryID=ter.TerritoryID
	 inner join [Northwind].dbo.Region as reg on ter.RegionID=reg.RegionID 
where reg.RegionDescription = 'Western'

--2. ������ � ����������� ������� ����� ���� ���������� �� ������� Customers � 
--��������� ���������� �� ������� �� ������� Orders. ������� �� ��������, ��� � 
--��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� 
--�������. ����������� ���������� ������� �� ����������� ���������� �������.

select cust.CompanyName, 'The number of orders'= count(ord.CustomerID)
from [Northwind].dbo.Customers as cust
	 left outer join [Northwind].dbo.Orders as ord on cust.CustomerID=ord.CustomerID 
group by cust.CustomerID, cust.CompanyName
order by 'The number of orders'