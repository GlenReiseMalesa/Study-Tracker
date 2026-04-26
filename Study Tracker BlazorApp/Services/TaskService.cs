using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using Study_Tracker_BlazorApp.Data;
using Study_Tracker_BlazorApp.Models;

namespace Study_Tracker_BlazorApp.Services
{
    //Contains our CRUD functions
    public class TaskService
    {
        private readonly ISqliteWasmDbContextFactory<AppDbContext> _dbContextFactory;


        public TaskService(ISqliteWasmDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // READ : Get single taskitem
        public async Task<TaskItem?> GetTaskItemsByIdAsync(int Id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.TaskItems.FirstOrDefaultAsync(t => t.Id == Id);
        }


        //DELETE : delete a taskitem
        public async Task<bool> DeleteTaskAsync(int id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var TaskItem = await context.TaskItems.FindAsync(id);
            if (TaskItem == null) return false;

            context.TaskItems.Remove(TaskItem);
            await context.SaveChangesAsync();
            return true;
        }

        //UPDATE : update a taskitem
        public async Task<bool> UpdateTaskAsync(int id, string newTitle, string newSubject, string newEstimatedTime, string newPriority, string newNotes, bool newIsComplete)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var TaskItem = await context.TaskItems.FindAsync(id);
            if (TaskItem == null) return false;

            TaskItem.Title = newTitle;
            TaskItem.CreatedAt = DateTime.Now;
            TaskItem.Subject = newSubject;
            TaskItem.Notes = newNotes;
            TaskItem.EstimatedTime = newEstimatedTime;
            TaskItem.Priority = newPriority;
            TaskItem.IsCompleted = newIsComplete;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
