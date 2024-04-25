using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task CreateUser(User user);
        Task<bool> CheckUserExists(string username);
        Task<List<User>> GetAllUsers();
    }
}
