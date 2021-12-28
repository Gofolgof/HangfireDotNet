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

    /// <summary>
    /// Создание отложенной фоновой задачи
    /// </summary>
    /// <param name="text">текст для задачи</param>
    /// <param name="minutes">через сколько отправить фоновую задачу</param>
    /// <returns></returns>
    Task<string> CreateDelayBackgroundTask(string text, int minutes);
}