using AutoMapper;
using OrderManagment.BLL.DTO;
using OrderManagment.DAL.Models;

namespace OrderManagment.APIs.Helpers
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<OrderReturnDto, Order>();
        }
    }
}
