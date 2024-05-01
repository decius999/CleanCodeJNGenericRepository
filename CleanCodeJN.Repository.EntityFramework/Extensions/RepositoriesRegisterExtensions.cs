using CleanCodeJN.Repository.Abstractions.Contracts;
using CleanCodeJN.Repository.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeJN.Repository.EntityFramework.Extensions;
public static class RepositoriesRegisterExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IIntRepository<>), typeof(IntRepository<>));
        services.AddScoped(typeof(IStringRepository<>), typeof(StringRepository<>));
        services.AddScoped(typeof(ILongRepository<>), typeof(LongRepository<>));
        services.AddScoped(typeof(IGuidRepository<>), typeof(GuidRepository<>));
    }
}
