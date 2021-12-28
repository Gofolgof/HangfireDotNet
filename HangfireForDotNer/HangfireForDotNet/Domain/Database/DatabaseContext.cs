using Microsoft.EntityFrameworkCore;

namespace HangfireForDotNet.Domain.Database;

/// <summary>
/// Контекст базы данных
/// </summary>
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }
}