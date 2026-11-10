using Microsoft.Extensions.DependencyInjection;

namespace GlycemicIndex.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    { 
        services.AddScoped<IMealCategoriesService, MealCategoriesService>();

        return services;
    }
}