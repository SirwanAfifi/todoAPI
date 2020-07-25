using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using todoAPI.Controllers;
using todoAPI.Services;

namespace todoAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<TodoController>();
            builder.Services.AddTransient<ITodoService, TodoService>();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var todoController = serviceProvider.GetService<TodoController>();

            var app = WebApplication.Create(args);

            app.MapGet("/", todoController.GetTodos);
            app.MapPost("/api/todos", todoController.CreateTodo);
            app.MapPost("/api/todos/{id}", todoController.ToggleTodo);
            app.MapDelete("/api/todos/{id}", todoController.DeleteTodo);

            await app.RunAsync();
        }
    }
}
