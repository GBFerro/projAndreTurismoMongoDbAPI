using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projAndreTurismoMongoDbAPI.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
