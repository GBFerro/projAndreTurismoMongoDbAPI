using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projAndreTurismoMongoDbAPI.Models;
using projAndreTurismoMongoDbAPI.Services;

namespace projAndreTurismoMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CityService _cityService;
        private readonly AddressService _addressService;
        private readonly CustomerService _customerService;

        public CustomerController(CityService cityService, AddressService addressService, CustomerService customerService)
        {
            _cityService = cityService;
            _addressService = addressService;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            _cityService.Insert(customer.Address.City);
            customer.Address = _addressService.Insert(customer.Address);
            _customerService.Insert(customer);

            return customer;
        }

        [HttpPut("{id:length(24)}", Name = "PutCustomer")]
        public ActionResult Update(string id, Customer customer)
        {
            var c = _customerService.Get(id);
            if (c == null) return NotFound();
            _customerService.Update(id, customer);

            return Ok();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCustomer")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            _customerService.Delete(id);

            return Ok();
        }
    }
}
