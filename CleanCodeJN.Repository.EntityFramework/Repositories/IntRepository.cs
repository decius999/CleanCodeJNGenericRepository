using CleanCodeJN.Repository.Abstractions.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class IntRepository<TEntity> : Repository<IDataContext, TEntity, int>, IIntRepository<TEntity>
    where TEntity : class, IEntity<int>
{
    public IntRepository(IDataContext context) : base(context)
    {
    }
}
