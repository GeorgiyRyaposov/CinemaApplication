using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class Extensions
{
    public static void AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<ICinemaService, CinemaService>();
    }
}