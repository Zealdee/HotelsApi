
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Context;
using HotelsApi.Entities;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public StatesController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<State>> GetAllStates()
        {
            var state = await databaseContext.States.ToListAsync();

            return state;
        }

        [HttpGet("{id}")]
        public async Task<State?> GetStateById([FromRoute] int id)
        {
            var state = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            return state;
        }

        [HttpPost()]
        public async Task<State> CreateState([FromBody] State state)
        {
            databaseContext.States.Add(state);
            await databaseContext.SaveChangesAsync();

            return state;
        }

        [HttpPut("{id}")]
        public async Task<State?> UpdateState([FromRoute] int id, [FromBody] State state)
        {

            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return null;
            }

            stateRecord.StateName = state.StateName;
            stateRecord.StateCode = state.StateCode;

            await databaseContext.SaveChangesAsync();

            return stateRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteState([FromRoute] int id)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return false;
            }

            databaseContext.States.Remove(stateRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }
    }
}
