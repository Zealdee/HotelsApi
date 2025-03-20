using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;

namespace HotelsApi.AutoMapperProfiles
{
    public class BarangayAutoMapperProfiles : Profile
    {
        public BarangayAutoMapperProfiles()
        {
            CreateMap<CreateBarangay, Barangay>();
            CreateMap<UpdateBarangay, Barangay>();
            CreateMap<Barangay, GetBarangay>();
        }
    }
}
