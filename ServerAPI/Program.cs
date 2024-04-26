using MongoDB.Driver;
using ServerAPI.Repositories;

namespace ServerAPI1
{
    public class Program
    {
        // Main entry point for the application
        public static void Main(string[] args)
        {
            // Creates and configures a new web application builder
            var builder = WebApplication.CreateBuilder(args);

            // Configures an HTTP client named 'MyClient' with a specific base address
            builder.Services.AddHttpClient("MyClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7052/");
            });

            // Registers a singleton MongoDbContext configured from application settings
            builder.Services.AddSingleton(sp => new MongoDbContext(
                builder.Configuration["MongoDB:ConnectionString"],
                builder.Configuration["MongoDB:DatabaseName"]
            ));

            // Dependency injection for repository classes
            builder.Services.AddSingleton<IAdRepository, AdRepositoryMongoDB>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Adds support for Razor Pages and Server-Side Blazor
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Adds MVC Controllers to the application
            builder.Services.AddControllers();

            // Configures CORS to allow any origin, method, and header
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });

            // Builds the web application
            var app = builder.Build();

            // Configures middleware for authorization
            app.UseAuthorization();

            // Maps controller routes and Blazor hub connections
            app.MapControllers();
            app.MapBlazorHub();

            // Runs the web application
            app.Run();
        }

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
}
