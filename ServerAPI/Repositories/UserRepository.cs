using Core.Model;
using MongoDB.Driver;
using System.Threading.Tasks;
using static ServerAPI1.Program;

namespace ServerAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        // Constructor that initializes the UserRepository with the MongoDB context
        public UserRepository(MongoDbContext context)
        {
            _users = context.Database.GetCollection<User>("Users");
        }

        // Retrieves a user based on their username from the MongoDB collection
        public async Task<User> GetUserByUsername(string username)
        {
            return await _users.Find(user => user.Username == username).FirstOrDefaultAsync();
        }

        // Inserts a new user into the MongoDB collection
        public async Task CreateUser(User user)
        {
            await _users.InsertOneAsync(user);
        }

        // Checks if a user exists in the MongoDB collection based on the username
        public async Task<bool> CheckUserExists(string username)
        {
            return await _users.Find(user => user.Username == username).AnyAsync();
        }

        // Retrieves all users from the MongoDB collection
        public async Task<List<User>> GetAllUsers()
        {
            return await _users.Find(_ => true).ToListAsync();
        }
    }
}
