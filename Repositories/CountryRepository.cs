using HotelsApi.Context;
using HotelsApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelsApi.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country?> GetCountryById(int id);
        Task<Country> CreateCountry(Country country);
        Task<Country?> UpdateCountry(int id, Country country);
        Task<bool> DeleteCountry(int id);
        Task<Country?> GetCountryName(string countryName);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext databaseContext;

        public CountryRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Country>> GetAllCountries()
        {
            var country = await databaseContext.Countries.ToListAsync();

            return country;
        }
        public async Task<Country?> GetCountryById(int id)
        {
            var country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            return country;
        }
        public async Task<Country> CreateCountry(Country country)
        {
            databaseContext.Countries.Add(country);
            await databaseContext.SaveChangesAsync();

            return country;
        }
        public async Task<Country?> UpdateCountry(int id, Country country)
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
        public async Task<bool> DeleteCountry(int id)
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
        public async Task<Country?> GetCountryName(string countryName)
        {
            Country? country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryName == countryName);

            return country;
        }
    }
}
