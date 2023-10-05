using AmigoCars.DTOs.Incoming;
using AmigoCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCars.Contracts
{
    public interface ICarsRepository
    {
        public Task<Success> CreateCar([FromBody] CarDetail createCar);
        public Task<List<CarsDatum>> GetCarDetail(string brand, string model);
    }
}
