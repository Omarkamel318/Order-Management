using OrderManagment.BLL.DTO;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.Iservices
{
    public interface IOrderService
    {
		public Task<OrderReturnDto?> CreateOrder(OrderDto orderDto);
		public Task<Order> GetOrderAsync(int id);
		public Task<IReadOnlyList<Order>> GetAllOrderAsync();//Auth

		public Task<Order?> UpdateStatus(int id, OrderStatus status);





	}
}
