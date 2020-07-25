using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoAPI.Models;
using todoAPI.Services;

namespace todoAPI.Controllers
{
    public class TodoController
    {
        private readonly ITodoService _todoService;
        private readonly IHttpContextAccessor _accessor;
        public TodoController(ITodoService todoService, IHttpContextAccessor accessor)
        {
            _todoService = todoService;
            _accessor = accessor;
        }

        [HttpGet("/todos")]
        public async Task GetTodos()
        {
            var todos = _todoService.GetAllToDoItmes();
            await _accessor.HttpContext.Response.WriteJsonAsync(todos);
        }

        [HttpPost("/todos")]
        public async Task CreateTodo()
        {
            var todo = await _accessor.HttpContext.Request.ReadJsonAsync<Todo>();
            _todoService.AddTodo(todo);
            _accessor.HttpContext.Response.StatusCode = 204;
        }

        [HttpPost("/todos/{id}")]
        public async Task ToggleTodo(int id)
        {
            _todoService.ToggleTodo(id);
            _accessor.HttpContext.Response.StatusCode = 204;
        }

        [HttpDelete("/todos/{id}")]
        public async Task DeleteTodo(int id)
        {
            _todoService.DeleteTodo(id);
            _accessor.HttpContext.Response.StatusCode = 204;
        }
    }
}