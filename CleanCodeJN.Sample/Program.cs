using CleanCodeJN.Repository.EntityFramework.Extensions;
using CleanCodeJN.Sample;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterDbContextAndRepositories<MyDbContext>();

await builder.Build().RunAsync();
