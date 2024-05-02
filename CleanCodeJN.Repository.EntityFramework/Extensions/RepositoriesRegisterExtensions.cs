using CleanCodeJN.Repository.EntityFramework.Contracts;
using CleanCodeJN.Repository.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeJN.Repository.EntityFramework.Extensions;
public static class RepositoriesRegisterExtensions
{
    /// <summary>
    /// Register DbContext and generic Repositories.
    /// </summary>
    /// <typeparam name="TDataContext">DbContext which inherits from IDataContext interface</typeparam>
    /// <param name="services">IServiceCollection</param>
    public static void RegisterDbContextAndRepositories<TDataContext>(this IServiceCollection services)
        where TDataContext : class, IDataContext
    {
        services.AddScoped<IDataContext, TDataContext>();
        services.AddScoped<TDataContext>();

        services.AddScoped(typeof(IIntRepository<>), typeof(IntRepository<>));
        services.AddScoped(typeof(IStringRepository<>), typeof(StringRepository<>));
        services.AddScoped(typeof(ILongRepository<>), typeof(LongRepository<>));
        services.AddScoped(typeof(IGuidRepository<>), typeof(GuidRepository<>));
    }
}
