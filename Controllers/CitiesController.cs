using AmigoCars.Contracts;
using AmigoCars.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace AmigoCars.Controllers
{
    [Route("api/Citis")]
    [ApiController]

    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _cities;
        public CitiesController(ICitiesRepository citiesRepository) 
        {
            _cities = citiesRepository;
        }
        [HttpGet]
        public async Task<List<Address>> GetCities(int pin)
        {
            var cities = await _cities.GetCities(pin);
            return cities;
        }

        [HttpGet("Rto")]
        public async Task<List<Rto>> GetRto(string rto)
        {
            var rtoName = await _cities.RtoNames(rto.ToUpper());
            return rtoName;
        }
    }
}
