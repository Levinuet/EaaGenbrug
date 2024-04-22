using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.UserRepositories;

namespace ServerAPI.Controllers
{
    [ApiController]
        [Route("[controller]")]
        public class UserController : ControllerBase
        {
            private readonly IUserRepository _userRepository;
        

        public UserController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] UserRegistrationDto registration)
            {
                var result = await _userRepository.RegisterUserAsync(registration);

                if (result.Succeeded)
                {
                    return Ok("User registered successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] UserLoginDto login)
            {
                var result = await _userRepository.LoginUserAsync(login);

                if (result.Succeeded)
                {
                    return Ok("User logged in successfully.");
                }
                else if (result.IsLockedOut)
                {
                    return BadRequest("User account locked.");
                }
                else
                {
                    return BadRequest("Invalid login attempt.");
                }
            }
        }
}
