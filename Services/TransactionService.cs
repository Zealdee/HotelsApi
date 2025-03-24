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
    public interface ITransactionService
    {
        Task<List<GetTransactionName>> GetAllTransactions();

        Task<GetTransactionName?> GetTransactionById(int id);

        Task<GetTransactionName> CreateTransaction(CreateTransaction transaction);

        Task<GetTransactionName?> UpdateTransaction(int id, UpdateTransaction transaction);

        Task<bool> DeleteTransaction(int id);

    }
    public class TransactionService(ITransactionRepository transactionRepository, IMapper mapper) : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository = transactionRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetTransactionName> CreateTransaction(CreateTransaction transaction)
        {
            CreateTransactionValidator validator = new(transactionRepository);
            ValidationResult results = validator.Validate(transaction);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createTransaction = await transactionRepository.CreateTransaction(mapper.Map<Transaction>(transaction));
            return mapper.Map<GetTransactionName>(createTransaction);
        }
        public async Task<bool> DeleteTransaction(int id)
        {
            var deleteResult = await transactionRepository.DeleteTransaction(id);

            return deleteResult;


        }

        public async Task<List<GetTransactionName>> GetAllTransactions()
        {
            var transaction = await transactionRepository.GetAllTransactions();

            return mapper.Map<List<GetTransactionName>>(transaction);
        }

        public async Task<GetTransactionName?> GetTransactionById(int id)
        {
            var transaction = await transactionRepository.GetTransactionById(id);

            return mapper.Map<GetTransactionName>(transaction);
        }

        public async Task<GetTransactionName?> UpdateTransaction(int id, UpdateTransaction transaction)
        {
            var updateTransactionResult = await transactionRepository.UpdateTransaction(id, mapper.Map<Transaction>(transaction));

            return mapper.Map<GetTransactionName>(updateTransactionResult);
        }
    }
}
