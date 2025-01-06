using System.ComponentModel.DataAnnotations;

namespace Domain;

public class TodoItem
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(64, MinimumLength = 10)]
    public required string Title { get; set; }

    public string? Description { get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid UserId { get; set; }
}