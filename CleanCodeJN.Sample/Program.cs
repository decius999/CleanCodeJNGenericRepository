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

service.GetCustomers();

await host.RunAsync();
