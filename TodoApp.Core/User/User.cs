namespace TodoApp.Core.User;

public class User
{
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? LastLoggedInAt { get; private set; }

    public User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateFirstName(string newFirstName)
    {
        FirstName = newFirstName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLastName(string newLastName)
    {
        FirstName = newLastName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePassword(string newPassword)
    {
        Password = newPassword;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLastLoggedInAt()
    {
        LastLoggedInAt = DateTime.UtcNow;
    }
}