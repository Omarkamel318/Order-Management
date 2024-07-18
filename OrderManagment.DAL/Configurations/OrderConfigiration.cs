using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.Configurations
{
	internal class OrderConfigiration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(o => o.Status).HasConversion(
				(o) => o.ToString(),
				(o) => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
				);

			builder.Property(o => o.PaymentMethod).HasConversion(
				(o) => o.ToString(),
				(o) => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), o)
				);
		}
	}
}
