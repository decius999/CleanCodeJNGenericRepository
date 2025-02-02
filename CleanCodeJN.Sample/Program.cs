﻿using CleanCodeJN.Repository.EntityFramework.Extensions;
using CleanCodeJN.Sample;
using CleanCodeJN.Sample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterDbContextAndRepositories<MyDbContext>();
builder.Services.AddScoped<IMyService, MyService>();

var host = builder.Build();
var service = host.Services.GetService<IMyService>();

await service.AddCustomer(new() { Name = "New Customer 1" });
await service.AddCustomer(new() { Name = "New Customer 2" });
await service.AddCustomer(new() { Name = "New Customer 3" });
await service.AddCustomer(new() { Name = "New Customer 4" });

await service.DeleteCustomer(1);
var customers = service.GetCustomers();

var updateCustomer2 = customers.First(x => x.Id == 2);
var updateCustomer3 = customers.First(x => x.Id == 3);
updateCustomer2.Name = "New Customer 2 - Updated";
updateCustomer3.Name = "New Customer 3 - Updated";

await service.SaveChangedCustomers();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.Id} = {customer.Name}");
}

await host.RunAsync();
