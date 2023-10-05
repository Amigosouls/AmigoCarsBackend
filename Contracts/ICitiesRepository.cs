using AmigoCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCars.Contracts
{
    public interface ICitiesRepository
    {
        public Task<List<Address>> GetCities(int pin);
        public Task<List<Rto>> RtoNames(string rto);
        
    }
}
