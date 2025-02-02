﻿using System.Linq.Expressions;

namespace CleanCodeJN.Repository.EntityFramework.Contracts;
public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    IQueryable<TEntity> RawSQL(string sql);

    IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> Query(bool asNoTracking = false, bool ignoreQueryFilters = false, bool asSplitQuery = false, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);

    Task<List<TEntity>> Create(List<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> Delete(TKey id, CancellationToken cancellationToken);

    Task<int> Delete(IEnumerable<TKey> ids, CancellationToken cancellationToken);

    Task SaveChangedEntities(CancellationToken cancellationToken);

    Task BeginTransaction();

    Task CommitTransaction();
}
