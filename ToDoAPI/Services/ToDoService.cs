using ToDoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ToDoAPI.Services
{
    public class ToDoService
    {
        private readonly IMongoCollection<ToDoItem> _items;

        public ToDoService(IToDoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<ToDoItem>(settings.ToDoCollectionsName);
        }

        public List<ToDoItem> Get()
        {
            return _items.Find(item => true).ToList();
        }
        public ToDoItem Get(long id)
        {
            return _items.Find<ToDoItem>(_ => _.Id == id).FirstOrDefault();
        }
        public ToDoItem Create(ToDoItem item)
        {
            _items.InsertOne(item);
            return item;
        }
        public void Update(ToDoItem item)
        {
            _items.ReplaceOne(_=>_.Id == item.Id, item);
        }
        public void Delete(ToDoItem item)
        {
            _items.DeleteOne(_ => _.Id == item.Id);
        }
        public void Delete(long id)
        {
            _items.DeleteOne(_ => _.Id == id);
        }
    }
}
