using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using Northwind.EF.DAL.Entities;
using Northwind.ORM.DAL.Context;

namespace Northwind.ORM.DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly NorthwindLinq2dbContext _context;

        public Repository(NorthwindLinq2dbContext context) =>
            _context = context;

        public async Task<IEnumerable<Product>> GetProductWithCategoryAndSupplier() =>
            await _context.Products.AsQueryable()
                .LoadWith(x => x.Category)
                .LoadWith(x => x.Supplier)
                .ToListAsync();

        public async Task<IEnumerable<Employee>> GetEmployeesWithRegions() =>
            await _context.Employees.AsQueryable()
                .LoadWith(x => x.EmployeeTerritories)
                .ThenLoad(x => x.Territory)
                .ToListAsync();

        public async Task<IEnumerable<Tuple<Region, int>>> NumberOfEmployeesByRegion() =>
            await _context.EmployeeTerritories
                .AsQueryable()
                .GroupBy(x => x.Territory.Region)
                .Select((x) => new Tuple<Region, int>(x.Key, x.Count()))
                .ToListAsync();

        public async Task<IEnumerable<Employee>> GetEmployeeWithShippers() =>
            await _context.Employees
                .AsQueryable()
                .LoadWith(x => x.Orders)
                .ThenLoad(x => x.ShipViaNavigation)
                .ToListAsync();

        public async Task<int> AddNewEmployeeWithTerritories(Employee newEmployee)
        {
            if (newEmployee == null)
                throw new ArgumentNullException();

            var a = _context.BeginTransaction();
            newEmployee.EmployeeId = await _context.InsertWithInt32IdentityAsync(newEmployee);
            if (newEmployee.EmployeeTerritories.Any())
                foreach (var employeeTerritories in newEmployee.EmployeeTerritories)
                {
                    employeeTerritories.EmployeeId = newEmployee.EmployeeId;
                    await _context.GetTable<Territory>()
                        .Value(x => x.TerritoryId, employeeTerritories.Territory.TerritoryId)
                        .Value(x => x.RegionId, employeeTerritories.Territory.RegionId)
                        .Value(x => x.TerritoryDescription, employeeTerritories.Territory.TerritoryDescription)
                        .InsertAsync();

                    await _context.InsertAsync(employeeTerritories);
                }
            _context.CommitTransaction();
            return newEmployee.EmployeeId;
        }

        public async Task<int> TransferProductsFromOneCategoryToAnother(int firstId, int secondId)
        {
            if (firstId == secondId)
                throw new ArgumentException();

            var updatedCount = await _context.Products
                .UpdateAsync(p => p.CategoryId == firstId, pr =>
                    new Product
                    {
                        CategoryId = secondId
                    });
            return updatedCount;
        }
    }
}
