
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Context;
using HotelsApi.Entities;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public CitiesController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<City>> GetAllCities()
        {
            var city = await databaseContext.Cities.ToListAsync();

            return city;
        }

        [HttpGet("{id}")]
        public async Task<City?> GetCityById([FromRoute] int id)
        {
            var city = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            return city;
        }

        [HttpPost()]
        public async Task<City> CreateCity([FromBody] City city)
        {
            databaseContext.Cities.Add(city);
            await databaseContext.SaveChangesAsync();

            return city;
        }

        [HttpPut("{id}")]
        public async Task<City?> UpdateCity([FromRoute] int id, [FromBody] City city)
        {

            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            if (cityRecord == null)
            {
                return null;
            }

            cityRecord.CityName = city.CityName;
            cityRecord.CityCode = city.CityCode;

            await databaseContext.SaveChangesAsync();

            return cityRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCity([FromRoute] int id)
        {
            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            if (cityRecord == null)
            {
                return false;
            }

            databaseContext.Cities.Remove(cityRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }
    }
}
