using HttpHandler.BL.Models;
using HttpHandler.DAL.Entities;
using System.Collections.Generic;

namespace HttpHandler.BL.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetReport(FilterModel filter);
    }
}
