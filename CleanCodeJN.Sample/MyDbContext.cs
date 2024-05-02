using CleanCodeJN.Repository.EntityFramework.Contracts;
using CleanCodeJN.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeJN.Sample;
public class MyDbContext : DbContext, IDataContext
{
    public DbSet<Customer> Customers { get; set; }
}
