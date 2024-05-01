namespace CleanCodeJN.Repository.EntityFramework.Contracts;
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
