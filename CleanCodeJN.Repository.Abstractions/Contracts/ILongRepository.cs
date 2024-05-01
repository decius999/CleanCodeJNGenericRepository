namespace CleanCodeJN.Repository.Abstractions.Contracts;
public interface ILongRepository<TEntity> : IRepository<TEntity, long>
      where TEntity : class, IEntity<long>
{
}
