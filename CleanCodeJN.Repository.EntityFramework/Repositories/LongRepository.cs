using CleanCodeJN.Repository.EntityFramework.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class LongRepository<TEntity> : Repository<TEntity, long>, ILongRepository<TEntity>
    where TEntity : class, IEntity<long>
{
    public LongRepository(IDataContext context) : base(context)
    {
    }
}
