
using CleanCodeJN.Repository.EntityFramework.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class GuidRepository<TEntity> : Repository<TEntity, Guid>, IGuidRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    public GuidRepository(IDataContext context) : base(context)
    {
    }
}
