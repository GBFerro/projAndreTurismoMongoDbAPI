using MongoDB.Driver;
using projAndreTurismoMongoDbAPI.Config;
using projAndreTurismoMongoDbAPI.Models;

namespace projAndreTurismoMongoDbAPI.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        public AddressService(IProjATMSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }
    }
}
