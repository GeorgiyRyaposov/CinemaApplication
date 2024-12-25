using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static void AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<ICinemaRepository, CinemaRepository>();
    }
}