using HttpHandler.DAL.Context;
using HttpHandler.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpHandler.Tests.Helpers
{
    public class Utilities
    {
        public static async Task InitializeDbForTests(NorthwindEFContext context)
        {
            await context.Orders.AddRangeAsync(OrdersData);
            await context.SaveChangesAsync();
        }

        private static Order[] OrdersData
            => new[]
            {
                new Order
                {
                    Id = 10835,
                    CustomerId = "ALFKI",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=69.53m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 10952,
                    CustomerId = "ALFKI",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=40.42m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 11011,
                    CustomerId = "ALFKI",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=1.21m,
                    ShipName = "Alfred's Futterkiste",
                    ShipAddress = "Obere Str. 57",
                    ShipCity = "Berlin",
                    ShipRegion = null,
                    ShipPostalCode = "12209",
                    ShipCountry = "Germany"
                },
                new Order
                {
                    Id = 10625,
                    CustomerId = "ANATR",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 1,
                    Freight=43.90m,
                    ShipName = "Ana Trujillo Emparedados y helados",
                    ShipAddress = "Avda. de la Constitución 2222",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05021",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10759,
                    CustomerId = "ANATR",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=11.99m,
                    ShipName = "Ana Trujillo Emparedados y helados",
                    ShipAddress = "Avda. de la Constitución 2222",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05021",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10365,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=22.00m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10677,
                    CustomerId = "ANTON",
                    EmployeeId = 1,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 3,
                    Freight=4.03m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10682,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=36.13m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                },
                new Order
                {
                    Id = 10856,
                    CustomerId = "ANTON",
                    EmployeeId = 3,
                    OrderDate = null,
                    RequiredDate = null,
                    ShippedDate = null,
                    ShipVia = 2,
                    Freight=58.43m,
                    ShipName = "Antonio Moreno Taquería",
                    ShipAddress = "Mataderos  2312",
                    ShipCity = "México D.F.",
                    ShipRegion = null,
                    ShipPostalCode = "05023",
                    ShipCountry = "Mexico"
                }
            };
    }
}
