namespace TodoApp.Core.Todo;

public sealed class TodoItem
{
    /// <summary>
    /// Gets or sets the UUID for the todo item.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the Todo item.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Represents an optional detailed description of the Todo item.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the current state of the Todo item.
    /// </summary>
    /// <remarks>
    /// This property indicates the status of the Todo item, which can be one of the predefined values in the <see cref="TodoStatus"/> enum.
    /// The status can signify whether the item is due, overdue, completed, deleted, or unset (None).
    /// </remarks>
    public TodoStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the Todo item was created.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the <see cref="Todo"/> item was last updated.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the optional due date and time for the associated Todo item.
    /// </summary>
    /// <remarks>
    /// When set, this indicates the deadline by which the Todo item should ideally be completed.
    /// If null, the item does not have a specified due date.
    /// </remarks>
    public DateTime? DueAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the to-do item was marked as completed.
    /// </summary>
    /// <remarks>
    /// This property is nullable and will have a value only if the item's status is set to <see cref="TodoStatus.Completed"/>.
    /// </remarks>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Represents the timestamp at which the to-do item was marked as deleted.
    /// This property is null if the to-do item has not been deleted.
    /// </summary>
    /// <remarks>
    /// Useful for implementing soft-delete functionality by storing the deletion time
    /// instead of permanently removing the item from the database.
    /// </remarks>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who created the to-do item.
    /// </summary>
    public required string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user to whom the todo item is assigned.
    /// </summary>
    public string? AssignedToId { get; set; }

    /// <summary>
    /// Represents a to-do item entity in the application domain.
    /// </summary>
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

    //
    // public void Complete()
    // {
    //     Status = TodoStatus.Completed;
    //     CompletedAt = DateTime.UtcNow;
    //     UpdatedAt = DateTime.UtcNow;
    // }
    //
    // public void Delete()
    // {
    //     Status = TodoStatus.Deleted;
    //     DeletedAt = DateTime.UtcNow;
    //     UpdatedAt = DateTime.UtcNow;
    // }
    //
    // public void Restore()
    // {
    //     Status = TodoStatus.Due;
    //     DeletedAt = null;
    //     UpdatedAt = DateTime.UtcNow;
    // }
    //
    public void UpdateTitle(string newTitle)
    {
        Title = newTitle;
        UpdatedAt = DateTime.UtcNow;
    }
    //
    // public void UpdateDescription(string newDescription)
    // {
    //     Description = newDescription;
    //     UpdatedAt = DateTime.UtcNow;
    // }
    //
    // public void UpdateDueDate(DateTime newDueDate)
    // {
    //     DueAt = newDueDate;
    //     UpdatedAt = DateTime.UtcNow;
    // }
    //
    // public void MarkAsOverdue()
    // {
    //     if (DueAt.HasValue && DueAt.Value < DateTime.UtcNow && Status != TodoStatus.Completed)
    //     {
    //         Status = TodoStatus.Overdue;
    //         UpdatedAt = DateTime.UtcNow;
    //         // Scheduled job candidate?
    //     }
    // }
}