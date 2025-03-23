using HotelsApi.Context;
using HotelsApi.Entities;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Dtos;
using HotelsApi.Validators;
using AutoMapper;
using FluentValidation.Results;
using HotelsApi.Repositories;

namespace HotelsApi.Services
{
    public interface ICountryService
    {
        Task<List<GetCountryName>> GetAllCountries();

        Task<GetCountryName?> GetCountryById(int id);

        Task<GetCountryName> CreateCountry(CreateCountry country);

        Task<GetCountryName?> UpdateCountry(int id, UpdateCountry country);

        Task<bool> DeleteCountry(int id);

    }
    public class CountryService(ICountryRepository countryRepository, IMapper mapper) : ICountryService
    {
        private readonly ICountryRepository countryRepository = countryRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetCountryName> CreateCountry(CreateCountry country)
        {
            CreateCountryValidator validator = new(countryRepository);
            ValidationResult results = validator.Validate(country);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createCountry = await countryRepository.CreateCountry(mapper.Map<Country>(country));
            return mapper.Map<GetCountryName>(createCountry);
        }
        public async Task<bool> DeleteCountry(int id)
        {
            var deleteResult = await countryRepository.DeleteCountry(id);

            return deleteResult;


        }

        public async Task<List<GetCountryName>> GetAllCountries()
        {
            var country = await countryRepository.GetAllCountries();

            return mapper.Map<List<GetCountryName>>(country);
        }

        public async Task<GetCountryName?> GetCountryById(int id)
        {
            var country = await countryRepository.GetCountryById(id);

            return mapper.Map<GetCountryName>(country);
        }

        public async Task<GetCountryName?> UpdateCountry(int id, UpdateCountry country)
        {
            var updateCountryResult = await countryRepository.UpdateCountry(id, mapper.Map<Country>(country));

            return mapper.Map<GetCountryName>(updateCountryResult);
        }
    }
}
