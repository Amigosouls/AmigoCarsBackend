using AmigoCars.Contracts;
using AmigoCars.Exceptions;
using AmigoCars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace AmigoCars.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly AmigoCarsContext _context;
        public CitiesRepository(AmigoCarsContext context)
        {
            _context = context;
        }
        public async Task<List<Address>> GetCities(int pin)
        {
            try
            {
                var address = await _context.Addresses.Where(x=>x.Pincode==pin).ToListAsync();
                if(address!=null)
                {
                    return  address;
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException("The requested URL is unreachable");
            }
            return null;
        }

        public async Task<List<Rto>> RtoNames(string rto)
        {
            var rtoNames = await _context.Rtos.Where(x => x.RegNo == rto).ToListAsync();
            if (rtoNames != null)
                return rtoNames;
            else
                throw new BadRequestException("The Request cannot be made now, or the data is invalid!");
        }
    }
}
