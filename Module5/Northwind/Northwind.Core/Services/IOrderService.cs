using Northwind.EF.DAL.Entities;
using System.Collections.Generic;

namespace Northwind.Core.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersWithDescrByProductsCategory(int categoryId);
    }
}
