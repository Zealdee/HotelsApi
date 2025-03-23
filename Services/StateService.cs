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
    public interface IStateService
    {
        Task<List<GetStateName>> GetAllStates();

        Task<GetStateName?> GetStateById(int id);

        Task<GetStateName> CreateState(CreateState state);

        Task<GetStateName?> UpdateState(int id, UpdateState state);

        Task<bool> DeleteState(int id);

    }
    public class StateService(IStateRepository stateRepository, IMapper mapper) : IStateService
    {
        private readonly IStateRepository stateRepository = stateRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetStateName> CreateState(CreateState state)
        {
            CreateStateValidator validator = new(stateRepository);
            ValidationResult results = validator.Validate(state);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createState = await stateRepository.CreateState(mapper.Map<State>(state));
            return mapper.Map<GetStateName>(createState);
        }
        public async Task<bool> DeleteState(int id)
        {
            var deleteResult = await stateRepository.DeleteState(id);

            return deleteResult;


        }

        public async Task<List<GetStateName>> GetAllStates()
        {
            var state = await stateRepository.GetAllStates();

            return mapper.Map<List<GetStateName>>(state);
        }

        public async Task<GetStateName?> GetStateById(int id)
        {
            var state = await stateRepository.GetStateById(id);

            return mapper.Map<GetStateName>(state);
        }

        public async Task<GetStateName?> UpdateState(int id, UpdateState state)
        {
            var updateStateResult = await stateRepository.UpdateState(id, mapper.Map<State>(state));

            return mapper.Map<GetStateName>(updateStateResult);
        }
    }
}
