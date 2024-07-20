using AutoMapper;
using OrderManagment.BLL.DTO;
using OrderManagment.DAL.Models;

namespace OrderManagment.APIs.Helpers
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<OrderReturnDto, Order>().ForMember(d => d.TotalAmount, o => o.MapFrom(o => o.Total));
            CreateMap<Order,OrderToReturnDto>();
            CreateMap<OrderItem,OrderItemDto>();
        }
    }
}
