using ConnectToMongo.Models;
using MongoDB.Driver;

namespace ConnectToMongo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _category;

        public CategoryService(ICategoryStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
           _category =  database.GetCollection<Category>(settings.CategoryCollectionName);
        } 
        public List<Category> Get()
        {
            return _category.Find(s => true).ToList();
        }
    }
}
