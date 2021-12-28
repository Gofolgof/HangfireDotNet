using HangfireForDotNet.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace HangfireForDotNet.Controllers;

/// <summary>
/// Контроллер по работе с Hangfire
/// </summary>
[Route("/Hangfire")]
public class HangfireControllers : ControllerBase
{
    /// <inheritdoc cref="IBackgroundTaskService"/>
    private readonly IBackgroundTaskService _backgroundTask;

    
    public HangfireControllers(IBackgroundTaskService backgroundTask)
    {
        _backgroundTask = backgroundTask;
    }


    /// <summary>
    /// Создание быстрой фоновой задачи
    /// </summary>
    [HttpPost("CreateQuickBackgroundTask/{name}")]
    public Task<string> CreateQuickBackgroundTask([FromRoute]string name)
    {
        return _backgroundTask.CreateQuickBackgroundTask(name);
    }
}