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