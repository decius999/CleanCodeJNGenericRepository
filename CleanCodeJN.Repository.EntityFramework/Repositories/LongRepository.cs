using CleanCodeJN.Repository.Abstractions.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class LongRepository<TEntity> : Repository<IDataContext, TEntity, long>, ILongRepository<TEntity>
    where TEntity : class, IEntity<long>
{
    public LongRepository(IDataContext context) : base(context)
    {
    }
}
