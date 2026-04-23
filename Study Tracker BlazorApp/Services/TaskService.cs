using Microsoft.EntityFrameworkCore;
using Study_Tracker_BlazorApp.Data;
using Study_Tracker_BlazorApp.Models;

namespace Study_Tracker_BlazorApp.Services
{
    //Contains our CRUD functions
    public class TaskService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;


        public TaskService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // READ : Get all tasks
        public async Task<List<TaskItem>> GetAllTaskItemsAsync()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.TaskItems.OrderByDescending(static T => T.CreatedAt).ToListAsync();
        }
        

        //CREATE : add new taskitem
        public async Task<TaskItem> CreateTaskItemAsync(TaskItem TaskItem)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            context.TaskItems.Add(TaskItem);
            await context.SaveChangesAsync();
            return TaskItem;
        }
    }
}
