using Hackathon.Domain.Interfaces.IRepositories;
using Hackathon.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Infra.Data.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly SQLiteContext _context;
		public BaseRepository(SQLiteContext context)
		{
			_context = context;
		}
		public Task<int> Delete(T entity)
		{
			this._context.Set<T>().Remove(entity);
			return this._context.SaveChangesAsync();
		}

		public IQueryable<T> FindAll()
		{
			return this._context.Set<T>();
		}

		public async Task<T> FindById(int id)
		{
			return await this._context.Set<T>().FindAsync(id);
		}

		public Task<int> Save(T entity)
		{
			this._context.Set<T>().Add(entity);
			return this._context.SaveChangesAsync();
		}

		public Task<int> Update(T entity)
		{
			this._context.Set<T>().Update(entity);
			return this._context.SaveChangesAsync();
		}
	}
}
