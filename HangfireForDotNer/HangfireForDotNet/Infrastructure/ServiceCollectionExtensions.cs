using HangfireForDotNet.Infrastructure.Abstractions;
using HangfireForDotNet.Infrastructure.Services;

namespace HangfireForDotNet.Infrastructure;

/// <summary>
/// Класс расширения коллекции сервисов
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавление инфраструктурного слоя слоя
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBackgroundTaskService, BackgroundTaskService>();
        
        return services;
    }
}