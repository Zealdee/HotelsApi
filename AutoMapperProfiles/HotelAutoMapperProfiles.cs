using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;

namespace HotelsApi.AutoMapperProfiles
{
    public class HotelAutoMapperProfiles : Profile
    {
        public HotelAutoMapperProfiles()
        {
            CreateMap<CreateHotel, Hotel>();
            CreateMap<UpdateHotel, Hotel>();
            CreateMap<Hotel, GetHotel>();
        }
    }

}
