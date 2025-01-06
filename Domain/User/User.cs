namespace Domain.User;

public class User
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; } = string.Empty;

    public required string LastName { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? LastLoggedInAt { get; set; }
}