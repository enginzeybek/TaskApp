public class TaskRepository
{
    private readonly List<TaskItem> _tasks = new(); //new List<TaskItem>();

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }

    public List<TaskItem> GetListTask()
    {
        return _tasks;
    }

    public TaskItem? GetTaskById(Guid id)
    {
        return _tasks.FirstOrDefault(x => x.TaskItemID == id);
    }
}