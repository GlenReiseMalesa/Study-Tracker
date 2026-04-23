using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Study_Tracker.Models;

namespace Study_Tracker.Data
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
