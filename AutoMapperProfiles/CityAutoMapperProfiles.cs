using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;

namespace HotelsApi.AutoMapperProfiles
{
    public class CityAutoMapperProfiles : Profile
    {
        public CityAutoMapperProfiles()
        {
            CreateMap<CreateCity, City>();
            CreateMap<UpdateCity, City>();
            CreateMap<City, GetCityName>();
        }
    }
}
