using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Northwind.EF.DAL.Entities;

namespace Northwind.ORM.DAL.Context
{
    public class NorthwindLinq2dbContext : DataConnection
    {
        public NorthwindLinq2dbContext() { }


        public ITable<Category> Categories => GetTable<Category>();
        public ITable<Product> Products => GetTable<Product>();
        public ITable<Supplier> Suppliers => GetTable<Supplier>();
        public ITable<Employee> Employees => GetTable<Employee>();
        public ITable<EmployeeTerritory> EmployeeTerritories => GetTable<EmployeeTerritory>();
        public ITable<Territory> Territories => GetTable<Territory>();
        public ITable<Region> Regions => GetTable<Region>();
        public ITable<Shipper> Shippers => GetTable<Shipper>();
        public ITable<Order> Orders => GetTable<Order>();

    }
}
