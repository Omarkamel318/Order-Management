using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.DTO
{
	public class OrderToReturnDto
	{
		public int CustomerId { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalAmount { get; set; }
		public ICollection<OrderItemDto> Items { get; set; } = new HashSet<OrderItemDto>();
		public OrderStatus Status { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public decimal Discount { get; set; }
	}
}
