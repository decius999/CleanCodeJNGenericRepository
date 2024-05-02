using CleanCodeJN.Repository.EntityFramework.Contracts;
using CleanCodeJN.Sample.Models;

namespace CleanCodeJN.Sample.Services;
public class MyService(IIntRepository<Customer> repository) : IMyService
{
    public List<Customer> GetCustomers() => repository.Query().Where(x => x.Id > 100).ToList();
}
