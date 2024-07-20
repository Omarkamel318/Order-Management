using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.BLL.DTO;
using OrderManagment.BLL.Iservices;
using OrderManagment.BLL.Services;
using OrderManagment.DAL.Models;

namespace OrderManagment.APIs.Controllers
{
    public class OrdersController : BaseAPIController
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrdersController
			(IOrderService orderService,
			IMapper mapper)
        {
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<ActionResult<OrderReturnDto>> CreateOrder(OrderDto order)
		{
			var orderDto = await _orderService.CreateOrder(order);
			var orderToReturnDto =_mapper.Map<OrderToReturnDto>(orderDto) ;
			if (orderToReturnDto is null)
				return BadRequest();
			return Ok(orderToReturnDto);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrder(int id)
		{
			var order = await _orderService.GetOrderAsync(id);
			if (order is null)
				return BadRequest();
			return Ok(_mapper.Map<OrderToReturnDto>(order));
		}

		[HttpGet] //auth
		public async Task<ActionResult<IReadOnlyList<Order>>> GetAllOrders()
		{
			var orders = await _orderService.GetAllOrderAsync();
			return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));

		}

		[HttpPut("{id}/{status}")]
		public async Task<ActionResult<Order>> UpdateStatus(int id, OrderStatus status)
		{
			var order = await _orderService.UpdateStatus(id, status);
			if (order is null)
				return BadRequest();
			return Ok(_mapper.Map<OrderToReturnDto>(order));
		}

	}
}
