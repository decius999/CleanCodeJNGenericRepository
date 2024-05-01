using CleanCodeJN.Repository.Abstractions.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class StringRepository<TEntity> : Repository<IDataContext, TEntity, string>, IStringRepository<TEntity>
    where TEntity : class, IEntity<string>
{
    public StringRepository(IDataContext context) : base(context)
    {
    }
}
