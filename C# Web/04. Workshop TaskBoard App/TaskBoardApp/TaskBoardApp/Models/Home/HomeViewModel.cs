namespace TaskBoardApp.Models.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }
        public List<HomeBoardModel> BoardsWithTasksCount { get; init; } = null!;
        public int UserTasksCount { get; set; }
    }
}
