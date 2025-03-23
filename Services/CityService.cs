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
    public interface ICityService
    {
        Task<List<GetCityName>> GetAllCities();

        Task<GetCityName?> GetCityById(int id);

        Task<GetCityName> CreateCity(CreateCity city);

        Task<GetCityName?> UpdateCity(int id, UpdateCity city);

        Task<bool> DeleteCity(int id);

    }
    public class CityService(ICityRepository cityRepository, IMapper mapper) : ICityService
    {
        private readonly ICityRepository cityRepository = cityRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetCityName> CreateCity(CreateCity city)
        {
            CreateCityValidator validator = new(cityRepository);
            ValidationResult results = validator.Validate(city);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createCity = await cityRepository.CreateCity(mapper.Map<City>(city));
            return mapper.Map<GetCityName>(createCity);
        }
        public async Task<bool> DeleteCity(int id)
        {
            var deleteResult = await cityRepository.DeleteCity(id);

            return deleteResult;


        }

        public async Task<List<GetCityName>> GetAllCities()
        {
            var city = await cityRepository.GetAllCities();

            return mapper.Map<List<GetCityName>>(city);
        }

        public async Task<GetCityName?> GetCityById(int id)
        {
            var city = await cityRepository.GetCityById(id);

            return mapper.Map<GetCityName>(city);
        }

        public async Task<GetCityName?> UpdateCity(int id, UpdateCity city)
        {
            var updateCityResult = await cityRepository.UpdateCity(id, mapper.Map<City>(city));

            return mapper.Map<GetCityName>(updateCityResult);
        }
    }
}
