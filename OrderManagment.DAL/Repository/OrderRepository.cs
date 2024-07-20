using Microsoft.EntityFrameworkCore;
using OrderManagment.DAL.Data;
using OrderManagment.DAL.IRepository;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.Repository
{
	public class OrderRepository : GenericRepository<Order> , IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
			_dbContext = dbContext;
		}

		public async Task<IReadOnlyList<Order>> GetAllAsyncWithIncludeItems()
				=> await _dbContext.Set<Order>().Include(o => o.Items).ToListAsync();



		public async Task<Order> GetAsyncWithIncludeItem(int id)
			=> await _dbContext.Set<Order>().Where(o=>o.Id==id).Include(o => o.Items).FirstOrDefaultAsync();
	}
}
