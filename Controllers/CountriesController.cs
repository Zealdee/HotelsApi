
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Context;
using HotelsApi.Entities;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public CountriesController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<Country>> GetAllCountries()
        {
            var country = await databaseContext.Countries.ToListAsync();

            return country;
        }

        [HttpGet("{id}")]
        public async Task<Country?> GetCountryById([FromRoute] int id)
        {
            var country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            return country;
        }

        [HttpPost()]
        public async Task<Country> CreateCountry([FromBody] Country country)
        {
            databaseContext.Countries.Add(country);
            await databaseContext.SaveChangesAsync();

            return country;
        }

        [HttpPut("{id}")]
        public async Task<Country?> UpdateCountry([FromRoute] int id, [FromBody] Country country)
        {

            var countryRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (countryRecord == null)
            {
                return null;
            }

            countryRecord.CountryName = country.CountryName;
            countryRecord.CountryCode = country.CountryCode;

            await databaseContext.SaveChangesAsync();

            return countryRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCountry([FromRoute] int id)
        {
            var countryRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (countryRecord == null)
            {
                return false;
            }

            databaseContext.Countries.Remove(countryRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }
    }
}
