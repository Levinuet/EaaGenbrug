using System.ComponentModel.DataAnnotations;

namespace Core.Model;

public class User
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

public class RegisterDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}


