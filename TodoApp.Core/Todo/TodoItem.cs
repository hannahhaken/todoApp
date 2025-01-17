namespace TodoApp.Core.Todo;

public sealed class TodoItem
{
    public required string Id { get; set; }
    
    public required string Title { get; set; }

    public string? Description { get; set; }

    public TodoStatus Status { get; set; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required DateTime UpdatedAt { get; set; }
    
    public DateTime? DueAt { get; set; }
    
    public DateTime? CompletedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }

    public required string CreatedById { get; set; }
    
    public string? AssignedToId { get; set; }
    
    public TodoItem(string userId, string title, string? description = null, DateTime? dueAt = null)
    {
        Id = userId;
        Title = title;
        Description = description;
        Status = TodoStatus.Due;
        DueAt = dueAt;
        CreatedAt = DateTime.UtcNow;
        DeletedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }


    public void Complete()
    {
        Status = TodoStatus.Completed;
        CompletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        Status = TodoStatus.Deleted;
        DeletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        Status = TodoStatus.Due;
        DeletedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateTitle(string newTitle)
    {
        Title = newTitle;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDueDate(DateTime newDueDate)
    {
        DueAt = newDueDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsOverdue()
    {
        if (DueAt.HasValue && DueAt.Value < DateTime.UtcNow && Status != TodoStatus.Completed)
        {
            Status = TodoStatus.Overdue;
            UpdatedAt = DateTime.UtcNow;
            // Scheduled job candidate?
        }
    }
}