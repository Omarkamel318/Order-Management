﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.DTO
{
	public class OrderItemDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Discount { get; set; }

	}
}
