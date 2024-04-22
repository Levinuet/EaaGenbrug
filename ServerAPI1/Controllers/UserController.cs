using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);  // Returns the list of users with a 200 OK status
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if (await _userRepository.CheckUserExists(user.Username))
        {
            return BadRequest("User already exists");
        }

        await _userRepository.CreateUser(user); // No password hashing
        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null || user.Password != password)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok("User logged in successfully");
    }
}
