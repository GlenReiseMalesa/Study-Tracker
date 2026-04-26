using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using Study_Tracker_BlazorApp;
using Study_Tracker_BlazorApp.Data;
using Study_Tracker_BlazorApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//DB code
try
{
    // Your service registration
    builder.Services.AddSqliteWasmDbContextFactory<AppDbContext>(
        opts => opts.UseSqlite("Data Source=app.db"));
    builder.Services.AddScoped<TaskService>();
    builder.Services.AddScoped<DatabaseService>();

 
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    var host = builder.Build();

    // Add global error handling
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Application starting...");

    //await host.RunAsync();
    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"FATAL ERROR: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
    throw;
}
//DB code

//await builder.Build().RunAsync();



