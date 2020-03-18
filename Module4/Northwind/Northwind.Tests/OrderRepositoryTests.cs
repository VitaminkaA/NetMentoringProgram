using System.Linq;
using Northwind.DAL;
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
    }
}
