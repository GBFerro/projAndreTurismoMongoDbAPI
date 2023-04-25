using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace projAndreTurismoMongoDbAPI.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostCode { get; set; }
        public string? Complement { get; set; }
        public City City { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
