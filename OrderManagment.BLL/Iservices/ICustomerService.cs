using OrderManagment.BLL.DTO;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.Iservices
{
	public interface ICustomerService
	{
		public Task<Customer?> CreateCustomer(Customer customer);
		public Task<IReadOnlyList<Order>?> GetAllOrdersForCustomer(int customerId);

	}
}
