using HotelsApi.Context;
using HotelsApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace HotelsApi.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction?> GetTransactionById(int id);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction?> UpdateTransaction(int id, Transaction transaction);
        Task<bool> DeleteTransaction(int id);
        Task<Transaction?> GetTransactionName(string transactionName);
        Task<Transaction?> GetTransactionNumber(int transactionNumber);

    }
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext databaseContext;

        public TransactionRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Transaction>> GetAllTransactions()
        {
            var transaction = await databaseContext.Transactions.ToListAsync();

            return transaction;
        }
        public async Task<Transaction?> GetTransactionById(int id)
        {
            var transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            return transaction;
        }
        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            databaseContext.Transactions.Add(transaction);
            await databaseContext.SaveChangesAsync();

            return transaction;
        }
        public async Task<Transaction?> UpdateTransaction(int id, Transaction transaction)
        {

            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionRecord == null)
            {
                return null;
            }

            transactionRecord.HotelId = transaction.HotelId;
            transactionRecord.HotelName = transaction.HotelName;
            transactionRecord.HotelCode = transaction.HotelCode;
            transactionRecord.DateTo = transaction.DateTo;
            transactionRecord.DateFrom = transaction.DateFrom;
            transactionRecord.FullName = transaction.FullName;
            transactionRecord.PhoneNumber = transaction.PhoneNumber;
            transactionRecord.EmailAddress = transaction.EmailAddress;

            await databaseContext.SaveChangesAsync();

            return transactionRecord;
        }
        public async Task<bool> DeleteTransaction(int id)
        {
            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionRecord == null)
            {
                return false;
            }

            databaseContext.Transactions.Remove(transactionRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }

        public async Task<Transaction?> GetTransactionName(string transactionName)
        {
            Transaction? transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.FullName == transactionName);

            return transaction;
        }

        public async Task<Transaction?> GetTransactionNumber(int transactionNumber)
        {
            Transaction? transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.PhoneNumber == transactionNumber);

            return transaction;
        }
    }
}
