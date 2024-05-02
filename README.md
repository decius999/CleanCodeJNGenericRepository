# Generic Repository Implementation
## _Repository Abstraction for Entity Framework_

This generic Repository implementation for Entity Framework abstracts completely all EF-References from your business layer in a domain driven design manner.

## Features

- Ready to use in seconds
- Abstracts all EF specific Code out of your business layer
- Easy to mock and test
- On latest .NET 8.0

## How to use

- Add IEntity<T> interfaces to your domain classes
- Add IDataContext Interface to your DBContext class
- Use Extension RegisterRepositories() in your startup class or program.cs
- Inject IRepository<T> in your business layer
- Just use It

### Step by step explanation

Add IEntity<T> interfaces to your domain classes:

```C#
public class Customer : IEntity<int>
{
    public int Id { get; set; }
}
```

Add IDataContext Interface to your DBContext class:

```C#
public partial class MyDbContext : DbContext, IDataContext
{   
}
```

Use Extension RegisterDbContextAndRepositories() in your startup class or program.cs:

```C#
// Just register generic repositories and your dbContext which has the IDataContext marker interface
builder.Services.RegisterDbContextAndRepositories<MyDbContext>();
```

Inject IIntRepository<T> (or IStringRepository, IGuidRepository, ILongRepository) in your business layer:

```C#
public class MyService(IIntRepository<Customer> repository)
{   
}
```

Just use it:

```C#
List<customer> customerWhoHavePayed = repository
                            .Query(x => x.Invoices) // Use to Include dependent tables, e.g: Invoices
                            .Where(x => x.Invoice.IsPayed)
                            .ToList()
```
