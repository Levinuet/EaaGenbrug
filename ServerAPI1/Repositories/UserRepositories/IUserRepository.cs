using Core.Models;
using Microsoft.AspNetCore.Identity;
using ServerAPI.Controllers;

namespace ServerAPI.Repositories.UserRepositories
{
public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRegistration);
        Task<SignInResult> LoginUserAsync(UserLoginDto userLogin);
    }


}