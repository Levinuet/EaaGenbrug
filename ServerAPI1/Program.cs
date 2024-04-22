using ServerAPI.Repositories;

namespace ServerAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(builder.Configuration["MongoDB:ConnectionString"], builder.Configuration["MongoDB:DatabaseName"]));
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddControllers();
            // Add other necessary services like Razor Pages or MVC if needed.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/login");


            app.Run();
        }
    }
}
