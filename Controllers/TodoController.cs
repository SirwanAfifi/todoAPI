using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using todoAPI.Models;
using todoAPI.Services;

namespace todoAPI.Controllers
{
    public class TodoController
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task GetTodos(HttpContext http)
        {
            var todos = _todoService.GetAllToDoItmes();
            await http.Response.WriteJsonAsync(todos);
        }

        public async Task CreateTodo(HttpContext http)
        {
            var todo = await http.Request.ReadJsonAsync<Todo>();
            _todoService.AddTodo(todo);
            http.Response.StatusCode = 204;
        }

        public async Task ToggleTodo(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGet("id", out int id))
            {
                http.Response.StatusCode = 400;
                return;
            }
            _todoService.ToggleTodo(id);
            http.Response.StatusCode = 204;
        }

        public async Task DeleteTodo(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGet("id", out int id))
            {
                http.Response.StatusCode = 400;
                return;
            }
            _todoService.DeleteTodo(id);
            http.Response.StatusCode = 204;
        }
    }
}