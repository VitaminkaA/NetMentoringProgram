using HttpHandler.BL.Models;
using HttpHandler.DAL.Entities;
using HttpHandler.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HttpHandler.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
            => _repository = repository;

        public IEnumerable<Order> GetReport(FilterModel filter)
        {
            IQueryable<Order> res;

            if (filter == null)
                res = _repository.GetAll();
            else
            {
                Expression<Func<Order, bool>> filterExpression = x =>
                                    string.IsNullOrWhiteSpace(filter.CustomerId) ? true : x.CustomerId == filter.CustomerId
                                    && !filter.DateRange.Item1.HasValue ? true : x.OrderDate > filter.DateRange.Item1.Value
                                    && !filter.DateRange.Item2.HasValue ? true : x.OrderDate < filter.DateRange.Item1.Value;

                res = _repository.GetAll(filterExpression);

                if (filter.Skip > 0)
                    res = res.Skip(filter.Skip);
                if (filter.Take > 0)
                    res = res.Take(filter.Take);
            }

            return res.Include(x => x.OrderDetails)
                      .ThenInclude(x => x.Product);
        }

    }
}
