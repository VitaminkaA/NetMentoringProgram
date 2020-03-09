--������� 2.2. ���������� ������, ������������� ���������� ������� � ����������� GROUP BY � HAVING

--1. �� ������� Orders ����� ���������� ������� � ������������ �� �����. � ����������� ������� 
--���� ���������� ��� ������� c ���������� Year � Total. �������� ����������� ������, ������� 
--��������� ���������� ���� �������.

select year(o.OrderDate) as 'Year', count(1) as 'Total'
from [Northwind].dbo.Orders as o
group by year(o.OrderDate)

select count(1) as 'Total'
from [Northwind].dbo.Orders as o

--2. �� ������� Orders ����� ���������� �������, c�������� ������ ���������. ����� ��� ���������� 
--�������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� 
--������� ��������. � ����������� ������� ���� ���������� ������� � ������ �������� (������ 
--������������� ��� ���������� ������������� LastName & FirstName. ��� ������ LastName & FirstName 
--������ ���� �������� ��������� �������� � ������� ��������� �������. ����� �������� ������ ������ 
--������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� 
--������� ���������� � ��������� 'Amount'. ���������� ������� ������ ���� ����������� �� �������� 
--���������� �������.

select 'Seller' = (select emp.FirstName+' '+emp.LastName 
				   from [Northwind].dbo.Employees as emp 
				   where o.EmployeeID = emp.EmployeeID),
	   'Amount' = COUNT(1) 
from [Northwind].dbo.Orders as o
group by o.EmployeeID
order by 'Amount' desc

--3. �� ������� Orders ����� ���������� �������, ��������� ������ ���������(emp) � ��� ������� ����������(cust). 
--���������� ���������� ��� ������ ��� �������, ��������� � 1998 ����.

select o.EmployeeID, o.CustomerID, 'Amount' = count(1)
from [Northwind].dbo.Orders as o
where year(o.OrderDate)=1998
group by o.EmployeeID, o.CustomerID

--4. ����� �����������(cust) � ���������(emp), ������� ����� � ����� ������. ���� � ������ ����� ������ ���� ��� 
--��������� ���������, ��� ������ ���� ��� ��������� �����������, �� ���������� � ����� ���������� � 
--��������� �� ������ �������� � �������������� �����. �� ������������ ����������� JOIN.

select cust.CompanyName, 'Seller'=emp.FirstName+' '+emp.LastName
from [Northwind].dbo.Customers as cust, 
	 [Northwind].dbo.Employees as emp, 
	 (select cust.City
	 from [Northwind].dbo.Employees as emp, [Northwind].dbo.Customers as cust
	 where cust.City=emp.City
	 group by cust.City
	 having count(distinct(cust.CustomerID))>1 and count(distinct(emp.EmployeeID))>1) as cities
where cities.City=emp.City and cust.City=cities.City

--5. ����� ���� �����������(cust), ������� ����� � ����� ������.

select cust.CompanyName, 'Neighbor'= neighbors.CompanyName, cust.City
from [Northwind].dbo.Customers as cust,
	 [Northwind].dbo.Customers as neighbors
where cust.City=neighbors.City and cust.CustomerID!=neighbors.CustomerID

--6. �� ������� Employees ����� ��� ������� �������� ��� ������������.

select 'Employee' = emp.FirstName+' '+emp.LastName, 
	   'ReportsTo' = rep.FirstName+' '+rep.LastName
from [Northwind].dbo.Employees as emp 
	 LEFT OUTER JOIN [Northwind].dbo.Employees as rep
	 on rep.EmployeeID =emp.ReportsTo