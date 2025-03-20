using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;


namespace HotelsApi.AutoMapperProfiles
{
    public class StateAutoMapperProfiles : Profile
    {
        public StateAutoMapperProfiles()
        {
            CreateMap<CreateState, State>();
            CreateMap<UpdateState, State>();
            CreateMap<State, GetState>();
        }
    }
}
