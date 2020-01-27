
namespace ToDoAPI.Models
{
    public class ToDoDatabaseSettings : IToDoDatabaseSettings
    {
        public string ToDoCollectionsName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IToDoDatabaseSettings
    {
        string ToDoCollectionsName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
