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
            CreateMap<OrderReturnDto,OrderToReturnDto>();
            CreateMap<CustomerDto,Customer>();
            CreateMap<OrderItem,OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
