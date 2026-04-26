namespace Study_Tracker_BlazorApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? EstimatedTime { get; set; }
        public string? Priority { get; set; }
        public string? Notes { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
