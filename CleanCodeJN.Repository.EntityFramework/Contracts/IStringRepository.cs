namespace CleanCodeJN.Repository.EntityFramework.Contracts;
public interface IStringRepository<TEntity> : IRepository<TEntity, string>
      where TEntity : class, IEntity<string>
{
}
