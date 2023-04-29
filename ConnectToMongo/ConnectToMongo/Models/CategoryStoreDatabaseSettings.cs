namespace ConnectToMongo.Models
{
    public class CategoryStoreDatabaseSettings:ICategoryStoreDatabaseSettings
    {
        public string CategoryCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
