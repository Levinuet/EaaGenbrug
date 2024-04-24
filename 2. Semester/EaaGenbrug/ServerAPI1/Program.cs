using MongoDB.Driver;
using ServerAPI.Repositories;


namespace ServerAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           builder.Services.AddHttpClient("MyClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7052/");
            });


            // Add services to the container.
            builder.Services.AddSingleton(sp => new MongoDbContext(
                builder.Configuration["MongoDB:ConnectionString"],
                builder.Configuration["MongoDB:DatabaseName"]
            ));
            builder.Services.AddSingleton<IAdRepository, AdRepositoryMongoDB>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddControllers();

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
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAuthorization();
            app.MapControllers();
            app.MapBlazorHub();

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
