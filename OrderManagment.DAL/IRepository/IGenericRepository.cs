using OrderManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.IRepository
{
	public interface IGenericRepository<T> where T : BaseEntity //primary=>special constrains
	{
		public Task<IReadOnlyList<T>> GetAllAsync();

		public Task<T?> GetAsync(int id);
		void Add(T entity);

		void Update(T entity);

		void Delete(T entity);
	}
}
