using OrderManagment.DAL.Models;
using OrderManagment.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.IRepository
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		public Task<IReadOnlyList<Order>> GetAllAsyncWithIncludeItems();
		public Task<Order> GetAsyncWithIncludeItem(int id);

	}
}
