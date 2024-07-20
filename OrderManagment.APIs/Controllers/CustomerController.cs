using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.BLL.DTO;
using OrderManagment.BLL.Iservices;
using OrderManagment.DAL.Models;

namespace OrderManagment.APIs.Controllers
{
	public class CustomerController : BaseAPIController
	{
		private readonly ICustomerService _customerService;
		private readonly IMapper _mapper;

		public CustomerController(
			ICustomerService customerService,
			IMapper mapper)
		{
			_customerService = customerService;
			_mapper = mapper;
		}
		[HttpPost]
		public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customer)
			 => ((await _customerService.CreateCustomer(_mapper.Map<Customer>(customer))) is not null) ? Ok(_mapper.Map<Customer>(customer)) : BadRequest();

		[HttpGet("{CustomerId}/orders")]
		public async Task<ActionResult<IReadOnlyList<Order>>?> GetAllOrdersForCustomer(int CustomerId)
		{
			var orders = await _customerService.GetAllOrdersForCustomer(CustomerId);
			return (orders is not null) ? Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders)) : NotFound();
		}
	}
}
