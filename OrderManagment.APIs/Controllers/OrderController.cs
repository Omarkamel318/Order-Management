using Microsoft.AspNetCore.Mvc;
using OrderManagment.BLL.DTO;
using OrderManagment.BLL.Iservices;
using OrderManagment.BLL.Services;

namespace OrderManagment.APIs.Controllers
{
    public class OrderController : BaseAPIController
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
        {
			_orderService = orderService;
		}

        [HttpPost]
		public async Task<ActionResult<OrderReturnDto>> CreateOrder(OrderDto order)
		{
			var orderDto = await _orderService.CreateOrder(order);
			if (orderDto is null)
				return BadRequest();
			return Ok(orderDto);
		}
		
	}
}
