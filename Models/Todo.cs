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


}