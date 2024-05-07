using CleanCodeJN.Repository.EntityFramework.Contracts;

namespace CleanCodeJN.Repository.EntityFramework.Repositories;
public class StringRepository<TEntity> : Repository<TEntity, string>, IStringRepository<TEntity>
    where TEntity : class, IEntity<string>
{
    public StringRepository(IDataContext context) : base(context)
    {
    }
}
