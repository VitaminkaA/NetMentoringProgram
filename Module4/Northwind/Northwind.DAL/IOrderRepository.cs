using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.DAL.Entities;

namespace Northwind.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
    }
}
