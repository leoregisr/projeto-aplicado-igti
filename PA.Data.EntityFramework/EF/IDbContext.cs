using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public interface IDbContext : IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache,
		IDbContextPoolable
	{
		ChangeTracker ChangeTracker { get; }
		DatabaseFacade Database { get; }
		IModel Model { get; }
		EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;

		ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(
			TEntity entity,
			CancellationToken cancellationToken = default(CancellationToken))
			where TEntity : class;

		void AddRange(params object[] entities);
		Task AddRangeAsync(params object[] entities);
		EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
		void AttachRange(params object[] entities);

		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		EntityEntry Entry(object entity);
		object Find(Type entityType, params object[] keyValues);

		TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);

        ValueTask<object> FindAsync(
			Type entityType,
			object[] keyValues,
			CancellationToken cancellationToken);

        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(
			object[] keyValues,
			CancellationToken cancellationToken)
			where TEntity : class;
		
	
		EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
		void RemoveRange(params object[] entities);
		void RemoveRange(IEnumerable<object> entities);

		int SaveChanges();
		int SaveChanges(bool acceptAllChangesOnSuccess);
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

		Task<int> SaveChangesAsync(
			bool acceptAllChangesOnSuccess,
			CancellationToken cancellationToken = default(CancellationToken));

		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
		EntityEntry Update(object entity);
		void UpdateRange(params object[] entities);
		void UpdateRange(IEnumerable<object> entities);
	}
}