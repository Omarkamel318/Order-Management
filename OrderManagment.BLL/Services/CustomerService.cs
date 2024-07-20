using OrderManagment.BLL.DTO;
using OrderManagment.BLL.Iservices;
using OrderManagment.DAL.Data;
using OrderManagment.DAL.IRepository;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IGenericRepository<Customer> _customerRepo;
		private readonly ApplicationDbContext _dbContext;
		private readonly IOrderService _orderService;

		public CustomerService(
			IGenericRepository<Customer> customerRepo,
			ApplicationDbContext dbContext,
			IOrderService orderRepo)
        {
			_customerRepo = customerRepo;
			_dbContext = dbContext;
			_orderService = orderRepo;
		}
		public async Task<Customer?> CreateCustomer(Customer customer)
		{
			_customerRepo.Add(customer);
			var result = _dbContext.SaveChanges();
			if (result <= 0)
				return null;
			return customer;
		}

		public async Task<IReadOnlyList<Order>?> GetAllOrdersForCustomer(int customerId)	
			=> await _orderService.GetAllOrdersForCustomer(customerId);
		
	}
}
