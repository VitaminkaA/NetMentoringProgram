using HttpHandler.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHandler.ConsoleApp
{
    public class Application
    {
        private readonly IOrderService _service;
        public Application(IOrderService service)
            => _service = service;

        public void Run()
        {
            foreach (var order in _service.GetReport(null))
            {
                Console.WriteLine(order.CustomerId);
            }
        }
    }
}
