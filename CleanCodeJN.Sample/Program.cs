using CleanCodeJN.Repository.EntityFramework.Extensions;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterRepositories();

await builder.Build().RunAsync();
