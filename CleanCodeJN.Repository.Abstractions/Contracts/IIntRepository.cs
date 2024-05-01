namespace CleanCodeJN.Repository.Abstractions.Contracts;
public interface IIntRepository<TEntity> : IRepository<TEntity, int>
      where TEntity : class, IEntity<int>
{
}
