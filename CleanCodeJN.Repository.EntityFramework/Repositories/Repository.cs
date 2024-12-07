using System.Linq.Expressions;
using CleanCodeJN.Repository.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    protected readonly DbContext _context;
    private IDbContextTransaction _transaction;

    public Repository(IDataContext context) => _context = context as DbContext;

    public IQueryable<TEntity> RawSQL(string sql) => _context.Set<TEntity>().FromSqlRaw(sql);

    public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes?.Any() == true)
        {
            query = query.AsSplitQuery();
        }

        foreach (var includeExpression in includes)
        {
            query = query.Include(includeExpression);
        }

        return query;
    }

    public IQueryable<TEntity> Query(bool asNoTracking = false, bool ignoreQueryFilters = false, bool asSplitQuery = false, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters();
        }

        if (asSplitQuery)
        {
            query = query.AsSplitQuery();
        }

        foreach (var includeExpression in includes)
        {
            query = query.Include(includeExpression);
        }

        return query;
    }

    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<List<TEntity>> Create(List<TEntity> entities, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().AddRange(entities);
        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public async Task<TEntity> Delete(TKey id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);

        if (entity == null)
        {
            return entity;
        }

        _context.Set<TEntity>().Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<int> Delete(IEnumerable<TKey> ids, CancellationToken cancellationToken)
    {
        var entities = new List<TEntity>();

        foreach (var id in ids)
        {
            entities.Add(await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken));
        }

        _context.Set<TEntity>().RemoveRange(entities.Where(x => x != null));

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveTrackedEntities(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

    public async Task BeginTransaction() => _transaction = await _context.Database.BeginTransactionAsync();

    public async Task CommitTransaction() => await _transaction.CommitAsync();
}
