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
    public interface IHotelService
    {
        Task<List<GetHotelName>> GetAllHotels();

        Task<GetHotelName?> GetHotelById(int id);

        Task<GetHotelName> CreateHotel(CreateHotel hotel);

        Task<GetHotelName?> UpdateHotel(int id, UpdateHotel hotel);

        Task<bool> DeleteHotel(int id);

    }
    public class HotelService(IHotelRepository hotelRepository, IMapper mapper) : IHotelService
    {
        private readonly IHotelRepository hotelRepository = hotelRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetHotelName> CreateHotel(CreateHotel hotel)
        {
            CreateHotelValidator validator = new(hotelRepository);
            ValidationResult results = validator.Validate(hotel);
            
            if(results.Errors.Count>0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createHotel = await hotelRepository.CreateHotel(mapper.Map<Hotel>(hotel));
            return mapper.Map<GetHotelName>(createHotel);
        }
        public async Task<bool> DeleteHotel(int id)
        {
            var deleteResult = await hotelRepository.DeleteHotel(id);

            return deleteResult;


        }

        public async Task<List<GetHotelName>> GetAllHotels()
        {
            var hotel = await hotelRepository.GetAllHotels();

            return mapper.Map<List<GetHotelName>>(hotel);
        }

        public async Task<GetHotelName?> GetHotelById(int id)
        {
            var hotel = await hotelRepository.GetHotelById(id);

            return mapper.Map<GetHotelName>(hotel);
        }

        public async Task<GetHotelName?> UpdateHotel(int id, UpdateHotel hotel)
        {
            var updateHotelResult = await hotelRepository.UpdateHotel(id, mapper.Map<Hotel>(hotel));

            return mapper.Map<GetHotelName>(updateHotelResult);
        }
    }
}
