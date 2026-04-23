using Study_Tracker_BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;


namespace Study_Tracker_BlazorApp.Services;

public class DatabaseService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DatabaseService(IJSRuntime jsRuntime, IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _jsRuntime = jsRuntime;
        _dbContextFactory = dbContextFactory;
    }

    public async Task InitializeDatabaseAsync()
    {
        const string filename = "app.db";

        // 1. Restore existing database from browser cache
        await _jsRuntime.InvokeVoidAsync("blazorSqlite.loadDatabaseFromCache", filename);

        // 2. Create/update database schema
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Database.EnsureCreatedAsync();

        // 3. Save the database to cache (for new or updated databases)
        await _jsRuntime.InvokeVoidAsync("blazorSqlite.syncDatabaseToCache", filename);
    }
}