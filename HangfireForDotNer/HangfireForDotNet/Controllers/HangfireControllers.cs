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

    /// <summary>
    /// Создание отложенной фоновой задачи
    /// </summary>
    /// <param name="text">текст для сообщения</param>
    /// <param name="minutes">через сколько отправить фоновую задачу</param>
    /// <returns></returns>
    [HttpPost("DelayBackgroundTask/{text}/{minutes}")]
    public Task<string> CreateDelayBackgroundTask([FromRoute] string text, [FromRoute] int minutes)
    {
        return _backgroundTask.CreateDelayBackgroundTask(text, minutes);
    }
}