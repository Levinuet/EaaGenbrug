using MongoDB.Driver;

namespace ServerAPI.Repositories
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(string connectionString, string dbName)
        {
            var client = new MongoClient("mongodb+srv://nicolaischmidt59:Uct89stc@cluster0.nczpyyv.mongodb.net/");
            Database = client.GetDatabase("Genbrugsmarked");
        }
    }
}