using System;
using System.Linq;
using Northwind.DAL;
using Northwind.DAL.Entities;
using Xunit;

namespace Northwind.Tests
{
    public class OrderRepositoryTests
    {
        [Fact]
        public void GetOrders_ReturnOrders()
        {
            var rep = new OrderRepository("System.Data.SqlClient",
                "Server=EPBYBREW0245;Database=Northwind;Trusted_Connection=True;");

            var res = rep.GetOrders().ToArray();

            Assert.True(res != null);
        }

        [Fact]
        public void GetOrder_ReturnOrder()
        {
            var rep = new OrderRepository("System.Data.SqlClient",
                "Server=EPBYBREW0245;Database=Northwind;Trusted_Connection=True;");

            var res = rep.GetOrderById(10253);

            Assert.False(res == null);
        }

        [Fact]
        public void AddOrder_insert()
        {
            var rep = new OrderRepository("System.Data.SqlClient",
                "Server=EPBYBREW0245;Database=Northwind;Trusted_Connection=True;");

            var newOrder = new Order
            {
                CustomerID = "ANTON",
                EmployeeID = 1,
                Freight = 10,
                OrderDate = DateTime.Now
            };
            rep.AddOrder(newOrder);

            //Assert.True(res != null);
        }
    }
}
