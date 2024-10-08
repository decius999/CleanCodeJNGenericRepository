using CleanCodeJN.Repository.EntityFramework.Extensions;
using CleanCodeJN.Sample;
using CleanCodeJN.Sample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterDbContextAndRepositories<MyDbContext>();
builder.Services.AddScoped<IMyService, MyService>();

var host = builder.Build();
var service = host.Services.GetService<IMyService>();

await service.AddCustomer(new() { Name = "New Customer" });
await service.DeleteCustomer(1);
var customers = service.GetCustomers();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.Id} = {customer.Name}");
}

await host.RunAsync();
