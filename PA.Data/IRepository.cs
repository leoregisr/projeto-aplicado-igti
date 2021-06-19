using System.Threading.Tasks;

namespace PA.Data
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Get(object id);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}