using System.ComponentModel.DataAnnotations;

namespace Domain;

public enum TodoStatus
{
    None = 0,
    Due = 1,
    Overdue = 2,
    Completed = 3,
    Deleted = 99
}

public class TodoItem
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(64, MinimumLength = 10)]
    public required string Title { get; set; }

    public string? Description { get; set; }

    public TodoStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid UserId { get; set; }
}