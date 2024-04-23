using Core.Models;
using Microsoft.AspNetCore.Identity;
using ServerAPI.Controllers;

namespace ServerAPI.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRegistration)
        {
            var user = new IdentityUser { UserName = userRegistration.Email, Email = userRegistration.Email };
            return await _userManager.CreateAsync(user, userRegistration.Password);
        }

        public async Task<SignInResult> LoginUserAsync(UserLoginDto userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, false);
            return result;
        }
    }
}
