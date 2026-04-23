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
// Register DbContext Factory (REQUIRED for WebAssembly)
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Register our database service
builder.Services.AddScoped<DatabaseService>();
//DB code

await builder.Build().RunAsync();



