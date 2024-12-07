using CleanCodeJN.Sample.Models;

namespace CleanCodeJN.Sample.Services;
public interface IMyService
{
    Task AddCustomer(Customer customer);

    Task DeleteCustomer(int customerId);

    List<Customer> GetCustomers();

    Task SaveChangedCustomers();
}
