using Core.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Org.BouncyCastle.Crypto.Generators;
using ServerAPI.Repositories;
using static Core.Model.User;
using static ServerAPI1.Program;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly IMongoDatabase _database;

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");


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
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (await _userRepository.CheckUserExists(dto.Username))
        {
            return BadRequest("User already exists");
        }

        var user = new User
        {
            Username = dto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Email = dto.Email // if applicable
        };

        await _userRepository.CreateUser(user);
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

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        await _userRepository.CreateUser(user);
        return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
    }
}
