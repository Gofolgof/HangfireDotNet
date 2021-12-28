using Hangfire;
using HangfireForDotNet.Infrastructure.Abstractions;

namespace HangfireForDotNet.Infrastructure.Services;

/// <inheritdoc cref="IBackgroundTaskService"/>
public class BackgroundTaskService : IBackgroundTaskService
{
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<BackgroundTaskService> _logger;

    
    public BackgroundTaskService(ILogger<BackgroundTaskService> logger)
    {
        _logger = logger;
    }

    
    /// <inheritdoc cref="IBackgroundTaskService.CreateQuickBackgroundTask"/>
    public Task<string> CreateQuickBackgroundTask(string name)
    {
        var textForMessage = $"Hello {name}";
        var jobId = BackgroundJob.Enqueue(() => Console.WriteLine(textForMessage));
        _logger.LogInformation($"Job with id - {jobId} completed");

        return Task.FromResult(jobId);
    }
}