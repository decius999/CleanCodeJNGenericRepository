using CleanCodeJN.Repository.EntityFramework.Contracts;
using CleanCodeJN.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeJN.Sample;
public class MyDbContext : DbContext, IDataContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("MyDatabase");

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Customer)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[nameof(Customer.IsDeleted)] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(Customer.IsDeleted)] = true;
                        break;
                }
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
