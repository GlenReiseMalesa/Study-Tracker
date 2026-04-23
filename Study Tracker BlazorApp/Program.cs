using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Study_Tracker_BlazorApp.Data;
using Study_Tracker_BlazorApp.Services;
using Study_Tracker_BlazorApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//DB code
try
{
    // Your service registration
    builder.Services.AddDbContextFactory<AppDbContext>(options =>
        options.UseSqlite("Data Source=app.db"));
    builder.Services.AddScoped<DatabaseService>();
    builder.Services.AddScoped<TaskService>();
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



