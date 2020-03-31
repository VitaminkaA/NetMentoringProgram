using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Northwind.EF.DAL.Entities;
using Northwind.ORM.ConsoleApp.Settings;
using Northwind.ORM.DAL.Repositories;

namespace Northwind.ORM.ConsoleApp
{
    public class App
    {
        private readonly IRepository _repository;
        public App(IRepository repository)
            => _repository = repository;

        public async Task Run()
        {
            Console.WriteLine("Cписок продуктов с категорией и поставщиком:");
            foreach (var record in await _repository.GetProductWithCategoryAndSupplier())
                Console.WriteLine($"{nameof(record.ProductName)}: {record.ProductName} | " +
                                  $"{nameof(record.Category.Name)}: {record.Category.Name} | " +
                                  $"{nameof(record.Supplier.CompanyName)}: {record.Supplier.CompanyName}");

            Console.WriteLine("Cписок сотрудников с указанием региона, за который они отвечают:");
            foreach (var record in await _repository.GetEmployeesWithRegions())
            {
                Console.WriteLine($"{nameof(record.FirstName)}: {record.FirstName}");
                foreach (var territory in record.EmployeeTerritories)
                    Console.WriteLine($"{nameof(territory.Territory.TerritoryDescription)}: {territory.Territory.TerritoryDescription}");
            }

            Console.WriteLine("Статистики по регионам: количество сотрудников по регионам");
            foreach (var (region, count) in await _repository.NumberOfEmployeesByRegion())
                Console.WriteLine($"{region.RegionDescription}:{count}");


            Console.WriteLine("Список /'Сотрудник - с какимим грузоперевозчиками работал/'");
            foreach (var employee in await _repository.GetEmployeeWithShippers())
            {
                Console.WriteLine($"{employee.FirstName}:{employee.FirstName} :");
                if (!employee.Orders.Any()) continue;
                foreach (var order in employee.Orders)
                {
                    if (order.ShipViaNavigation != null)
                        Console.WriteLine($"{nameof(order.ShipViaNavigation.CompanyName)}:{order.ShipViaNavigation.CompanyName}");
                }
            }

            Console.WriteLine("Добавить сотрудника и указать ему список территорий:");
            var newEmp = new Employee
            {
                LastName = "Panasiuk",
                FirstName = "Tatyana",
                EmployeeTerritories = new List<EmployeeTerritory>
                {
                    new EmployeeTerritory
                    {
                        TerritoryId = "00998",
                        Territory = new Territory
                        {
                            TerritoryId = "00998",
                            TerritoryDescription = "Territory1",
                            RegionId = 1
                        }
                    },
                    new EmployeeTerritory
                    {
                        TerritoryId = "09985",
                        Territory = new Territory
                        {
                            TerritoryId = "09985",
                            TerritoryDescription = "Territory2",
                            RegionId = 1
                        }
                    }
                }
            };
            //Console.WriteLine("ID=" + await _repository.AddNewEmployeeWithTerritories(newEmp));

            Console.WriteLine("Перенести продукты из одной категории в другую:");
            Console.WriteLine("Count=" + await _repository.TransferProductsFromOneCategoryToAnother(1,2));
        }
    }
}
