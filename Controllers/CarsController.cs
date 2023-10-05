using AmigoCars.Contracts;
using AmigoCars.DTOs.Incoming;
using AmigoCars.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _carRepository;


        public CarsController(ICarsRepository carRepository)
        {
            this._carRepository = carRepository;

        }
        [HttpPost("CarDetails")]
        public async Task<ActionResult<Success>> CreateCars([FromBody] CarDetail createCar)
        {
            var response = await _carRepository.CreateCar(createCar);
            return response;
        }
        [HttpGet("FindCar")]
        public async Task<List<CarsDatum>> FetchCar(string brand,string model)
        {
            var result = await _carRepository.GetCarDetail(brand, model);
            return result;
        }
    }
}
