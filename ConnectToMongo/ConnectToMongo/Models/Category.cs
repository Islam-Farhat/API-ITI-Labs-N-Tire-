using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConnectToMongo.Models
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("name")]
        public string? name { get; set; }
        [BsonElement("icon")]
        public string? icon { get; set; }
    }
}
