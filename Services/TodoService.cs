using System.Collections;
using System.Collections.Generic;
using todoAPI.Models;
using System.Linq;

namespace todoAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly IList<Todo> _db = new List<Todo>
        {
            new Todo { Id = 1, Title = "Read book" },
            new Todo { Id = 2, Title = "Watch an episode of Dark" },
            new Todo { Id = 3, Title = "Publish a post on dotnettips" },
            new Todo { Id = 4, Title = "Skype with my friend" },
        };
        public IList<Todo> GetAllToDoItmes()
        {
            return _db;
        }
        public void AddTodo(Todo item)
        {
            _db.Add(item);
        }
        public void ToggleTodo(int id)
        {
            var todo = _db.FirstOrDefault(x => x.Id == id);
            todo.Completed = !todo.Completed;
        }

        public void DeleteTodo(int id)
        {
            var todo = _db.FirstOrDefault(x => x.Id == id);
            _db.Remove(todo);
        }
    }
}