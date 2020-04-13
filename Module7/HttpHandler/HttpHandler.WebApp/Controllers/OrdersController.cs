using AutoMapper;
using HttpHandler.BL.Models;
using HttpHandler.BL.Services;
using HttpHandler.WebApp.View;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHandler.WebApp.Controllers
{
    [ApiController]
    [FormatFilter]
    [Route("api/[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderView>> Get(string customerId, DateTime? dateRangeFrom, DateTime? dateRangeTo, int? skip, int? take)
        {
            var filter = new FilterModel
            {
                CustomerId = customerId,
                DateRange = (dateRangeFrom, dateRangeTo),
                Skip = skip,
                Take = take
            };
            return _mapper.Map<IEnumerable<OrderView>>(await _service.GetReport(filter));
        }

        [HttpPost]
        public async Task<IEnumerable<OrderView>> Get(FilterModel filter)
            => _mapper.Map<IEnumerable<OrderView>>(await _service.GetReport(filter));

    }
}