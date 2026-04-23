using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Study_Tracker_BlazorApp.Models;

namespace Study_Tracker_BlazorApp.Data
{
    //DbContext is the database connection manager
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }

        //DbSet<TaskItem> represents TaskItems table in our database
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
