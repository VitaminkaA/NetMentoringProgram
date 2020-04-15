using AutoMapper;
using HttpHandler.DAL.Entities;
using HttpHandler.WebApp.View;

namespace HttpHandler.WebApp.Mapping
{
    public class OrderViewProfile : Profile
    {
        public OrderViewProfile()
        {
            CreateMap<Order, OrderView>()
                .ForMember(c=>c.OrderId, o=>o.MapFrom(c=>c.Id));
        }
    }
}
