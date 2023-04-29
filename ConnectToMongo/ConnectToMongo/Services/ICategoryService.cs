using ConnectToMongo.Models;

namespace ConnectToMongo.Services
{
    public interface ICategoryService
    {
        List<Category> Get();
    }
}
