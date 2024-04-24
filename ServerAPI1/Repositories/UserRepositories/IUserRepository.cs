using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace ServerAPI.Repositories.UserRepositories
{
public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRegistration);
        Task<SignInResult> LoginUserAsync(UserLoginDto userLogin);
    }
}
