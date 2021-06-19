using System.Threading.Tasks;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public abstract class RepositoryBase<T> : IRepository<T> where T : class
	{
		protected IDbContext Context { get; }

		protected RepositoryBase(IDbContext context)
		{
			Context = context;
		}

		public virtual async Task<T> AddAsync(T entity)
		{
			var result = await Context.AddAsync(entity);
			await Context.SaveChangesAsync();
            return result.Entity;
		}

		public T Get(object id)
		{
			return Context.Find<T>(id);
		}

		public virtual async Task RemoveAsync(T entity)
		{
			Context.Remove(entity);
			await Context.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(T entity)
		{
			Context.Update(entity);
			await Context.SaveChangesAsync();
		}
	}
}
