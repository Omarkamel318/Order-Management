using Microsoft.EntityFrameworkCore;
using OrderManagment.DAL.Data;
using OrderManagment.DAL.IRepository;
using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
				=> await _dbContext.Set<T>().ToListAsync();
		

		public async Task<T?> GetAsync(int id)
				=>await _dbContext.Set<T>().FindAsync(id);
		

		public void Add(T entity)
				=> _dbContext.Set<T>().Add(entity);
		

		public void Delete(T entity)
				=>_dbContext?.Set<T>().Remove(entity);
		

		public void Update(T entity)
				=>_dbContext.Set<T>().Update(entity);
		
	}
}
