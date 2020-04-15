using HttpHandler.BL.Models;
using HttpHandler.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHandler.BL.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetReport(FilterModel filter);
    }
}
