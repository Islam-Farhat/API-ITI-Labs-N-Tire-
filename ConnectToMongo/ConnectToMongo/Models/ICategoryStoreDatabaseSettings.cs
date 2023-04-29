namespace ConnectToMongo.Models
{
    public interface ICategoryStoreDatabaseSettings
    {
        string CategoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
