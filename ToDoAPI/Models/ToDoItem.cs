using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ToDoAPI.Models
{
    public class ToDoItem
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
