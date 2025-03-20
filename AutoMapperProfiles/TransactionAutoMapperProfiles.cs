using AutoMapper;
using HotelsApi.Dtos;
using HotelsApi.Entities;

namespace HotelsApi.AutoMapperProfiles
{
    public class TransactionAutoMapperProfiles : Profile
    {
        public TransactionAutoMapperProfiles()
        {
            CreateMap<CreateTransaction, Transaction>();
            CreateMap<UpdateTransaction, Transaction>();
            CreateMap<Transaction, GetTransaction>();
        }
    }
}
