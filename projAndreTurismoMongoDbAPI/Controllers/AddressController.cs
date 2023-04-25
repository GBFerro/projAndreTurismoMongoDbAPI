using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projAndreTurismoMongoDbAPI.Models;
using projAndreTurismoMongoDbAPI.Services;

namespace projAndreTurismoMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return address;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            address.City = _cityService.Insert(address.City);
            _addressService.Insert(address);

            return address;
        }
        [HttpPut("{id:length(24)}", Name = "PutAddress")]
        public ActionResult Update(string id, Address address)
        {
            var a = _addressService.Get(id);
            if (a == null) return NotFound();

            _addressService.Update(id, address);

            return Ok();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteAddress")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var address = _addressService.Get(id);
            if (address == null) return NotFound();

            _addressService.Delete(id);

            return Ok();
        }

    }
}
