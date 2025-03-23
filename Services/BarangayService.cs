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
    public interface IBarangayService
    {
        Task<List<GetBarangayName>> GetAllBarangays();

        Task<GetBarangayName?> GetBarangayById(int id);

        Task<GetBarangayName> CreateBarangay(CreateBarangay barangay);

        Task<GetBarangayName?> UpdateBarangay(int id, UpdateBarangay barangay);

        Task<bool> DeleteBarangay(int id);

    }
    public class BarangayService(IBarangayRepository barangayRepository, IMapper mapper) : IBarangayService
    {
        private readonly IBarangayRepository barangayRepository = barangayRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetBarangayName> CreateBarangay(CreateBarangay barangay)
        {
            CreateBarangayValidator validator = new(barangayRepository);
            ValidationResult results = validator.Validate(barangay);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createBarangay = await barangayRepository.CreateBarangay(mapper.Map<Barangay>(barangay));
            return mapper.Map<GetBarangayName>(createBarangay);
        }
        public async Task<bool> DeleteBarangay(int id)
        {
            var deleteResult = await barangayRepository.DeleteBarangay(id);

            return deleteResult;


        }

        public async Task<List<GetBarangayName>> GetAllBarangays()
        {
            var barangay = await barangayRepository.GetAllBarangays();

            return mapper.Map<List<GetBarangayName>>(barangay);
        }

        public async Task<GetBarangayName?> GetBarangayById(int id)
        {
            var barangay = await barangayRepository.GetBarangayById(id);

            return mapper.Map<GetBarangayName>(barangay);
        }

        public async Task<GetBarangayName?> UpdateBarangay(int id, UpdateBarangay barangay)
        {
            var updateBarangayResult = await barangayRepository.UpdateBarangay(id, mapper.Map<Barangay>(barangay));

            return mapper.Map<GetBarangayName>(updateBarangayResult);
        }
    }
}
