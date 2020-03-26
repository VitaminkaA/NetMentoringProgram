using Microsoft.EntityFrameworkCore;
using Northwind.EF.DAL.Entities;
using Northwind.EF.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
            => _repository = repository;

        public IEnumerable<Order> GetOrdersWithDescrByProductsCategory(int categoryId)
            => _repository.GetAll(x => x.OrderDetails.All(y => y.Product.CategoryId == categoryId))
                     .Include(x => x.OrderDetails)
                        .ThenInclude(x => x.Product)
                     .Include(x => x.Customer)
                .ToList();
    }
}
