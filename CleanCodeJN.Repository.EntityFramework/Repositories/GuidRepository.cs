using CleanCodeJN.Repository.Abstractions.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class GuidRepository<TEntity> : Repository<IDataContext, TEntity, Guid>, IGuidRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    public GuidRepository(IDataContext context) : base(context)
    {
    }
}
