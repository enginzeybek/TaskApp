public class TaskItem
{
    public Guid TaskItemID { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public TaskItem(string title,string description)
    {
        Title = title;
        Description = description;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}

