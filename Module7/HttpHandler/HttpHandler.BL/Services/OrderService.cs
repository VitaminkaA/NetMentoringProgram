using HttpHandler.BL.Models;
using HttpHandler.DAL.Entities;
using HttpHandler.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HttpHandler.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
            => _repository = repository;

        public async Task<IEnumerable<Order>> GetReport(FilterModel filter)
        {
            if (filter == null)
                throw new ArgumentNullException();

            Expression<Func<Order, bool>> filterExpression = x =>
                                (string.IsNullOrWhiteSpace(filter.CustomerId) || x.CustomerId == filter.CustomerId)
                                    && (!filter.DateRange.Item1.HasValue || (x.OrderDate > filter.DateRange.Item1.Value)
                                        && (!filter.DateRange.Item2.HasValue || x.OrderDate < filter.DateRange.Item1.Value));

            var res = _repository.GetAll(filterExpression);

            if (filter.Skip.HasValue)
                res = res.Skip(filter.Skip.Value);
            if (filter.Take.HasValue)
                res = res.Take(filter.Take.Value);

            return await res.OrderBy(x => x.Id)
                .Include(x => x.OrderDetails)
                      .ThenInclude(x => x.Product)
                .ToListAsync();
        }

    }
}
