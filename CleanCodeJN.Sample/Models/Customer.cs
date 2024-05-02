using CleanCodeJN.Repository.EntityFramework.Contracts;

namespace CleanCodeJN.Sample.Models;
public class Customer : IEntity<int>
{
    public int Id { get; set; }
}
