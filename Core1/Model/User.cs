namespace Core.Model;

public class User
{
    public string Id { get; set; } // MongoDB unique identifier
    public string Username { get; set; }
    public string Password { get; set; } // Store hashed passwords only
    public string Email { get; set; }
}
