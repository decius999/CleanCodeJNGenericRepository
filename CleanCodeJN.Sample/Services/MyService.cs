using CleanCodeJN.Repository.EntityFramework.Contracts;
using CleanCodeJN.Sample.Models;

namespace CleanCodeJN.Sample.Services;
public class MyService(IRepository<Customer, int> repository) : IMyService
{
    public Task AddCustomer(Customer customer) => repository.Create(customer, CancellationToken.None);

    public Task DeleteCustomer(int customerId) => repository.Delete(customerId, CancellationToken.None);

    public List<Customer> GetCustomers() => repository.Query(asNoTracking: true, ignoreQueryFilters: true).ToList();

    public async Task SaveChangedCustomers() => await repository.SaveChangedEntities(CancellationToken.None);
}
