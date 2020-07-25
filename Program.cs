using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using todoAPI.Services;

namespace todoAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddControllers();

            builder.Services.AddSingleton<ITodoService, TodoService>();

            var serviceProvider = builder.Services.BuildServiceProvider();

            var app = builder.Build();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
