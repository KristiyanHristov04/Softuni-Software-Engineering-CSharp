namespace TaskBoardApp.Models.Task
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Owner { get; set; } = null!;
    }
}
