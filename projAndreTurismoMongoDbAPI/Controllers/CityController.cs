﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projAndreTurismoMongoDbAPI.Models;
using projAndreTurismoMongoDbAPI.Services;

namespace projAndreTurismoMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);
            if (city == null) return NotFound();

            return city;
        }

        [HttpPost]
        public ActionResult<City> Create(City city) => _cityService.Insert(city);

        [HttpPut("{id:length(24)}", Name = "PutCity")]
        public ActionResult Update(string id, City city)
        {
            var c = _cityService.Get(id);
            if (c == null) return NotFound();

            _cityService.Update(id, city);

            return Ok();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCity")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var city = _cityService.Get(id);
            if (city == null) return NotFound();

            _cityService.Delete(id);

            return Ok();
        }

    }
}
