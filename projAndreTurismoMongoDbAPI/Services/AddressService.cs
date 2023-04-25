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

        public List<Address> Get() => _address.Find(a => true).ToList();
        public Address Get(string id) => _address.Find(a => a.Id == id).FirstOrDefault();

        public Address Insert(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(a => a.Id == id, address);
        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);
    }
}
