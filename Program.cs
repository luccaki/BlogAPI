using BlogAPI.Data;
using BlogAPI.Middlewares;
using BlogAPI.Repositories;
using BlogAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BlogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

            builder.Services.AddScoped<PostRepository>();
            builder.Services.AddScoped<CommentRepository>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File($"logs/log_{DateTime.Now.Date}.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            try
            {
                Log.Information("Starting up the application");

                var app = builder.Build();

                app.UseMiddleware<ExceptionHandlingMiddleware>();

                // Configure the HTTP request pipeline.
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start correctly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}