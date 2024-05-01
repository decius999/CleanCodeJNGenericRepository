namespace CleanCodeJN.Repository.Abstractions.Contracts;
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
