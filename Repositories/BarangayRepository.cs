using HotelsApi.Context;
using HotelsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsApi.Repositories
{
    public interface IBarangayRepository
    {
        Task<List<Barangay>> GetAllBarangays();
        Task<Barangay?> GetBarangayById(int id);
        Task<Barangay> CreateBarangay(Barangay barangay);
        Task<Barangay?> UpdateBarangay(int id, Barangay barangay);
        Task<bool> DeleteBarangay(int id);
        Task<Barangay?> GetBarangayName(string barangayName);

    }
    public class BarangayRepository : IBarangayRepository
    {
        private readonly DatabaseContext databaseContext;

        public BarangayRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Barangay>> GetAllBarangays()
        {
            var barangay = await databaseContext.Barangays.ToListAsync();

            return barangay;
        }
        public async Task<Barangay?> GetBarangayById(int id)
        {
            var barangay = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            return barangay;
        }
        public async Task<Barangay> CreateBarangay(Barangay barangay)
        {
            databaseContext.Barangays.Add(barangay);
            await databaseContext.SaveChangesAsync();

            return barangay;
        }
        public async Task<Barangay?> UpdateBarangay(int id,Barangay barangay)
        {

            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return null;
            }

            barangayRecord.BarangayName = barangay.BarangayName;
            barangayRecord.PostalCode = barangay.PostalCode;

            await databaseContext.SaveChangesAsync();

            return barangayRecord;
        }
        public async Task<bool> DeleteBarangay(int id)
        {
            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return false;
            }

            databaseContext.Barangays.Remove(barangayRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }

        public async Task<Barangay?> GetBarangayName(string barangayName)
        {
            Barangay? barangay = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayName == barangayName);

            return barangay;
        }
    }
}
