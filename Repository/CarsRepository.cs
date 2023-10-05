using AmigoCars.Contracts;
using AmigoCars.DTOs.Incoming;
using AmigoCars.Exceptions;
using AmigoCars.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCars.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly AmigoCarsContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CarsRepository(AmigoCarsContext context, IConfiguration config, IMapper mapper)
        {
            this._context = context;
            this._configuration = config;
            this._mapper = mapper;
        }
        public async Task<Success> CreateCar([FromBody] CarDetail createCar)
        {
            if (createCar == null) throw new ArgumentNullException("Sorry! No data Recieved");
            //var result =  _mapper.Map<CreateCarDto>(createCar);
            await this._context.AddAsync(createCar);
            await this._context.SaveChangesAsync();
            return new Success{ Message = "Car Details saved Successfully", StatusCode = 200 }; 
        }

        public async Task<List<CarsDatum>> GetCarDetail(string brand,string modal)
        {
            var carData = _context.CarsData.Where(x => x.Make.ToLower().Contains(brand.ToLower()) || x.Model.ToLower().Contains(modal.ToLower())).ToList();
            if (carData != null)
            {
                return carData;
            }
            else
                throw new NotFoundException("No result found");
        }
    }
}
