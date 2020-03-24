using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.EF.DAL.Entities;
using Northwind.EF.DAL.Repositories;

namespace Northwind.ConsoleApp
{
    public class Application
    {
        private readonly IRepository<Order> _repository;
        public Application(IRepository<Order> repository) 
            => _repository = repository;

        public async Task RunAsync()
        {
            var orders = 
                await _repository.GetAll(x 
                        => x.OrderDetails.All(y
                            => y.Product.CategoryId == 1))
                .ToListAsync();

            foreach (var order in orders)
            {
                Console.WriteLine($"Id:{order.Id}");
                Console.WriteLine($"Customer:{order.Customer}");
                Console.WriteLine($"OrderDate:{order.OrderDate}");
                Console.WriteLine($"RequiredDateDate:{order.RequiredDate}");
                Console.WriteLine($"ShippedDate:{order.ShippedDate}");
                Console.WriteLine($"ShipAddress:{order.ShipAddress}");
                foreach (var orderDetail in order.OrderDetails)
                {
                    
                    Console.WriteLine($"Product name:{orderDetail.Product.ProductName}; " +
                                      $"Quantity:{orderDetail.Quantity}; " +
                                      $"UnitPrice:{orderDetail.UnitPrice}; " +
                                      $"Discount:{orderDetail.Discount}. \r\n");
                }
            }
        }
    }
}
