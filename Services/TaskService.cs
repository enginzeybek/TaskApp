public class TaskService
{
    private readonly TaskRepository _taskRepository;
    
    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void CreateTask(string title,string description)
    {
        var task = new TaskItem(title,description);

        _taskRepository.AddTask(task);
    }

    public List<TaskItem> GetListTask()
    {
        return _taskRepository.GetListTask();
    }

    public bool CompleteTask(Guid id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task == null)
        {
            return false;
        }
        else
        {
            task.MarkAsCompleted();

            return true;
        }
    }
}