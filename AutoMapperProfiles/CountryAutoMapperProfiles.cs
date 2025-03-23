using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;


namespace HotelsApi.AutoMapperProfiles
{
    public class CountryAutoMapperProfiles : Profile
    {
        public CountryAutoMapperProfiles()
        {
            CreateMap<CreateCountry, Country>();
            CreateMap<UpdateCountry, Country>();
            CreateMap<Country, GetCountryName>();
        }
    }
}
