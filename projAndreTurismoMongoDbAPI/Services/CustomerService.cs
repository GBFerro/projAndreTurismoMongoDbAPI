using System.Net;
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

        public List<Customer> Get() => _customer.Find(a => true).ToList();
        public Customer Get(string id) => _customer.Find(a => a.Id == id).FirstOrDefault();

        public Customer Insert(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(a => a.Id == id, customer);
        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);
    }
}
