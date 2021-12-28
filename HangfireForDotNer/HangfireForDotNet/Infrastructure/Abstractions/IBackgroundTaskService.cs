namespace HangfireForDotNet.Infrastructure.Abstractions;

/// <summary>
/// Сервис по работе с фоновыми задачами
/// </summary>
public interface IBackgroundTaskService
{
    /// <summary>
    /// Создание быстрой фоновой задачи
    /// </summary>
    /// <param name="name">имя</param>
    /// <returns></returns>
    Task<string> CreateQuickBackgroundTask(string name);
}