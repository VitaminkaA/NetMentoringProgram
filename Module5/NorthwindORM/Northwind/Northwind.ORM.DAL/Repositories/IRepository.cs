using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Northwind.EF.DAL.Entities;

namespace Northwind.ORM.DAL.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<Product>> GetProductWithCategoryAndSupplier();
        Task<IEnumerable<Employee>> GetEmployeesWithRegions();
        Task<IEnumerable<Tuple<Region, int>>> NumberOfEmployeesByRegion();
        Task<IEnumerable<Employee>> GetEmployeeWithShippers();
        Task<int> AddNewEmployeeWithTerritories(Employee newEmployee);
        Task<int> TransferProductsFromOneCategoryToAnother(int firstId, int secondId);
    }
}
