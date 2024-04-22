using Core.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ServerAPI.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbContext context)
        {
            _users = context.Database.GetCollection<User>("Users");
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _users.Find(user => user.Username == username).FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<bool> CheckUserExists(string username)
        {
            return await _users.Find(user => user.Username == username).AnyAsync();
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _users.Find(_ => true).ToListAsync();
        }
    }
}
