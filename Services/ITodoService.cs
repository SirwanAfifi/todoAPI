using System.Collections;
using System.Collections.Generic;
using todoAPI.Models;

namespace todoAPI.Services
{
    public interface ITodoService
    {
        void AddTodo(Todo item);
        void DeleteTodo(int id);
        IList<Todo> GetAllToDoItmes();
        void ToggleTodo(int id);
    }
}