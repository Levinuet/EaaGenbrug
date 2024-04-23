namespace Core.Model;

public class User
{
    public string Id { get; set; } // MongoDB unique identifier
    public string Username { get; set; }
    public string Password { get; set; } // Store hashed passwords only
    public string Email { get; set; }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } // if applicable
    }

}
