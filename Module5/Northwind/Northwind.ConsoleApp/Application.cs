using Northwind.Core.Services;
using System;

namespace Northwind.ConsoleApp
{
    public class Application
    {
        private readonly IOrderService _service;
        public Application(IOrderService service) 
            => _service = service;

        public void Run()
        {
            foreach (var order in _service.GetOrdersWithDescrByProductsCategory(1))
            {
                Console.WriteLine($"-------------------------------------\r\n" +
                                  $"Id:{order.Id}\r\n" +
                                  $"Customer:{order.Customer.CompanyName}\r\n" +
                                  $"OrderDate:{order.OrderDate}\r\n" +
                                  $"RequiredDateDate:{order.RequiredDate}\r\n" +
                                  $"ShippedDate:{order.ShippedDate}\r\n" +
                                  $"ShipAddress:{order.ShipAddress}");
                foreach (var orderDetail in order.OrderDetails)
                {
                    Console.WriteLine($"Product name:{orderDetail.Product.ProductName}; " +
                                      $"Quantity:{orderDetail.Quantity}; " +
                                      $"UnitPrice:{orderDetail.UnitPrice}; " +
                                      $"Discount:{orderDetail.Discount}. ");
                }
            }
        }
    }
}
