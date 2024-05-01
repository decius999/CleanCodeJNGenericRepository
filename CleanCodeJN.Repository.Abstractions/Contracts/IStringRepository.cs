namespace CleanCodeJN.Repository.Abstractions.Contracts;
public interface IStringRepository<TEntity> : IRepository<TEntity, string>
      where TEntity : class, IEntity<string>
{
}
