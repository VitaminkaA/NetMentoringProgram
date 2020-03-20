using System;
using System.Linq;
using Northwind.DAL;
using Northwind.DAL.Entities;
using Northwind.DAL.Exceptions;
using Xunit;

namespace Northwind.Tests
{
    public class OrderRepositoryTests
    {
        private readonly IOrderRepository repository;

        public OrderRepositoryTests()
        {
            repository = new OrderRepository("System.Data.SqlClient",
                "Server=EPBYBREW0245;Database=Northwind;Trusted_Connection=True;");
        }

        [Fact]
        public void GetOrders_OrdersList()
        {
            // Arrange, Act
            var res = repository.GetOrders().ToArray();

            // Assert
            Assert.NotNull(res);
            Assert.True(res.Any());
        }

        [Fact]
        public void GetOrder_ExistingId_OrderWithDetail()
        {
            // Arrange
            const int id = 10253;

            // Act
            var res = repository.GetOrderById(id);

            // Assert
            Assert.NotNull(res);
            Assert.NotNull(res.OrderDetails);
            Assert.Equal(id, res.OrderId);
            Assert.All(res.OrderDetails, details => Assert.NotNull(details.Product));
        }

        [Fact]
        public void GetOrder_NonexistentId_RepositoryException()
        {
            // Arrange
            const int id = -1;

            // Act, Assert
            Assert.Throws<RepositoryException>(() => repository.GetOrderById(id));
        }

        [Fact]
        public void AddOrder_ValidOrder_InsertSuccess()
        {
            // Arrange
            var expectedCount = repository.GetOrders().Count() + 1;
            var newOrder = new Order
            {
                CustomerID = "ANTON",
                EmployeeID = 1,
                Freight = 10,
                OrderDate = DateTime.Now
            };

            // Act
            repository.AddOrder(newOrder);

            // Assert
            Assert.Equal(expectedCount, repository.GetOrders().Count());
        }

        [Fact]
        public void AddOrder_InvalidOrder_ArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => repository.AddOrder(null));
        }

        [Fact]
        public void UpdateOrder_ValidOrder_UpdateSuccess()
        {
            // Arrange
            const int id = 11097;
            var order = new Order
            {
                OrderId = id,
                CustomerID = "TOMSP"
            };
            repository.UpdateOrder(order);
            order.CustomerID = "ANTON";

            // Act
            repository.UpdateOrder(order);

            // Assert
            Assert.Equal(order.CustomerID, repository.GetOrderById(id).CustomerID);
        }

        [Fact]
        public void UpdateOrder_InvalidOrder_ArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => repository.UpdateOrder(null));
        }

        [Fact]
        public void UpdateOrder_UpdateOrderDate_RepositoryException()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 11103,
                CustomerID = "TOMSP",
                OrderDate = new DateTime(2020, 03, 20, 12, 27, 35),
            };

            // Act, Assert
            Assert.Throws<RepositoryException>(() => repository.UpdateOrder(order));
        }

        [Fact]
        public void UpdateOrder_UpdateOrderWithInWorkOrderStatus_RepositoryException()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 11077,
                CustomerID = "TOMSP",
                OrderDate = new DateTime(2020, 05, 06, 00, 00, 00),
                RequiredDate = new DateTime(2020, 05, 06, 00, 00, 00)
            };

            // Act, Assert
            Assert.Throws<RepositoryException>(() => repository.UpdateOrder(order));
        }

        [Fact]
        public void DeleteOrder_OrderWithStatusIsCompleted_RepositoryException()
        {
            // Arrange, Act, Assert
            Assert.Throws<RepositoryException>(() => repository.DeleteOrder(11101));
        }

        [Fact]
        public void CustOrderHist_ValidParameter_CustOrderHistList()
        {
            // Arrange
            const string customerId = "TOMSP";

            // Act
            var res = repository.CustOrderHist(customerId);

            //Assert
            Assert.NotNull(res);
            Assert.True(res.Any());
        }

        [Fact]
        public void CustOrderDetail_ValidParameter_CustOrderDetailList()
        {
            // Arrange
            const int orderId = 10250;

            // Act
            var res = repository.CustOrderDetail(orderId);

            //Assert
            Assert.NotNull(res);
            Assert.True(res.Any());
        }
    }
}
