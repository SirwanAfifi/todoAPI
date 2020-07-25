using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;

namespace todoAPI.Models
{
    public class Todo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }

    public class TodoData
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