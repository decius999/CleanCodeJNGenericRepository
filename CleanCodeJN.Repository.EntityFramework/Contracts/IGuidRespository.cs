namespace CleanCodeJN.Repository.EntityFramework.Contracts;
public interface IGuidRepository<TEntity> : IRepository<TEntity, Guid>
      where TEntity : class, IEntity<Guid>
{
}
