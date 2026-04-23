using Microsoft.EntityFrameworkCore;
using Study_Tracker_BlazorApp.Data;

namespace Study_Tracker_BlazorApp.Services;

public class DatabaseService
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DatabaseService(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task InitializeDatabaseAsync()
    {
        try
        {
            Console.WriteLine("=== Starting Database Initialization ===");

            // Create database and tables
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            var created = await context.Database.EnsureCreatedAsync();
            Console.WriteLine($"Database created/checked: {created}");

            // Add sample data if this is a new database
            if (created)
            {
                Console.WriteLine("Adding sample data...");
                if (!await context.TaskItems.AnyAsync())
                {
                    context.TaskItems.AddRange(
                        new Models.TaskItem { Title = "Learn Blazor WASM", IsCompleted = false, CreatedAt = DateTime.Now },
                        new Models.TaskItem { Title = "Build a study tracker", IsCompleted = false, CreatedAt = DateTime.Now },
                        new Models.TaskItem { Title = "Master SQLite", IsCompleted = false, CreatedAt = DateTime.Now }
                    );
                    await context.SaveChangesAsync();
                    Console.WriteLine(" Sample data added");
                }
            }

            // Verify table exists
            var tableExists = await context.Database.ExecuteSqlRawAsync(
                "SELECT name FROM sqlite_master WHERE type='table' AND name='TaskItems'");
            Console.WriteLine($"Table verification completed");

            Console.WriteLine("=== Database Initialization Complete ===");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Database initialization failed: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            throw;
        }
    }
}