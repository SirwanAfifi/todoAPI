using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using todoAPI.Models;

namespace todoAPI
{
    class Program
    {
        private static readonly TodoData db = new TodoData();
        static async Task Main(string[] args)
        {
            var app = WebApplication.Create(args);

            app.MapGet("/", GetTodos);
            app.MapPost("/api/todos", CreateTodo);
            app.MapPost("/api/todos/{id}", ToggleTodo);
            app.MapDelete("/api/todos/{id}", DeleteTodo);

            await app.RunAsync();
        }

        static async Task GetTodos(HttpContext http)
        {
            var todos = db.GetAllToDoItmes();
            await http.Response.WriteJsonAsync(todos);
        }

        static async Task CreateTodo(HttpContext http)
        {
            var todo = await http.Request.ReadJsonAsync<Todo>();
            db.AddTodo(todo);
            http.Response.StatusCode = 204;
        }

        static async Task ToggleTodo(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGet("id", out int id))
            {
                http.Response.StatusCode = 400;
                return;
            }
            db.ToggleTodo(id);
            http.Response.StatusCode = 204;
        }

        static async Task DeleteTodo(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGet("id", out int id))
            {
                http.Response.StatusCode = 400;
                return;
            }
            db.DeleteTodo(id);
            http.Response.StatusCode = 204;
        }
    }
}
