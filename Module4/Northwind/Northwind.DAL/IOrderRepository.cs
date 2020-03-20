using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.DAL.Entities;

namespace Northwind.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        void AddOrder(Order order);
        void SetInWorkStatus(int id);
        void SetCompletedStatus(int id);
        IEnumerable<CustOrderHist> CustOrderHist(string customerId);
        IEnumerable<CustOrdersDetail> CustOrderDetail(int orderId);

    }
}
