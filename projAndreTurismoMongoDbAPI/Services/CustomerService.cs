using MongoDB.Driver;
using projAndreTurismoMongoDbAPI.Config;
using projAndreTurismoMongoDbAPI.Models;

namespace projAndreTurismoMongoDbAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjATMSettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }
    }
}
