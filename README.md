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
public class Comment : IEntity<int>
{
    public int Id { get; set; }
}
```

Add IDataContext Interface to your DBContext class:

```C#
public partial class YourContext : DbContext, IDataContext
{   
}
```

Use Extension RegisterRepositories() in your startup class or program.cs:

```C#
using CleanCodeJN.Repository.EntityFramework.Extensions;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register Repositories
builder.Services.RegisterRepositories();

await builder.Build().RunAsync();
```

Inject IRepository<T> in your business layer:

```C#
public class MyService(IIntRepository<Customer> repository)
{   
}
```

Just use it:

```C#
List<customer> customerWhoHavePayed = repository
                                           .Query(x => x.Invoices)
                                           .Where(x => x.Invoice.IsPayed)
                                           .ToList()
```

## License

MIT
